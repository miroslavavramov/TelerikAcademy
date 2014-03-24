namespace FilesystemTree
{
    using System.Collections.Generic;
    using System.Numerics;

    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.ChildFolders = new List<Folder>();
        }

        public string Name { get; private set; }

        public List<File> Files { get; private set; }

        public ICollection<Folder> ChildFolders { get; private set; }
        
        public void AddFile(File file)
        {
            this.Files.Add(file);
        }

        public void AddFolder(Folder folder)
        {
            this.ChildFolders.Add(folder);
        }

        public BigInteger GetSize()
        {
            BigInteger size = 0;

            foreach (var file in this.Files)
            {
                size += file.Size;
            }

            foreach (var childFolder in this.ChildFolders)
            {
                size += childFolder.GetSize();
            }

            return size;
        }
    }
}
