namespace HashTableImplementation
{
    using System;
    
    class Program
    {
        static void Main()
        {
            var hashTable = new HashTable<string, int>();

            hashTable.Add("Helsinki", 15);
            hashTable.Add("Sydney", 22);
            hashTable.Add("Moscow", 2);
            hashTable.Add("Toronto", 71);
            hashTable.Add("Berlin", 40);

            hashTable.Remove("Moscow");

            Console.WriteLine(hashTable.ContainsKey("Moscow"));
            Console.WriteLine(hashTable.ContainsKey("Berlin"));

            Console.WriteLine(string.Join(", ", hashTable.Keys));

            hashTable["Helsinki"] = 37;
            Console.WriteLine(hashTable["Helsinki"]);

            foreach (var kvp in hashTable)
            {
                Console.WriteLine(kvp);
            }
        }
    }
}