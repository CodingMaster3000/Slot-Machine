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
            int lineComboValue;
            int amountOfCenterLineCoordinates;
            int amountOfAllHorizontalCoordinates;
            int amountOfAllVerticalCoordinates;
            int amountOfAlldiagnoalsCoordniates;
            string gridSizeUserInput;
            string mode;
            bool lineWon;
            Console.WriteLine("You can choose the size of the grid for the slot machine. How large should the grid be?");
            gridSizeUserInput = Console.ReadLine();
            gridSize = Convert.ToInt32(gridSizeUserInput);
            amountOfCenterLineCoordinates = gridSize * 2;
            amountOfAllHorizontalCoordinates = gridSize * gridSize * 2;
            amountOfAllVerticalCoordinates = gridSize * gridSize * 2;
            amountOfAlldiagnoalsCoordniates = gridSize * 2 * 2;
            centerLinePosition = gridSize / 2;
            string[] centerLine = new string[amountOfCenterLineCoordinates];
            string[] allHorizontal = new string[amountOfAllHorizontalCoordinates];
            string[] allVertical = new string[amountOfAllVerticalCoordinates];
            string[] diagonals = new string[amountOfAlldiagnoalsCoordniates];
            for (int i = 0; i < gridSize; i++)
            {
                centerLine[i * 2] = i.ToString();
                centerLine[i * 2 + 1] = centerLinePosition.ToString();
                for (int j = 0; j < gridSize; j++)
                {
                    allHorizontal[(i*gridSize + j)*2] = j.ToString();
                    allHorizontal[(i * gridSize + j) * 2+1] = i.ToString();
                    allVertical[(i * gridSize + j) * 2] = i.ToString();
                    allVertical[(i * gridSize + j) * 2 + 1] = j.ToString();

                }
                diagonals[i] = i.ToString();
                diagonals[i+1] = i.ToString();
                diagonals[gridSize*2-i*2] = i.ToString();
                diagonals[i*2 + 1] = i.ToString();
            }
            string[,] grid = new string[gridSize, gridSize];
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
                Console.WriteLine("Choose a mode.(center line / all horizontal lines / all vertical lines / all diagonal lines");
                mode = Console.ReadLine().ToLower();
                if (mode == "center line")
                {
                    lineWon = true;
                    lineComboValue = Convert.ToInt32(grid[centerLinePosition, 0]);
                    for (int i = 1; i < gridSize; i++)
                    {
                        if (Convert.ToInt32(grid[centerLinePosition, 0]) != Convert.ToInt32(grid[centerLinePosition, i]))
                        {
                            lineWon = false;
                        }
                    }
                    if (lineWon == true)
                    {
                        cash++;
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
