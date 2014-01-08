using System;
////Write a program that parses an URL address given in the format:
//and extracts from it the [protocol], [server] and [resource] elements. 
//For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
//[protocol] = "http" [server] = "www.devbg.org" [resource] = "/forum/index.php"
class ParseURL
{
    static void Main()
    {
        string url = "http://www.regular-expressions.info/examples.html";

        string protocol = url.Substring(0, url.IndexOf(':'));

        int serverStartIndex = url.IndexOf("://") + 3;
        int serverEndIndex = url.IndexOf('/', serverStartIndex);
        string server = url.Substring(serverStartIndex, serverEndIndex-serverStartIndex);
        
        string resource = url.Substring(serverEndIndex, url.Length - serverEndIndex);

        Console.WriteLine(protocol);
        Console.WriteLine(server);
        Console.WriteLine(resource);
    }
}

