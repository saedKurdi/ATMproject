namespace ATMconsoleProject;
internal static class OtherFunctions
{

    public static int Menu(string[] elementsToShow)
    {
        int count = 0;
        while (true)
        {
            Console.Clear();
            if (count == -1) count = elementsToShow.Length - 1; if (count == elementsToShow.Length) count = 0;
            for (int i = 0; i < elementsToShow.Length; i++)
            {

                Console.ForegroundColor = ConsoleColor.White;
                if (i == count)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\t\t\t\t{elementsToShow[i]} ");
                    Console.WriteLine();
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"\t\t\t\t{elementsToShow[i]} ");
                    Console.WriteLine();

                }
            }
            var result = Console.ReadKey();
            if (result.Key == ConsoleKey.Enter) return count;

            switch (result.Key)
            {
                case ConsoleKey.UpArrow:
                    count--;
                    break;
                case ConsoleKey.DownArrow:
                    count++;
                    break;

            }
        }

    }

}
