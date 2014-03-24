/*Define classes File { string name, int size } and Folder 
 * { string name, File[] files, Folder[] childFolders } and using 
 * them build a tree keeping all files and folders on the hard drive starting from 
 * C:\WINDOWS. Implement a method that calculates the sum of the file sizes in given
 * subtree of the tree and test it accordingly. Use recursive DFS traversal.
 * */

namespace FilesystemTree
{
    using System;
    using System.IO;
    using System.Numerics;

    class Program
    {
        static Folder BuildTree(DirectoryInfo directory)
        {
            var folder = new Folder(directory.Name);

            try
            {
                var files = directory.GetFiles();
                var childFolders = directory.GetDirectories();

                foreach (var file in files)
                {
                    folder.AddFile(new File(file.Name, file.Length));
                }

                foreach (var subfolder in childFolders)
                {
                    folder.AddFolder(BuildTree(subfolder));
                }
            }
            catch (UnauthorizedAccessException) 
            { }

            return folder;
        }

        static void Main()
        {
            const string RootFolderPath = "C:\\Windows";

            var rootDirectory = new DirectoryInfo(RootFolderPath);

            //Process might take a while, depending on the size of the folder.
            //It won't include files or folders with restricted access
            var rootFolder = BuildTree(rootDirectory);
            var rootFolderSize = rootFolder.GetSize();

            Console.WriteLine("Folder \"{0}\" size = {1} bytes",rootFolder.Name, rootFolderSize);
        }
    }
}
