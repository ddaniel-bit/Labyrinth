using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace Labyrinth
{
    class Program
    {
        static void menu()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WindowHeight = 35;
            Console.WindowWidth = 105;
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
            TextReader tr = new StreamReader("../../../lang.txt");
            string language = tr.ReadLine();
            tr.Close();
            if (language == "hu")
            {
                Console.SetCursorPosition(26, 22);
                Console.WriteLine("> EGYJÁTÉKOS MÓD <       TÖBBJÁTÉKOS MÓD");
                Console.SetCursorPosition(38, 24);
                Console.WriteLine("  NYELVVÁLASZTÁS (HU)");
                int op = 1;
                while (true)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == (char)ConsoleKey.Enter || bill == (char)ConsoleKey.Tab)
                    {
                        if (bill == (char)ConsoleKey.Tab)
                        {
                            if (op == 1)
                            {
                                Console.SetCursorPosition(26, 22);
                                Console.WriteLine("  EGYJÁTÉKOS MÓD       > TÖBBJÁTÉKOS MÓD <");
                                Console.SetCursorPosition(38, 24);
                                Console.WriteLine("  NYELVVÁLASZTÁS (HU)  ");
                                op = 2;
                            }
                            else if (op == 2)
                            {
                                Console.SetCursorPosition(26, 22);
                                Console.WriteLine("  EGYJÁTÉKOS MÓD         TÖBBJÁTÉKOS MÓD  ");
                                Console.SetCursorPosition(38, 24);
                                Console.WriteLine("> NYELVVÁLASZTÁS (HU) <");
                                op = 3;
                            }
                            else if (op == 3)
                            {
                                Console.SetCursorPosition(26, 22);
                                Console.WriteLine("> EGYJÁTÉKOS MÓD <       TÖBBJÁTÉKOS MÓD  ");
                                Console.SetCursorPosition(38, 24);
                                Console.WriteLine("  NYELVVÁLASZTÁS (HU)  ");
                                op = 1;
                            }

                        }

                        else if (bill == (char)ConsoleKey.Enter)
                        {
                            if (op == 1)
                            {
                                singleplayer();
                            }
                            else if (op == 2)
                            {
                                multiplayer();
                            }
                            else if (op == 3)
                            {
                                languagemenu();
                            }
                            break;

                        }

                    }
                }
            }
            else
            {
                Console.SetCursorPosition(32, 22);
                Console.WriteLine("> SINGLEPLAYER <       MULTIPLAYER");
                Console.SetCursorPosition(39, 24);
                Console.WriteLine("  CHOOSE LANGUAGE (EN)");
                int op = 1;
                while (true)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == (char)ConsoleKey.Enter || bill == (char)ConsoleKey.Tab)
                    {
                        if (bill == (char)ConsoleKey.Tab)
                        {
                            if (op == 1)
                            {
                                Console.SetCursorPosition(32, 22);
                                Console.WriteLine("  SINGLEPLAYER       > MULTIPLAYER <");
                                Console.SetCursorPosition(39, 24);
                                Console.WriteLine("  CHOOSE LANGUAGE (EN)  ");
                                op = 2;
                            }
                            else if (op == 2)
                            {
                                Console.SetCursorPosition(32, 22);
                                Console.WriteLine("  SINGLEPLAYER         MULTIPLAYER  ");
                                Console.SetCursorPosition(39, 24);
                                Console.WriteLine("> CHOOSE LANGUAGE (EN) <");
                                op = 3;
                            }
                            else if (op == 3)
                            {
                                Console.SetCursorPosition(32, 22);
                                Console.WriteLine("> SINGLEPLAYER <       MULTIPLAYER");
                                Console.SetCursorPosition(39, 24);
                                Console.WriteLine("  CHOOSE LANGUAGE (EN)  ");
                                op = 1;
                            }

                        }

                        else if (bill == (char)ConsoleKey.Enter)
                        {
                            if (op == 1)
                            {
                                singleplayer();
                            }
                            else if (op == 2)
                            {
                                multiplayer();
                            }
                            else if (op == 3)
                            {
                                languagemenu();
                            }
                            break;

                        }

                    }
                }
            }
        }
        static void Main(string[] args)
        {
            menu();
        }
        static void singleplayer()
        {

        }
        static void multiplayer()
        {

        }
        static void languagemenu()
        {
            Console.Clear();
            TextReader tr = new StreamReader("../../../lang.txt");
            string language = tr.ReadLine();
            tr.Close();
            if (language == "hu")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(40, 14);
                Console.WriteLine("Válaszd ki a játék nyelvét!");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(48, 16);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Magyar (HU)");
                Console.SetCursorPosition(48, 17);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Angol (EN)");
                int selected = 1;
                while (true)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == (char)ConsoleKey.Enter || bill == (char)ConsoleKey.Tab)
                    {
                        if (bill == (char)ConsoleKey.Tab)
                        {
                            if (selected == 1)
                            {
                                selected = 2;
                                Console.SetCursorPosition(48, 16);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Magyar (HU)");
                                Console.SetCursorPosition(48, 17);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("Angol (EN)");
                            }
                            else if (selected == 2)
                            {
                                selected = 1;
                                Console.SetCursorPosition(48, 16);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("Magyar (HU)");
                                Console.SetCursorPosition(48, 17);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Angol (EN)");
                            }

                        }

                        else if (bill == (char)ConsoleKey.Enter)
                        {
                            if (selected == 1)
                            {
                                using (StreamWriter writer = File.CreateText("../../../lang.txt"))
                                {
                                    writer.WriteLineAsync("hu");
                                    writer.Close();
                                }
                            }
                            else if (selected == 2)
                            {
                                using (StreamWriter writer = File.CreateText("../../../lang.txt"))
                                {
                                    writer.WriteLineAsync("en");
                                    writer.Close();
                                }
                            }
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;

                        }

                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(42, 14);
                Console.WriteLine("Choose the game language!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(47, 16);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Hungarian (HU)");
                Console.SetCursorPosition(48, 17);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("English (EN)");
                int selected = 2;
                while (true)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == (char)ConsoleKey.Enter || bill == (char)ConsoleKey.Tab)
                    {
                        if (bill == (char)ConsoleKey.Tab)
                        {
                            if (selected == 1)
                            {
                                selected = 2;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.SetCursorPosition(47, 16);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Hungarian (HU)");
                                Console.SetCursorPosition(48, 17);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("English (EN)");
                            }
                            else if (selected == 2)
                            {
                                selected = 1;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(47, 16);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("Hungarian (HU)");
                                Console.SetCursorPosition(48, 17);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("English (EN)");
                            }

                        }

                        else if (bill == (char)ConsoleKey.Enter)
                        {
                            if (selected == 1)
                            {
                                using (StreamWriter writer = File.CreateText("../../../lang.txt"))
                                {
                                    writer.WriteLineAsync("hu");
                                    writer.Close();
                                }
                            }
                            else if (selected == 2)
                            {
                                using (StreamWriter writer = File.CreateText("../../../lang.txt"))
                                {
                                    writer.WriteLineAsync("en");
                                    writer.Close();
                                }
                            }
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                        }

                    }
                }
            }
            menu();


        }
    }
}
