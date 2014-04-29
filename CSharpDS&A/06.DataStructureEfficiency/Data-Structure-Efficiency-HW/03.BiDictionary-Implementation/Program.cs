namespace BiDictionaryImplementation
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var biDict = new BiDictionary<string, string, int>();

            biDict.Add("one", "ein", 1);
            biDict.Add("two", "zwei", 2);
            biDict.Add("three", "drei", 3);
            biDict.Add("four", "vier", 4);
            biDict.Add("one", "two", 12);
            biDict.Add("three", "vier", 43);

            biDict.RemoveWithFirstKey("one");

            Console.WriteLine(biDict.GetValuesBySecondKey("drei"));
            Console.WriteLine(biDict.GetValuesByFirstKey("three"));
            Console.WriteLine(biDict.GetValuesByBothKeys("three", "vier"));
        }
    }
}
