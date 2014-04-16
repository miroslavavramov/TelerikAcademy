namespace Phonebook
{
    using System;
    
    class Program
    {
        static void Main()
        {
            var pb = new Phonebook();
            pb.ReadAndFillEntries(@"../../phones.txt");

            var engine = CommandExecutor.GetInstance();
            engine.ReadAndExecute(@"../../commands.txt", pb);
        }
    }
}
