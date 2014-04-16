namespace Phonebook
{
    using System;
    
    class Entry
    {
        public Entry(string name, string town, string number)
        {
            this.Name = name;
            this.Town = town;
            this.Number = number;
        }

        public string Name { get; private set; }
        public string Town { get; private set; }
        public string Number { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} | {1} | {2}", this.Name, this.Town, this.Number);
        }
    }
}
