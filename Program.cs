namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int BANKRUPTCY_CASH_LEVEL = 0;
            const int CELL_VALUE_LOWER_BOUND_INCLUSIVE = 0;
            const int CELL_VALUE_UPPER_BOUND_EXCLUSIVE = 2;
            const string CENTER_LINE_MODE = "cl";
            const string DIAGONALS_MODE = "d";
            const string ALL_HORIZONTAL_MODE = "ah";
            const string ALL_VERTICAL_MODE = "av";
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
            Random rng = new Random();
            Console.WriteLine("The game starts now.You have $50 cash at start.\n--------------------------------------------------");
            while (cash > BANKRUPTCY_CASH_LEVEL)
            {
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
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
                cash -= 3;
                mode = Console.ReadLine().ToLower();
                if (mode == CENTER_LINE_MODE)
                {
                    centerLineWon = true;
                    for (int i = 1; i < gridSize; i++)
                    {
                        if (grid[centerLinePosition, 0] != grid[centerLinePosition, i])
                        {
                            centerLineWon = false;
                            break;
                        }
                    }
                    if (centerLineWon)
                    {
                        cash++;
                    }

                }
                if (mode == DIAGONALS_MODE)
                {
                    for (int i = 1; i < gridSize; i++)
                    {
                        if (grid[0, 0] != grid[i, i])
                        {
                            winningDiagonals[0] = false;
                        }
                        if (grid[gridSize-1, 0] != grid[gridSize-i-1, i])
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
                if (mode == ALL_HORIZONTAL_MODE)
                {
                    for (int i = 0; i < gridSize; i++)
                    {
                        for (int j = 0; j < gridSize; j++)
                        {
                            if (grid[i, 0] != grid[i, j])
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
                if (mode == ALL_VERTICAL_MODE)
                {
                    for (int i = 0; i < gridSize; i++)
                    {
                        for (int j = 0; j < gridSize; j++)
                        {
                            if (grid[0, i] != grid[j, i])
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
