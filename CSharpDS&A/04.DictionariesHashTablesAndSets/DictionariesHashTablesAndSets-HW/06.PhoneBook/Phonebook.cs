namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Wintellect.PowerCollections;

    class Phonebook
    {
        private readonly char[] separators = new char[] {'|'};

        public Phonebook()
        {
            this.SelectedByName = 
                new MultiDictionary<string, Entry>(allowDuplicateValues: true);
            this.SelectedByNameAndTown = 
                new MultiDictionary<Tuple<string, string>, Entry>(allowDuplicateValues: true);
        }

        public MultiDictionary<string, Entry> SelectedByName { get; private set; }
        public MultiDictionary<Tuple<string,string>, Entry> SelectedByNameAndTown { get; private set; }

        public IEnumerable<Entry> SearchByName(string name)
        {
            var output = new List<Entry>();

            foreach (var item in SelectedByName)
            {
                if (item.Key.Contains(name))
                {
                    output.AddRange(item.Value);
                }
            }

            return output;
        }

        public IEnumerable<Entry> SearchByNameAndTown(string name, string town)
        {
            var output = new List<Entry>();

            foreach (var item in SelectedByNameAndTown)
            {
                if (item.Key.Item1.Contains(name) && item.Key.Item2 == town)
                {
                    output.AddRange(item.Value);
                }
            }

            return output;
        }

        public void ReadAndFillEntries(string path)
        {
            using (var reader = new StreamReader(path))
            {
                string inputLine = "";

                while ((inputLine = reader.ReadLine()) != null)
                {
                    var entryInfo = inputLine
                        .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToArray();

                    var entry = new Entry(
                        entryInfo[0], entryInfo[1], entryInfo[2]
                        );

                    this.SelectedByName.Add(entry.Name, entry);
                    this.SelectedByNameAndTown.Add(
                        new Tuple<string,string>(entry.Name, entry.Town), entry
                        );
                }
            }
        }
    }
}
