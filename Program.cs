using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Linq.Expressions;

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
            Console.Clear();
            Console.CursorVisible = false;
            TextReader tr = new StreamReader("../../../lang.txt");
            string language = tr.ReadLine();
            tr.Close();
            if (language == "hu")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(45, 14);
                Console.WriteLine("Válassz játékmódot!");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(50, 16);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Idő mód");
                Console.SetCursorPosition(49, 17);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Vaktérkép");
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
                                Console.SetCursorPosition(50, 16);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Idő mód");
                                Console.SetCursorPosition(49, 17);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("Vaktérkép");
                            }
                            else if (selected == 2)
                            {
                                selected = 1;
                                Console.SetCursorPosition(50, 16);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("Idő mód");
                                Console.SetCursorPosition(49, 17);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Vaktérkép");
                            }

                        }

                        else if (bill == (char)ConsoleKey.Enter)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            singleplayer_palya_valaszto(selected);
                            break;
                        }

                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(47, 14);
                Console.WriteLine("Choose game mode!");
                Console.BackgroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(51, 16);
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Time mode");
                Console.SetCursorPosition(48, 17);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Blind map mode");
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
                                Console.SetCursorPosition(51, 16);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Time mode");
                                Console.SetCursorPosition(48, 17);
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("Blind map mode");
                            }
                            else if (selected == 2)
                            {
                                selected = 1;
                                Console.SetCursorPosition(51, 16);
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("Time mode");
                                Console.SetCursorPosition(48, 17);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Blind map mode");
                            }

                        }

                        else if (bill == (char)ConsoleKey.Enter)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            singleplayer_palya_valaszto(selected);
                            break;
                        }

                    }
                }
            }
            static void singleplayer_palya_valaszto(int mode)
            {
                Console.Clear();
                Console.CursorVisible = true;
                TextReader tr = new StreamReader("../../../lang.txt");
                string language = tr.ReadLine();
                tr.Close();
                bool olvasas_sikreres = true;
                string[] palya_listaban = { };
                if (mode == 1)
                {
                    if (language == "hu")
                    {
                        Console.SetCursorPosition(42, 15);
                        Console.WriteLine("Add meg a pálya nevét:");
                        do
                        {
                            Console.SetCursorPosition(42, 16);
                            string palya_nev = Console.ReadLine();
                            try
                            {
                                palya_listaban = File.ReadAllLines("../../../" + palya_nev);
                                olvasas_sikreres = false;
                            }
                            catch
                            {
                                Console.SetCursorPosition(37, 17);
                                Console.WriteLine("(!) Létező pályanevet adj meg!");
                                Console.SetCursorPosition(42, 16);
                                Console.WriteLine("                 ");
                            }
                        } while (olvasas_sikreres);
                    }
                    else
                    {
                        Console.SetCursorPosition(42, 15);
                        Console.WriteLine("Enter the level name:");
                        Console.SetCursorPosition(42, 16);
                        do
                        {
                            Console.SetCursorPosition(42, 16);
                            string palya_nev = Console.ReadLine();
                            try
                            {
                                palya_listaban = File.ReadAllLines("../../../" + palya_nev);
                                olvasas_sikreres = false;
                            }
                            catch
                            {
                                Console.SetCursorPosition(35, 17);
                                Console.WriteLine("(!) Enter an existing level name!");
                                Console.SetCursorPosition(42, 16);
                                Console.WriteLine("                 ");
                            }
                        } while (olvasas_sikreres);
                    }
                    palya_betoltese(palya_listaban);
                }
                else if (mode == 2)
                {
                    Console.WriteLine("vak");
                }
            }
            static void palya_betoltese(string[] palya_listaban)
            {
                Console.Clear();
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Magenta;
                int sorok = 0;
                int oszlopok = 0;
                foreach (string sor in palya_listaban)
                {
                    oszlopok++;
                }
                foreach (char karakter in palya_listaban[0])
                {
                    sorok++;
                }
                Console.WindowHeight = oszlopok + 10;
                Console.WindowWidth = sorok + 10;
                char[,] game_level = new char[oszlopok, sorok];
                for (int sor_index = 0; sor_index < sorok - 1; sor_index++)
                {
                    for (int oszlop_index = 0; oszlop_index < oszlopok - 1; oszlop_index++)
                    {
                        if (palya_listaban[oszlop_index][sor_index] == '.')
                        {
                            game_level[oszlop_index, sor_index] = ' ';
                        }
                        else
                        {
                            game_level[oszlop_index, sor_index] = palya_listaban[oszlop_index][sor_index];
                        }
                    }
                }

                int kozepre_oszlop = 5;
                int kozepre_sor = 7;
                for (int i7 = 0; i7 < oszlopok; i7++)
                {
                    string sor = "";
                    for (int i8 = 0; i8 < sorok; i8++)
                    {
                        sor += game_level[i7, i8];
                    }
                    Console.SetCursorPosition(kozepre_oszlop, kozepre_sor);
                    Console.WriteLine(sor);
                    kozepre_sor++;
                }

                while (true)
                {

                }
            }
        }
        static void multiplayer()
        {

        }
        static void languagemenu()
        {
            Console.Clear();
            Console.CursorVisible = false;
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
                            Console.ForegroundColor = ConsoleColor.Red;
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        }

                    }
                }
            }
            menu();


        }
    }
}
