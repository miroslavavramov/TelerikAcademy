using System;
using System.Net;
//Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
//and stores it the current directory. Find in Google how to download files in C#. Be sure to catch 
//all exceptions and to free any used resources in the finally block.
class DownloadFile
{
    static void Main()
    {
        using (WebClient Client = new WebClient())
        {
            try
            {
                string url = @"http://telerikacademy.com/Content/Images/news-img01.png";
                Client.DownloadFile(url, "ninja.png");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid URL.");
            }
            catch (WebException)
            {
                Console.WriteLine("Invalid URL.");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The method has been called simultaneously on multiple threads");
            }
        }

    }
}

