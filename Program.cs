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
        //Global variables
        private static int remaring_time = 30;
        private static int lepesek = -1;
        private static int felfedezett_szobak = 0;

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
                for (int sor_index = 0; sor_index < sorok; sor_index++)
                {
                    for (int oszlop_index = 0; oszlop_index < oszlopok; oszlop_index++)
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
                Random random = new Random();
                int veletlen = random.Next(0, spawn(game_level, sorok, oszlopok).Item1.Count);
                int yPos = spawn(game_level, sorok, oszlopok).Item1[veletlen];
                int xPos = spawn(game_level, sorok, oszlopok).Item2[veletlen];
                for (int isor = 0; isor < oszlopok; isor++)
                {
                    string sor = "";
                    for (int ioszlop = 0; ioszlop < sorok; ioszlop++)
                    {
                        sor += game_level[isor, ioszlop];
                    }
                    Console.SetCursorPosition(kozepre_oszlop, kozepre_sor);
                    Console.WriteLine(sor);
                    kozepre_sor++;
                }
                Console.WriteLine(spawn(game_level, sorok, oszlopok).Item1[0] + "," + spawn(game_level, sorok, oszlopok).Item2[0]);
                singlepalyer_game(game_level, xPos, yPos, oszlopok, sorok);
            }
            static void singlepalyer_game(char[,] palya_matrix, int xPos, int yPos, int oszlopok, int sorok)
            {
                Console.SetCursorPosition(0, 0);
                Console.SetCursorPosition(xPos + 5, yPos + 7);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(palya_matrix[yPos, xPos]);
                steps_update();
                var rooms = new Dictionary<string, bool>();
                room_search(palya_matrix, rooms, oszlopok, sorok);
                var idozito = new Timer(stopperora, null, 0, 1000);
                while (Program.remaring_time > 0)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == 'w' || bill == 'a' || bill == 's' || bill == 'd')
                    {
                        if (bill == 'w' && yPos != 0 && mozgas_iranya(palya_matrix[yPos, xPos]).Contains('W') && mozgas_iranya(palya_matrix[yPos - 1, xPos]).Contains('S') && mezo_ellenorzes(palya_matrix[yPos - 1, xPos], true) && Program.remaring_time > 0)
                        {
                            Console.SetCursorPosition(xPos + 5, yPos + 7);
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(palya_matrix[yPos, xPos]);
                            yPos--;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(xPos + 5, yPos + 7);
                            Console.WriteLine(palya_matrix[yPos, xPos]);
                            room_check(palya_matrix, rooms, xPos, yPos);
                            steps_update();
                        }
                        if (bill == 'a' && xPos != 0 && mozgas_iranya(palya_matrix[yPos, xPos]).Contains('A') && mozgas_iranya(palya_matrix[yPos, xPos - 1]).Contains('D') && mezo_ellenorzes(palya_matrix[yPos, xPos - 1], true) && Program.remaring_time > 0)
                        {
                            Console.SetCursorPosition(xPos + 5, yPos + 7);
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(palya_matrix[yPos, xPos]);
                            xPos--;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(xPos + 5, yPos + 7);
                            Console.WriteLine(palya_matrix[yPos, xPos]);
                            room_check(palya_matrix, rooms, xPos, yPos);
                            steps_update();
                        }
                        if (bill == 's' && yPos != oszlopok - 1 && mozgas_iranya(palya_matrix[yPos, xPos]).Contains('S') && mozgas_iranya(palya_matrix[yPos + 1, xPos]).Contains('W') && mezo_ellenorzes(palya_matrix[yPos + 1, xPos], true) && Program.remaring_time > 0)
                        {
                            Console.SetCursorPosition(xPos + 5, yPos + 7);
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(palya_matrix[yPos, xPos]);
                            yPos++;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(xPos + 5, yPos + 7);
                            Console.WriteLine(palya_matrix[yPos, xPos]);
                            room_check(palya_matrix, rooms, xPos, yPos);
                            steps_update();
                        }
                        if (bill == 'd' && xPos != sorok - 1 && mozgas_iranya(palya_matrix[yPos, xPos]).Contains('D') && mozgas_iranya(palya_matrix[yPos, xPos + 1]).Contains('A') && mezo_ellenorzes(palya_matrix[yPos, xPos + 1], true) && Program.remaring_time > 0)
                        {
                            Console.SetCursorPosition(xPos + 5, yPos + 7);
                            Console.BackgroundColor = ConsoleColor.Magenta;
                            Console.WriteLine(palya_matrix[yPos, xPos]);
                            xPos++;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.SetCursorPosition(xPos + 5, yPos + 7);
                            Console.WriteLine(palya_matrix[yPos, xPos]);
                            room_check(palya_matrix, rooms, xPos, yPos);
                            steps_update();
                        }

                    }
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
        static string mozgas_iranya(char mezo)
        {
            string iranyok = "";
            if (mezo == '╬')
            {
                iranyok = "WASD";
            }
            else if (mezo == '═')
            {
                iranyok = "AD";
            }
            else if (mezo == '╦')
            {
                iranyok = "ASD";
            }
            else if (mezo == '╩')
            {
                iranyok = "WAD";
            }
            else if (mezo == '║')
            {
                iranyok = "WS";
            }
            else if (mezo == '╣')
            {
                iranyok = "WAS";
            }
            else if (mezo == '╠')
            {
                iranyok = "WSD";
            }
            else if (mezo == '╗')
            {
                iranyok = "AS";
            }
            else if (mezo == '╝')
            {
                iranyok = "WA";
            }
            else if (mezo == '╚')
            {
                iranyok = "WD";
            }
            else if (mezo == '╔')
            {
                iranyok = "SD";
            }
            else if (mezo == '█')
            {
                iranyok = "WASD";
            }
            return iranyok;
        }
        static bool mezo_ellenorzes(char mezo, bool room)
        {
            bool valos = false;
            if (mezo == '╬')
            {
                valos = true;
            }
            else if (mezo == '═')
            {
                valos = true;
            }
            else if (mezo == '╦')
            {
                valos = true;
            }
            else if (mezo == '╩')
            {
                valos = true;
            }
            else if (mezo == '║')
            {
                valos = true;
            }
            else if (mezo == '╣')
            {
                valos = true;
            }
            else if (mezo == '╠')
            {
                valos = true;
            }
            else if (mezo == '╗')
            {
                valos = true;
            }
            else if (mezo == '╝')
            {
                valos = true;
            }
            else if (mezo == '╚')
            {
                valos = true;
            }
            else if (mezo == '╔')
            {
                valos = true;
            }
            else if (mezo == '█' && room)
            {
                valos = true;
            }
            return valos;
        }
        static Tuple<List<int>, List<int>> spawn(char[,] palya_matrix, int YPOS, int XPOS)
        {
            List<int> kijaratok_lista_sor = new List<int>();
            List<int> kijaratok_lista_oszlop = new List<int>();
            Console.SetCursorPosition(0, 40);
            for (int isor = 0; isor < XPOS - 1; isor++)
            {
                if (palya_matrix[isor, 0] == '═' || palya_matrix[isor, 0] == '╣')
                {
                    kijaratok_lista_sor.Add(isor);
                    kijaratok_lista_oszlop.Add(0);
                }
            }
            for (int isormax = 0; isormax < XPOS - 1; isormax++)
            {
                if (palya_matrix[isormax, YPOS - 1] == '═' || palya_matrix[isormax, YPOS - 1] == '╠')
                {
                    kijaratok_lista_sor.Add(isormax);
                    kijaratok_lista_oszlop.Add(YPOS - 1);
                }
            }
            for (int ioszlop = 0; ioszlop < YPOS - 1; ioszlop++)
            {
                if (palya_matrix[0, ioszlop] == '║' || palya_matrix[0, ioszlop] == '╩')
                {
                    kijaratok_lista_sor.Add(0);
                    kijaratok_lista_oszlop.Add(ioszlop);
                }
            }
            for (int ioszlopmax = 0; ioszlopmax < YPOS - 1; ioszlopmax++)
            {
                if (palya_matrix[XPOS - 1, ioszlopmax] == '║' || palya_matrix[XPOS - 1, ioszlopmax] == '╦')
                {
                    kijaratok_lista_sor.Add(XPOS - 1);
                    kijaratok_lista_oszlop.Add(ioszlopmax);
                }
            }
            return Tuple.Create(kijaratok_lista_sor, kijaratok_lista_oszlop);
        }
        private static void stopperora(object o)
        {
            Console.SetCursorPosition(1, 1);
            if (Program.remaring_time != 0)
            {
                Program.remaring_time -= 1;
            }
            TextReader tr = new StreamReader("../../../lang.txt");
            string language = tr.ReadLine();
            tr.Close();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            if (language == "hu")
            {
                if (Program.remaring_time < 10)
                {
                    Console.Write("Hátralévő idő:  " + Program.remaring_time + " mp");
                }
                else
                {
                    Console.Write("Hátralévő idő: " + Program.remaring_time + " mp");
                }
            }
            else
            {
                if (Program.remaring_time < 10)
                {
                    Console.Write("Remaring time:  " + Program.remaring_time + " mp");
                }
                else
                {
                    Console.Write("Remaring time: " + Program.remaring_time + " mp");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;


        }
        static void steps_update()
        {
            TextReader tr = new StreamReader("../../../lang.txt");
            string language = tr.ReadLine();
            tr.Close();
            Program.lepesek++;
            Console.SetCursorPosition(1, 2);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            if (language == "hu")
            {
                Console.WriteLine("Lépések: " + Program.lepesek);
            }
            else
            {
                Console.WriteLine("Steps: " + Program.lepesek);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void room_search(char[,] palya, Dictionary<string, bool> rooms, int oszlopok, int sorok)
        {
            for (int sor_index = 0; sor_index < sorok; sor_index++)
            {
                for (int oszlop_index = 0; oszlop_index < oszlopok; oszlop_index++)
                {
                    if (palya[oszlop_index, sor_index] == '█')
                    {
                        rooms.Add(oszlop_index + "," + sor_index, false);
                    }
                }
            }
            TextReader tr = new StreamReader("../../../lang.txt");
            string language = tr.ReadLine();
            tr.Close();
            Program.lepesek++;
            Console.SetCursorPosition(1, 3);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            if (language == "hu")
            {
                Console.WriteLine("Felfedezett szobak: " + Program.felfedezett_szobak + " / "+rooms.Count);
            }
            else
            {
                Console.WriteLine("Explored rooms: " + Program.felfedezett_szobak + " / " + rooms.Count);
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void room_check(char[,] palya, Dictionary<string, bool> rooms, int xPos, int yPos)
        {
            TextReader tr = new StreamReader("../../../lang.txt");
            string language = tr.ReadLine();
            tr.Close();
            Program.lepesek++;
            if (rooms.ContainsKey(yPos+","+xPos))
            {
                if (rooms[yPos + "," + xPos] == false)
                {
                    rooms[yPos + "," + xPos] = true;
                    Program.felfedezett_szobak++;
                    Console.SetCursorPosition(1, 3);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (language == "hu")
                    {
                        Console.WriteLine("Felfedezett szobak: " + Program.felfedezett_szobak + " / " + rooms.Count);
                    }
                    else
                    {
                        Console.WriteLine("Explored rooms: " + Program.felfedezett_szobak + " / " + rooms.Count);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
    }
}
