using System;

namespace Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 35;
            Console.WindowWidth = 105;


            /*Console.WriteLine(".____          ___.                 .__        __  .__     ");
            Console.WriteLine("|    |   _____ \\_ |__ ___.__._______|__| _____/  |_|  |__  ");
            Console.WriteLine("|    |   \\__  \\ | __ <   |  |\\_  __ \\  |/    \\   __\\  |  \\ ");
            Console.WriteLine("|    |___ / __ \\| \\_\\ \\___  | |  | \\/  |   |  \\  | |   Y  \\");
            Console.WriteLine("|_______ (____  /___  / ____| |__|  |__|___|  /__| |___|  /");
            Console.WriteLine("        \\/    \\/    \\/\\/                    \\/          \\/ ");
            Console.WriteLine("  _           _                _       _   _     ");
            Console.WriteLine(" | |         | |              (_)     | | | |    ");
            Console.WriteLine(" | |     __ _| |__  _   _ _ __ _ _ __ | |_| |__  ");
            Console.WriteLine(" | |    / _` | '_ \\| | | | '__| | '_ \\| __| '_ \\ ");
            Console.WriteLine(" | |___| (_| | |_) | |_| | |  | | | | | |_| | | |");
            Console.WriteLine(" |______\\__,_|_.__/ \\__, |_|  |_|_| |_|\\__|_| |_|");
            Console.WriteLine("                     __/ |                       ");
            Console.WriteLine("                    |___/                        ");*/
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 9);
            Console.WriteLine(" __                  __                            __              __      __       ");
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("/  |                /  |                          /  |            /  |    /  |      ");
            Console.SetCursorPosition(10, 11);
            Console.WriteLine("$$ |        ______  $$ |____   __    __   ______  $$/  _______   _$$ |_   $$ |____  ");
            Console.SetCursorPosition(10, 12);
            Console.WriteLine("$$ |       /      \\ $$      \\ /  |  /  | /      \\ /  |/       \\ / $$   |  $$      \\ ");
            Console.SetCursorPosition(10, 13);
            Console.WriteLine("$$ |       $$$$$$  |$$$$$$$  |$$ |  $$ |/$$$$$$  |$$ |$$$$$$$  |$$$$$$/   $$$$$$$  |");
            Console.SetCursorPosition(10, 14);
            Console.WriteLine("$$ |       /    $$ |$$ |  $$ |$$ |  $$ |$$ |  $$/ $$ |$$ |  $$ |  $$ | __ $$ |  $$ |");
            Console.SetCursorPosition(10, 15);
            Console.WriteLine("$$ |_____ /$$$$$$$ |$$ |__$$ |$$ \\__$$ |$$ |      $$ |$$ |  $$ |  $$ |/  |$$ |  $$ |");
            Console.SetCursorPosition(10, 16);
            Console.WriteLine("$$       |$$    $$ |$$    $$/ $$    $$ |$$ |      $$ |$$ |  $$ |  $$  $$/ $$ |  $$ |");
            Console.SetCursorPosition(10, 17);
            Console.WriteLine("$$$$$$$$/  $$$$$$$/ $$$$$$$/   $$$$$$$ |$$/       $$/ $$/   $$/    $$$$/  $$/   $$/ ");
            Console.SetCursorPosition(10, 18);
            Console.WriteLine("                              /  \\__$$ |                                            ");
            Console.SetCursorPosition(10, 19);
            Console.WriteLine("                              $$    $$/                                             ");
            Console.SetCursorPosition(10, 20);
            Console.WriteLine("                               $$$$$$/                                              ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(26, 22);
            Console.WriteLine("> EGYJÁTÉKOS MÓD <       TÖBBJÁTÉKOS MÓD");
            string mode = "egyjatekos";
            while (true)
            {
                char bill = Console.ReadKey(true).KeyChar;
                if (bill == 'a' || bill == 'd' || bill == (char)ConsoleKey.Enter)
                {
                    if (bill == 'a')
                    {
                        Console.SetCursorPosition(26, 22);
                        Console.WriteLine("> EGYJÁTÉKOS MÓD <       TÖBBJÁTÉKOS MÓD  ");
                        mode = "egyjatekos";
                    }
                    else if (bill == 'd')
                    {
                        Console.SetCursorPosition(26, 22);
                        Console.WriteLine("  EGYJÁTÉKOS MÓD       > TÖBBJÁTÉKOS MÓD <");
                        mode = "tobbjatekos";
                    }
                    else if (bill == (char)ConsoleKey.Enter)
                    {
                        break;
                    }

                }
            }
        }
    }
}
