namespace Minesweeper
{
    public class GameUI
    {
        private static void Main()
        {
            var engine = new Engine();
            engine.ReadAndExecuteCommands();
        }
    }
}
