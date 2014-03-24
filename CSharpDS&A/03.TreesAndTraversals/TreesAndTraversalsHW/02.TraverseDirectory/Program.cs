/*Write a program to traverse the directory C:\WINDOWS and all its subdirectories
  recursively and to display all files matching the mask *.exe. Use the class System.IO.Directory.*/
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static StreamWriter writer = new StreamWriter("../../output.txt");

    static void PrintExecutables(DirectoryInfo directory, Regex regex)
    {
        try
        {
            var files = directory.EnumerateFiles();

            //writer.WriteLine("{0}{1}{0} ", new string('-', 10), directory.FullName);

            foreach (var file in files)
            {
                if (regex.IsMatch(file.Name))
                {
                    writer.WriteLine(file.Name);
                }
            }

            var directories = directory.EnumerateDirectories();

            foreach (var dir in directories)
            {
                PrintExecutables(dir, regex);
            }
        }
        catch (UnauthorizedAccessException) 
        { }
    }

    static void Main()
    {
        const string RootFolderPath = "C:\\Windows";
        const string Pattern = "^(.*\\.exe)$";

        var rootDirectory = new DirectoryInfo(RootFolderPath);

        //Process might take a while, depending on the size of the folder.
        //It won't include files or folders with restricted access
        using (writer)
        {
            PrintExecutables(rootDirectory, new Regex(Pattern));
        }
    }
}

