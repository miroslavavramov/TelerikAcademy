using System;
using System.IO;
//Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
// reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…).
// Be sure to catch all possible exceptions and print user-friendly error messages.
class PrintText
{
    static void Main()
    {
        try
        {
            string text = File.ReadAllText(@"..\..\PrintText.cs");
            Console.WriteLine(text);
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Your path is either blank or contains invalid characters.");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("Your path is too long.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Directory not found.");
        }
        catch (IOException)
        {
            Console.WriteLine("Input/Output error.");
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("You have no permission to access this file.");
        }
        catch (NotSupportedException e)
        {
            Console.WriteLine("File is not supported.");
        }
    }
}

