namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int BANKRUPTCY_CASH_LEVEL = 0;
            int gridSize;
            int cash = 50;
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
                mode = Console.ReadLine();
            }

        }
    }
}
