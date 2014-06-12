class Program
{
    static void Main()
    {
        //First statement
        Potato potato = new Potato();
        //... 
        if (potato != null)
        {
            if (potato.IsFresh && potato.IsPeeled)
            {
                //Cook(potato);
            }
        }

        //Second statement

        int[,] grid = new int[,];
        bool[,] visited = new bool[,];

        int currentRow = 0; 
        int startRow = 0;
        int endRow = grid.GetLength(0) - 1;

        int currentColumn = 0;
        int startColumn = 0;
        int endColumn = grid.GetLength(1) - 1;

        bool isInGrid = (currentRow >= startRow && currentRow <= endRow) && 
            (currentColumn >= startColumn && currentColumn <= endColumn);

        bool isVisited = !visited[currentRow, currentColumn];

        if (isInGrid && !isVisited)
        {
           //VisitCell();
        }
    }
}