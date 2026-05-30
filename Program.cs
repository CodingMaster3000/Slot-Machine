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
            int centerLinePosition;

            string gridSizeUserInput;
            string mode;
            bool centerLineWon;
            Console.WriteLine("You can choose the size of the grid for the slot machine. How large should the grid be?");
            gridSizeUserInput = Console.ReadLine();
            gridSize = Convert.ToInt32(gridSizeUserInput);
            centerLinePosition = gridSize / 2;
            string[,] grid = new string[gridSize, gridSize];
            bool[] winningLines = new bool[gridSize];
            bool[] winningDiagonals = new bool[2];
            Console.WriteLine("The game starts now.You have $50 cash at start.\n--------------------------------------------------");
            while (cash > BANKRUPTCY_CASH_LEVEL)
            {
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        Random rng = new Random();
                        randomCellValue = rng.Next(CELL_VALUE_LOWER_BOUND_INCLUSIVE, CELL_VALUE_UPPER_BOUND_EXCLUSIVE);
                        grid[i, j] = randomCellValue.ToString();
                    }
                }
                for (int i = 0; i < gridSize; i++)
                {
                    winningLines[i] = true;

                }
                winningDiagonals[0] = true;
                winningDiagonals[1] = true;
                centerLineWon = true;
                Console.WriteLine("Choose a mode.(center line / all horizontal lines / all vertical lines / all diagonal lines");
                mode = Console.ReadLine().ToLower();
                if (mode == "cl")
                {
                    centerLineWon = true;
                    for (int i = 1; i < gridSize; i++)
                    {
                        if (Convert.ToInt32(grid[centerLinePosition, 0]) != Convert.ToInt32(grid[centerLinePosition, i]))
                        {
                            centerLineWon = false;
                            break;
                        }
                    }
                    if (centerLineWon == true)
                    {
                        cash++;
                    }
                }
                if (mode == "d")
                {
                    for (int i = 1; i < gridSize; i++)
                    {
                        if (Convert.ToInt32(grid[0, 0]) != Convert.ToInt32(grid[i, i]))
                        {
                            winningDiagonals[0] = false;
                        }
                        if (Convert.ToInt32(grid[gridSize-1, 0]) != Convert.ToInt32(grid[gridSize-i-1, i]))
                        {
                            winningDiagonals[1] = false;
                        }
                        if (winningDiagonals[0] == false && winningDiagonals[1] == false)
                        {
                            break;
                        }
                    }
                    foreach (bool i in winningDiagonals)
                    {
                        if (i)
                        {
                            cash++;
                        }
                    }
                }
                if (mode == "ah")
                {
                    for (int i = 0; i < gridSize; i++)
                    {
                        for (int j = 0; j < gridSize; j++)
                        {
                            if (Convert.ToInt32(grid[0, i]) != Convert.ToInt32(grid[j, i]))
                            {
                                winningLines[i] = false;
                                break;
                            }
                        }
                    }
                    foreach (bool i in winningLines)
                    {
                        if (i)
                        {
                            cash++;
                        }
                    }
                }
                if (mode == "av")
                {
                    for (int i = 0; i < gridSize; i++)
                    {
                        for (int j = 0; j < gridSize; j++)
                        {
                            if (Convert.ToInt32(grid[i, 0]) != Convert.ToInt32(grid[i, j]))
                            {
                                winningLines[i] = false;
                                break;
                            }
                        }
                    }
                    foreach (bool i in winningLines)
                    {
                        if (i)
                        {
                            cash++;
                        }
                    }
                }
                for (int i = 0; i < gridSize; i++)
                {
                    Console.Write("+");
                    for (int j = 0; j < gridSize; j++)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            Console.Write("-");
                        }
                        Console.Write("+");
                    }
                    Console.WriteLine();
                    for (int j = 0; j < gridSize; j++)
                    {
                        Console.Write("|");
                        Console.Write(" ");
                        Console.Write($"{grid[i, j]}");
                        Console.Write(" ");
                    }
                    Console.WriteLine("|");
                }
                Console.Write("+");
                for (int j = 0; j < gridSize; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.Write("-");
                    }
                    Console.Write("+");
                }
                Console.WriteLine();
                Console.WriteLine($"{cash}");
            }
        }
    }
}
