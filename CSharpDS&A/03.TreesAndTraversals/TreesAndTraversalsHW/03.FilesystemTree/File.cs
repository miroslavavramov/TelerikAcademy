namespace FilesystemTree
{
    public class File
    {
        public File(string name = "", long size = 0)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; private set; }

        public long Size { get; private set; }
    }
}
