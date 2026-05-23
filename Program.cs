namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int BANKRUPTCY_CASH_LEVEL = 0;
            const int CELL_VALUE_LOWER_BOUND_INCLUSIVE = 0;
            const int CELL_VALUE_UPPER_BOUND_EXCLUSIVE = 2;
            int gridSize;
            int cash = 50;
            int randomCellValue;
            string gridSizeUserInput;
            string mode;
            Console.WriteLine("You can choose the size of the grid for the slot machine. How large should the grid be?");
            gridSizeUserInput = Console.ReadLine();
            gridSize = Convert.ToInt32(gridSizeUserInput);
            string[,] grid = new string[gridSize,gridSize];
            Console.WriteLine("The game starts now.You have $50 cash at start.\n--------------------------------------------------");
            while (cash > BANKRUPTCY_CASH_LEVEL)
            {
                Console.WriteLine("Choose a mode.(center line / all horizontal lines / all vertical lines / all diagonal lines");
                mode = Console.ReadLine().ToLower();
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        Random rng = new Random();
                        randomCellValue = rng.Next(CELL_VALUE_LOWER_BOUND_INCLUSIVE, CELL_VALUE_UPPER_BOUND_EXCLUSIVE);
                        grid[i,j] = randomCellValue.ToString();
                        Console.Write($"{grid[i, j]}");
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

            }

        }
    }
}
