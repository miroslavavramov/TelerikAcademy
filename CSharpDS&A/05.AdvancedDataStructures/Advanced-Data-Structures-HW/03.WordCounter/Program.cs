namespace WordCount
{
    using rm.Trie;
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            string filePath = @"..\..\rainman-str.txt";

            var trie = TrieFactory.GetTrie();

            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    var words = Regex.Matches(reader.ReadToEnd(), @"\b\w+\b");

                    foreach (var word in words)
                    {
                        trie.AddWord(word.ToString());
                    }
                    
                    var extracted = trie.GetWords();

                    foreach (var word in extracted)
                    {
                        Console.WriteLine("{0}: {1} occurances", word, trie.WordCount(word));
                    }
                }
            }
            catch (FileNotFoundException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
    }
}
