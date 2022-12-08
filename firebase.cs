internal class Program
{
    private static void Main(string[] args)
    {
        Console.WindowWidth = 50;
        Console.WindowHeight = 30;
        static void Feltoltes()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                for (int i2 = 0; i2 < Console.WindowHeight; i2++)
                {
                    Console.SetCursorPosition(i, i2);
                    Console.WriteLine('o');
                }
            }
        }
        Feltoltes();
        int xPos = Console.WindowWidth / 2;
        int yPos = Console.WindowHeight / 2;
        Console.SetCursorPosition(xPos, yPos);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write('X');
        char valasz = 'O';
        while (true)
        {
            valasz = Console.ReadKey(true).KeyChar;
            if (valasz == 'w' || valasz == 's' || valasz == 'a'
            || valasz == 'd')
            {
                switch (valasz)
                {
                    case 'w':
                        yPos--;
                        Console.SetCursorPosition(xPos, yPos);
                        Console.Write('X');
                        break;
                    case 's':
                        yPos++;
                        Console.SetCursorPosition(xPos, yPos);
                        Console.Write('X');
                        break;
                    case 'a':
                        xPos--;
                        Console.SetCursorPosition(xPos, yPos);
                        Console.Write('X');
                        break;
                    case 'd':
                        xPos++;
                        Console.SetCursorPosition(xPos, yPos);
                        Console.Write('X');
                        break;
                }

            }

        }
    }
}