namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class CommandExecutor
    {
        private readonly string[] separators = new string[] { "(", ")", "," };

        private static CommandExecutor instance;
            
        private CommandExecutor()
        {
        }

        public static CommandExecutor GetInstance()
        {
            if (instance == null)
            {
                instance = new CommandExecutor();
            }
            return instance;
        }

        public void ReadAndExecute(string filePath, Phonebook phonebook)
        {
            using (var reader = new StreamReader(filePath))
            {
                string inputLine = "";

                while ((inputLine = reader.ReadLine()) != null)
                {
                    var commandWords = inputLine.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    var command = commandWords[0].ToLower();

                    switch (command)
                    {
                        case "find":
                            ExecuteFindCommand(
                                commandWords.Skip(1).Select(x => x.Trim()).ToArray()
                                ,phonebook
                                );
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void ExecuteFindCommand(IList<string> args, Phonebook pb)
        {
            Console.WriteLine("Searching for: {0} ...", string.Join(", ", args));

            IEnumerable<Entry> entriesFound;

            if (args.Count() == 1)
            {
                string name = args[0];
                
                entriesFound = pb.SearchByName(name);
            }
            else
            {
                string name = args[0];
                string town = args[1];

                entriesFound = pb.SearchByNameAndTown(name, town);
            }

            if (entriesFound.Count() > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, entriesFound));
            }
            else
            {
                Console.WriteLine("Entry not found");
            }
        }
    }
}
