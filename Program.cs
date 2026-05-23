namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int gridSize;
            string gridSizeUserInput;
            Console.WriteLine("You can choose the size of the grid for the slot machine. How large should the grid be?");
            gridSizeUserInput = Console.ReadLine();
            gridSize = Convert.ToInt32(gridSizeUserInput);
            string[,] grid = new string[gridSize,gridSize];
            Console.WriteLine("The game starts now.You have $50 cash at start.\n--------------------------------------------------");
            Console.WriteLine("Choose a mode.(center line / all horizontal lines / all vertical lines / all diagonal lines");


        }
    }
}
