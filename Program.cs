using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Linq.Expressions;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using FireSharp;
using Newtonsoft.Json;
using System.Numerics;

namespace Labyrinth
{
    class FirebaseDatabase
    {
        public int player { get; set; }
        public string username { get; set; }
        public string action { get; set; }
        public int party_id { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }
    }
    class Program
    {
        //Global variables
        private static int time = 120;
        private static int remaring_time = 120;
        private static int time_unlimited = 0;
        private static bool stopwatch_on = true;
        private static bool stopwatch_on_ul = true;
        private static int lepesek = -1;
        private static int felfedezett_szobak = 0;
        private static bool player2_joined = false;
        private static int party_id = 0;
        private static int player = 0;
        private static int other_player = 0;
        private static int other_player_xPos = 0;
        private static int other_player_yPos = 0;
        private static bool other_player_update = true;

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
            Program.time = 120;
            Program.remaring_time = 120;
            Program.time_unlimited = 0;
            Program.lepesek = -1;
            Program.felfedezett_szobak = 0;
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
                if (mode == 1)
                {
                    palya_betoltese(palya_listaban);
                }
                else if (mode == 2)
                {
                    palya_betoltese_blind_mode(palya_listaban);
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
                singlepalyer_game(game_level, xPos, yPos, oszlopok, sorok);
            }
            static void singlepalyer_game(char[,] palya_matrix, int xPos, int yPos, int oszlopok, int sorok)
            {
                Program.stopwatch_on = true;
                Console.SetCursorPosition(0, 0);
                Console.SetCursorPosition(xPos + 5, yPos + 7);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(palya_matrix[yPos, xPos]);
                int megmaradt_ido = 0;
                steps_update();
                var rooms = new Dictionary<string, bool>();
                room_search(palya_matrix, rooms, oszlopok, sorok);
                var idozito = new Timer(stopperora, null, 0, 1000);
                while (Program.remaring_time > 0)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == 'w' || bill == 'a' || bill == 's' || bill == 'd')
                    {
                        if (bill == 'w')
                        {
                            if (yPos != 0)
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('W') && mozgas_iranya(palya_matrix[yPos - 1, xPos]).Contains('S') && mezo_ellenorzes(palya_matrix[yPos - 1, xPos], true) && Program.remaring_time > 0)
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
                            }
                            else
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('W'))
                                {
                                    megmaradt_ido = Program.remaring_time;
                                    Program.stopwatch_on = false;
                                    game_end(megmaradt_ido, rooms.Count, true);
                                    break;
                                }
                            }
                        }
                        if (bill == 'a')
                        {
                            if (xPos != 0)
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('A') && mozgas_iranya(palya_matrix[yPos, xPos - 1]).Contains('D') && mezo_ellenorzes(palya_matrix[yPos, xPos - 1], true) && Program.remaring_time > 0)
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
                            }
                            else
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('A'))
                                {
                                    megmaradt_ido = Program.remaring_time;
                                    Program.stopwatch_on = false;
                                    game_end(megmaradt_ido, rooms.Count, true);
                                    break;
                                }
                            }
                        }
                        if (bill == 's')
                        {
                            if (yPos != oszlopok - 1)
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('S') && mozgas_iranya(palya_matrix[yPos + 1, xPos]).Contains('W') && mezo_ellenorzes(palya_matrix[yPos + 1, xPos], true) && Program.remaring_time > 0)
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
                            }
                            else
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('S'))
                                {
                                    megmaradt_ido = Program.remaring_time;
                                    Program.stopwatch_on = false;
                                    game_end(megmaradt_ido, rooms.Count, true);
                                    break;
                                }
                            }

                        }
                        if (bill == 'd')
                        {
                            if (xPos != sorok - 1)
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('D') && mozgas_iranya(palya_matrix[yPos, xPos + 1]).Contains('A') && mezo_ellenorzes(palya_matrix[yPos, xPos + 1], true) && Program.remaring_time > 0)
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
                            else
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('D'))
                                {
                                    megmaradt_ido = Program.remaring_time;
                                    Program.stopwatch_on = false;
                                    game_end(megmaradt_ido, rooms.Count, true);
                                    break;
                                }
                            }

                        }

                    }
                }
                Program.stopwatch_on = false;
                game_end(megmaradt_ido, rooms.Count, false);
            }
            static void game_end(int hatralevo_ido, int szobak_szama, bool win)
            {
                Console.WindowHeight = 25;
                Console.WindowWidth = 75;
                Console.Clear();
                Console.CursorVisible = false;
                TextReader tr = new StreamReader("../../../lang.txt");
                string language = tr.ReadLine();
                tr.Close();
                if (language == "hu")
                {
                    if (win)
                    {
                        Console.SetCursorPosition(20, 8);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Sikerült kijutnod a labirintusból");
                        Console.SetCursorPosition(24, 10);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felfedezett szobák: " + (felfedezett_szobak) + " / " + szobak_szama);
                        Console.SetCursorPosition(31, 11);
                        Console.WriteLine("Idő: " + (Program.time - Program.remaring_time) + " mp");
                        Console.SetCursorPosition(29, 12);
                        Console.WriteLine("Lépések száma: " + Program.lepesek);
                        Console.SetCursorPosition(22, 14);
                        Console.WriteLine("Nyomd meg az ENTERT a kilépéshez");
                        while (true)
                        {
                            char bill = Console.ReadKey(true).KeyChar;
                            if (bill == (char)ConsoleKey.Enter)
                            {
                                if (bill == (char)ConsoleKey.Enter)
                                {
                                    menu();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(32, 10);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("Vesztettél");
                        Console.SetCursorPosition(24, 11);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Bent ragadtál a labiritusban");
                        Console.SetCursorPosition(22, 13);
                        Console.WriteLine("Nyomd meg az ENTERT a kilépéshez");
                        while (true)
                        {
                            char bill = Console.ReadKey(true).KeyChar;
                            if (bill == (char)ConsoleKey.Enter)
                            {
                                if (bill == (char)ConsoleKey.Enter)
                                {
                                    menu();
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (win)
                    {
                        Console.SetCursorPosition(25, 8);
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("You got out of the maze");
                        Console.SetCursorPosition(25, 10);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Rooms explored: " + (felfedezett_szobak) + " / " + szobak_szama);
                        Console.SetCursorPosition(31, 11);
                        Console.WriteLine("Time: " + (Program.time - Program.remaring_time) + " sec");
                        Console.SetCursorPosition(31, 12);
                        Console.WriteLine("Steps: " + Program.lepesek);
                        Console.SetCursorPosition(26, 14);
                        Console.WriteLine("Press ENTER to quit");
                        while (true)
                        {
                            char bill = Console.ReadKey(true).KeyChar;
                            if (bill == (char)ConsoleKey.Enter)
                            {
                                if (bill == (char)ConsoleKey.Enter)
                                {
                                    menu();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(32, 10);
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Game over");
                        Console.SetCursorPosition(22, 11);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You are stuck in the labyrinth");
                        Console.SetCursorPosition(27, 14);
                        Console.WriteLine("Press ENTER to quit");
                        while (true)
                        {
                            char bill = Console.ReadKey(true).KeyChar;
                            if (bill == (char)ConsoleKey.Enter)
                            {
                                if (bill == (char)ConsoleKey.Enter)
                                {
                                    menu();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            static void palya_betoltese_blind_mode(string[] palya_listaban)
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
                        sor += " ";
                    }
                    Console.SetCursorPosition(kozepre_oszlop, kozepre_sor);
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(sor);
                    kozepre_sor++;
                }
                singlepalyer_game_blind_mode(game_level, xPos, yPos, oszlopok, sorok);
            }
            static void singlepalyer_game_blind_mode(char[,] palya_matrix, int xPos, int yPos, int oszlopok, int sorok)
            {
                Program.stopwatch_on_ul = true;
                Console.SetCursorPosition(0, 0);
                Console.SetCursorPosition(xPos + 5, yPos + 7);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(palya_matrix[yPos, xPos]);
                steps_update();
                var rooms = new Dictionary<string, bool>();
                room_search(palya_matrix, rooms, oszlopok, sorok);
                var idozito = new Timer(stopperora_unlimited, null, 0, 1000);
                while (Program.remaring_time > 0)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == 'w' || bill == 'a' || bill == 's' || bill == 'd')
                    {
                        if (bill == 'w')
                        {
                            if (yPos != 0)
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('W') && mozgas_iranya(palya_matrix[yPos - 1, xPos]).Contains('S') && mezo_ellenorzes(palya_matrix[yPos - 1, xPos], true) && Program.remaring_time > 0)
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
                            }
                            else
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('W'))
                                {
                                    Program.stopwatch_on_ul = false;
                                    game_end_blind_mode(rooms.Count);
                                    break;
                                }
                            }
                        }
                        if (bill == 'a')
                        {
                            if (xPos != 0)
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('A') && mozgas_iranya(palya_matrix[yPos, xPos - 1]).Contains('D') && mezo_ellenorzes(palya_matrix[yPos, xPos - 1], true) && Program.remaring_time > 0)
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
                            }
                            else
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('A'))
                                {
                                    Program.stopwatch_on_ul = false;
                                    game_end_blind_mode(rooms.Count);
                                    break;
                                }
                            }
                        }
                        if (bill == 's')
                        {
                            if (yPos != oszlopok - 1)
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('S') && mozgas_iranya(palya_matrix[yPos + 1, xPos]).Contains('W') && mezo_ellenorzes(palya_matrix[yPos + 1, xPos], true) && Program.remaring_time > 0)
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
                            }
                            else
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('S'))
                                {
                                    Program.stopwatch_on_ul = false;
                                    game_end_blind_mode(rooms.Count);
                                    break;
                                }
                            }

                        }
                        if (bill == 'd')
                        {
                            if (xPos != sorok - 1)
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('D') && mozgas_iranya(palya_matrix[yPos, xPos + 1]).Contains('A') && mezo_ellenorzes(palya_matrix[yPos, xPos + 1], true) && Program.remaring_time > 0)
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
                            else
                            {
                                if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('D'))
                                {
                                    Program.stopwatch_on_ul = false;
                                    game_end_blind_mode(rooms.Count);
                                    break;
                                }
                            }

                        }

                    }
                }
            }
            static void game_end_blind_mode(int szobak_szama)
            {
                Console.WindowHeight = 25;
                Console.WindowWidth = 75;
                Console.Clear();
                Console.CursorVisible = false;
                TextReader tr = new StreamReader("../../../lang.txt");
                string language = tr.ReadLine();
                tr.Close();
                if (language == "hu")
                {
                    Console.SetCursorPosition(20, 8);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Sikerült kijutnod a labirintusból");
                    Console.SetCursorPosition(24, 10);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felfedezett szobák: " + (felfedezett_szobak) + " / " + szobak_szama);
                    Console.SetCursorPosition(31, 11);
                    Console.WriteLine("Idő: " + (Program.time_unlimited) + " mp");
                    Console.SetCursorPosition(29, 12);
                    Console.WriteLine("Lépések száma: " + Program.lepesek);
                    Console.SetCursorPosition(22, 14);
                    Console.WriteLine("Nyomd meg az ENTERT a kilépéshez");
                    while (true)
                    {
                        char bill = Console.ReadKey(true).KeyChar;
                        if (bill == (char)ConsoleKey.Enter)
                        {
                            if (bill == (char)ConsoleKey.Enter)
                            {
                                menu();
                                break;
                            }
                        }
                    }

                }
                else
                {

                    Console.SetCursorPosition(25, 8);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("You got out of the maze");
                    Console.SetCursorPosition(25, 10);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rooms explored: " + (felfedezett_szobak) + " / " + szobak_szama);
                    Console.SetCursorPosition(31, 11);
                    Console.WriteLine("Time: " + (Program.time_unlimited) + " sec");
                    Console.SetCursorPosition(31, 12);
                    Console.WriteLine("Steps: " + Program.lepesek);
                    Console.SetCursorPosition(26, 14);
                    Console.WriteLine("Press ENTER to quit");
                    while (true)
                    {
                        char bill = Console.ReadKey(true).KeyChar;
                        if (bill == (char)ConsoleKey.Enter)
                        {
                            if (bill == (char)ConsoleKey.Enter)
                            {
                                menu();
                                break;
                            }
                        }
                    }

                }
            }
        }
        static void multiplayer()
        {
            Console.Clear();
            Console.CursorVisible = false;
            TextReader tr = new StreamReader("../../../lang.txt");
            string language = tr.ReadLine();
            tr.Close();
            if (language == "hu")
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(48, 14);
                Console.WriteLine("Figyelem!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(21, 15);
                Console.WriteLine("A játék működése nem tökéletes, előfordulhatnak szaggatások,");
                Console.SetCursorPosition(18, 16);
                Console.WriteLine("valamint egyszerre csak 2 játékos veheti igénybe a többjátékos módot");
                Console.SetCursorPosition(34, 18);
                Console.WriteLine("Nyomd meg az ENTERT a folytatáshoz");
                while (true)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == (char)ConsoleKey.Enter)
                    {
                        if (bill == (char)ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                }
                Console.CursorVisible = true;
                Console.Clear();
                string username = "";
                Console.SetCursorPosition(40, 15);
                Console.WriteLine("Adj meg egy felhasználónevet:");
                do
                {
                    Console.SetCursorPosition(42, 16);
                    username = Console.ReadLine();
                } while (username == "");
                create_or_join(username, language);
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(48, 14);
                Console.WriteLine("Caution!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(30, 15);
                Console.WriteLine("Game running is not perfect, lags may occur,");
                Console.SetCursorPosition(22, 16);
                Console.WriteLine("and multiplayer mode can only be used by 2 players at a time");
                Console.SetCursorPosition(40, 18);
                Console.WriteLine("Press ENTER to continue");
                while (true)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == (char)ConsoleKey.Enter)
                    {
                        if (bill == (char)ConsoleKey.Enter)
                        {
                            break;
                        }
                    }
                }
                Console.CursorVisible = true;
                Console.Clear();
                string username = "";
                Console.SetCursorPosition(42, 15);
                Console.WriteLine("Enter your username:");
                do
                {
                    Console.SetCursorPosition(42, 16);
                    username = Console.ReadLine();
                } while (username == "");
                create_or_join(username, language);
            }
            static void create_or_join(string username, string lang)
            {
                Console.Clear();
                Console.CursorVisible = false;
                if (lang == "hu")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(42, 14);
                    Console.WriteLine("Válassz az opciók közül!");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(45, 16);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Party létrehozása");
                    Console.SetCursorPosition(42, 17);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Csatlakozás egy partyhoz");
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
                                    Console.SetCursorPosition(45, 16);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Party létrehozása");
                                    Console.SetCursorPosition(42, 17);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("Csatlakozás egy partyhoz");
                                }
                                else if (selected == 2)
                                {
                                    selected = 1;
                                    Console.SetCursorPosition(45, 16);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("Party létrehozása");
                                    Console.SetCursorPosition(42, 17);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Csatlakozás egy partyhoz");
                                }

                            }

                            else if (bill == (char)ConsoleKey.Enter)
                            {
                                if (selected == 1)
                                {
                                    create_party(username, lang);
                                }
                                else if (selected == 2)
                                {
                                    join_party(username, lang);
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
                    Console.WriteLine("Choose from the options!");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(46, 16);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Create a party");
                    Console.SetCursorPosition(46, 17);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Join to a party");
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
                                    Console.SetCursorPosition(46, 16);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Create a party");
                                    Console.SetCursorPosition(46, 17);
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("Join to a party");
                                }
                                else if (selected == 2)
                                {
                                    selected = 1;
                                    Console.SetCursorPosition(46, 16);
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine("Create a party");
                                    Console.SetCursorPosition(46, 17);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Join to a party");
                                }

                            }

                            else if (bill == (char)ConsoleKey.Enter)
                            {
                                if (selected == 1)
                                {
                                    create_party(username, lang);
                                }
                                else if (selected == 2)
                                {
                                    join_party(username, lang);
                                }
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            }

                        }
                    }
                }
            }
            static void create_party(string username, string lang)
            {
                Random random = new Random();
                Program.party_id = random.Next(10000, 100000);
                Console.Clear();
                Console.CursorVisible = false;

                if (lang == "hu")
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(45, 15);
                    Console.WriteLine("Party azonosítója:");
                    Console.SetCursorPosition(51, 16);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(Program.party_id);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(49, 15);
                    Console.WriteLine("Party id:");
                    Console.SetCursorPosition(51, 16);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(Program.party_id);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                IFirebaseConfig ifc = new FirebaseConfig()
                {
                    AuthSecret = "qhXq6skeydxRKzsCycJlygm1psjDKLZvLudxkFI0",
                    BasePath = "https://projectlabyrinthmw-default-rtdb.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(ifc);
                FirebaseDatabase adatok = new FirebaseDatabase() { };
                adatok = new FirebaseDatabase()
                {
                    player = 1,
                    username = username,
                    action = "wait",
                    party_id = Program.party_id,
                    posX = 0,
                    posY = 0,
                };
                client.Set("GameUpdates/Player" + 1, adatok);
                Program.player2_joined = false;
                var idozito = new Timer(player2_join_test, null, 0, 100);
                while (Program.player2_joined == false)
                {

                }
                multiplayer_palya_betoltes(username, 1);
            }
            static void join_party(string username, string lang)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.CursorVisible = true;
                IFirebaseConfig ifc = new FirebaseConfig()
                {
                    AuthSecret = "qhXq6skeydxRKzsCycJlygm1psjDKLZvLudxkFI0",
                    BasePath = "https://projectlabyrinthmw-default-rtdb.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(ifc);
                var result = client.Get("GameUpdates/Player" + 1);
                FirebaseDatabase std = result.ResultAs<FirebaseDatabase>();
                if (lang == "hu")
                {
                    string party_id_input = "";
                    Console.SetCursorPosition(40, 15);
                    Console.WriteLine("Adj meg egy party azonosítót:");
                    do
                    {
                        Console.SetCursorPosition(42, 16);
                        Console.WriteLine("        ");
                        Console.SetCursorPosition(42, 16);
                        party_id_input = Console.ReadLine();
                    } while (party_id_input == "" || Convert.ToInt32(party_id_input) != std.party_id || std.action != "wait");
                    Program.party_id = Convert.ToInt32(party_id_input);
                }
                else
                {
                    string party_id_input = "";
                    Console.SetCursorPosition(45, 15);
                    Console.WriteLine("Enter a party ID:");
                    do
                    {
                        Console.SetCursorPosition(47, 16);
                        Console.WriteLine("        ");
                        Console.SetCursorPosition(47, 16);
                        party_id_input = Console.ReadLine();
                    } while (party_id_input == "" && Convert.ToInt32(party_id_input) != std.party_id && std.action != "wait");
                    Program.party_id = Convert.ToInt32(party_id_input);
                }
                FirebaseDatabase adatok = new FirebaseDatabase() { };
                adatok = new FirebaseDatabase()
                {
                    player = 2,
                    username = username,
                    action = "join_game",
                    party_id = Program.party_id,
                    posX = 0,
                    posY = 0,
                };
                client.Set("GameUpdates/Player" + 2, adatok);
                multiplayer_palya_betoltes(username, 2);
            }
        }
        static void multiplayer_palya_betoltes(string username, int player)
        {
            int yPos = 0;
            int xPos = 0;
            int masik_player = 0;
            if (player == 1)
            {
                masik_player = 2;
                yPos = 2;
                xPos = 4;
                Program.other_player_yPos = 3;
                Program.other_player_xPos = 29;
            }
            else if (player == 2)
            {
                masik_player = 1;
                yPos = 3;
                xPos = 29;
                Program.other_player_yPos = 2;
                Program.other_player_xPos = 4;
            }

            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "qhXq6skeydxRKzsCycJlygm1psjDKLZvLudxkFI0",
                BasePath = "https://projectlabyrinthmw-default-rtdb.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(ifc);
            var result = client.Get("GameUpdates/Player" + masik_player);
            FirebaseDatabase std = result.ResultAs<FirebaseDatabase>();
            Console.Clear();
            Console.CursorVisible = false;
            string[] palya_listaban = { };
            palya_listaban = File.ReadAllLines("../../../multiplayer.txt");
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
            int kozepre_sor = 5;
            Random random = new Random();
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            for (int isor = 0; isor < oszlopok; isor++)
            {
                string sor = "";
                for (int ioszlop = 0; ioszlop < sorok; ioszlop++)
                {
                    sor += " ";
                }
                Console.SetCursorPosition(kozepre_oszlop, kozepre_sor);
                Console.WriteLine(sor);
                kozepre_sor++;
            }
            Console.SetCursorPosition(5, 1);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("■ " + std.username);
            multiplayer_game(game_level, xPos, yPos, oszlopok, sorok, username, player, masik_player);
        }
        static void multiplayer_game(char[,] palya_matrix, int xPos, int yPos, int oszlopok, int sorok, string username, int player, int masik_player)
        {
            update_my_position(xPos, yPos, player, username);
            Program.other_player_update = true;
            Program.other_player = masik_player;
            Program.player = player;
            var idozito = new Timer(update_other_player_data, null, 0, 100);
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(xPos + 5, yPos + 5);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(palya_matrix[yPos, xPos]);
            while (Program.other_player_update)
            {
                char bill = Console.ReadKey(true).KeyChar;
                if (bill == 'w' || bill == 'a' || bill == 's' || bill == 'd')
                {
                    if (bill == 'w')
                    {
                        if (yPos != 0)
                        {
                            if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('W') && mozgas_iranya(palya_matrix[yPos - 1, xPos]).Contains('S') && mezo_ellenorzes(palya_matrix[yPos - 1, xPos], true) && Program.other_player_update)
                            {
                                Console.SetCursorPosition(xPos + 5, yPos + 5);
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.WriteLine(palya_matrix[yPos, xPos]);
                                yPos--;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(xPos + 5, yPos + 5);
                                Console.WriteLine(palya_matrix[yPos, xPos]);
                                update_my_position(xPos, yPos, player, username);
                            }
                        }
                        else
                        {
                            if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('W'))
                            {
                                multiplayer_end(true);
                                break;
                            }
                        }
                    }
                    if (bill == 'a')
                    {
                        if (xPos != 0)
                        {
                            if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('A') && mozgas_iranya(palya_matrix[yPos, xPos - 1]).Contains('D') && mezo_ellenorzes(palya_matrix[yPos, xPos - 1], true) && Program.other_player_update)
                            {
                                Console.SetCursorPosition(xPos + 5, yPos + 5);
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.WriteLine(palya_matrix[yPos, xPos]);
                                xPos--;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(xPos + 5, yPos + 5);
                                Console.WriteLine(palya_matrix[yPos, xPos]);
                                update_my_position(xPos, yPos, player, username);
                            }
                        }
                        else
                        {
                            if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('A'))
                            {
                                multiplayer_end(true);
                                break;
                            }
                        }
                    }
                    if (bill == 's')
                    {
                        if (yPos != oszlopok - 1)
                        {
                            if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('S') && mozgas_iranya(palya_matrix[yPos + 1, xPos]).Contains('W') && mezo_ellenorzes(palya_matrix[yPos + 1, xPos], true) && Program.other_player_update)
                            {
                                Console.SetCursorPosition(xPos + 5, yPos + 5);
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.WriteLine(palya_matrix[yPos, xPos]);
                                yPos++;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(xPos + 5, yPos + 5);
                                Console.WriteLine(palya_matrix[yPos, xPos]);
                                update_my_position(xPos, yPos, player, username);
                            }
                        }
                        else
                        {
                            if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('S'))
                            {
                                multiplayer_end(true);
                                break;
                            }
                        }

                    }
                    if (bill == 'd')
                    {
                        if (xPos != sorok - 1)
                        {
                            if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('D') && mozgas_iranya(palya_matrix[yPos, xPos + 1]).Contains('A') && mezo_ellenorzes(palya_matrix[yPos, xPos + 1], true) && Program.other_player_update)
                            {
                                Console.SetCursorPosition(xPos + 5, yPos + 5);
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.WriteLine(palya_matrix[yPos, xPos]);
                                xPos++;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(xPos + 5, yPos + 5);
                                Console.WriteLine(palya_matrix[yPos, xPos]);
                                update_my_position(xPos, yPos, player, username);
                            }
                        }
                        else
                        {
                            if (mozgas_iranya(palya_matrix[yPos, xPos]).Contains('D'))
                            {
                                multiplayer_end(true);
                                break;
                            }
                        }

                    }

                }
            }
        }
        static void multiplayer_end(bool win)
        {
            Console.WindowHeight = 25;
            Console.WindowWidth = 75;
            TextReader tr = new StreamReader("../../../lang.txt");
            string language = tr.ReadLine();
            tr.Close();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "qhXq6skeydxRKzsCycJlygm1psjDKLZvLudxkFI0",
                BasePath = "https://projectlabyrinthmw-default-rtdb.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(ifc);
            FirebaseDatabase adatok = new FirebaseDatabase() { };
            if (win)
            {
                adatok = new FirebaseDatabase()
                {
                    player = Program.player,
                    username = "",
                    action = "win",
                    party_id = Program.party_id,
                    posX = 0,
                    posY = 0,
                };
            }
            else
            {
                adatok = new FirebaseDatabase()
                {
                    player = Program.player,
                    username = "",
                    action = "lose",
                    party_id = Program.party_id,
                    posX = 0,
                    posY = 0,
                };
            }
            client.Set("GameUpdates/Player" + Program.player, adatok);
            if (win)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(12, 6);
                Console.WriteLine(" __ __   ___   __ __      __    __  ____  ____   __ ");
                Console.SetCursorPosition(12, 7);
                Console.WriteLine("|  |  | /   \\ |  |  |    |  |__|  ||    ||    \\ |  |");
                Console.SetCursorPosition(12, 8);
                Console.WriteLine("|  |  ||     ||  |  |    |  |  |  | |  | |  _  ||  |");
                Console.SetCursorPosition(12, 9);
                Console.WriteLine("|  ~  ||  O  ||  |  |    |  |  |  | |  | |  |  ||__|");
                Console.SetCursorPosition(12, 10);
                Console.WriteLine("|___, ||     ||  :  |    |  `  '  | |  | |  |  | __ ");
                Console.SetCursorPosition(12, 11);
                Console.WriteLine("|     ||     ||     |     \\      /  |  | |  |  ||  |");
                Console.SetCursorPosition(12, 12);
                Console.WriteLine("|____/  \\___/  \\__,_|      \\_/\\_/  |____||__|__||__|");
                Console.SetCursorPosition(12, 13);
                Console.WriteLine("                                                    ");

                if (language == "hu")
                {
                    Console.SetCursorPosition(19, 15);
                    Console.WriteLine("Te jutottál ki elsőnek a labirintusból");
                    Console.SetCursorPosition(22, 17);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nyomd meg az ENTERT a kilépéshez");
                }
                else
                {
                    Console.SetCursorPosition(18, 15);
                    Console.WriteLine("You were the first to get out of the maze");
                    Console.SetCursorPosition(27, 17);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Press ENTER to quit");
                }
                
                while (true)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == (char)ConsoleKey.Enter)
                    {
                        if (bill == (char)ConsoleKey.Enter)
                        {
                            menu();
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(10, 6);
                Console.WriteLine(" __ __   ___   __ __      _       ___   _____   ___  __ ");
                Console.SetCursorPosition(10, 7);
                Console.WriteLine("|  |  | /   \\ |  |  |    | |     /   \\ / ___/  /  _]|  |");
                Console.SetCursorPosition(10, 8);
                Console.WriteLine("|  |  ||     ||  |  |    | |    |     (   \\_  /  [_ |  |");
                Console.SetCursorPosition(10, 9);
                Console.WriteLine("|  ~  ||  O  ||  |  |    | |___ |  O  |\\__  ||    _]|__|");
                Console.SetCursorPosition(10, 10);
                Console.WriteLine("|___, ||     ||  :  |    |     ||     |/  \\ ||   [_  __ ");
                Console.SetCursorPosition(10, 11);
                Console.WriteLine("|     ||     ||     |    |     ||     |\\    ||     ||  |");
                Console.SetCursorPosition(10, 12);
                Console.WriteLine("|____/  \\___/  \\__,_|    |_____| \\___/  \\___||_____||__|");
                Console.SetCursorPosition(10, 13);
                Console.WriteLine("                                                        ");

                if (language == "hu")
                {
                    Console.SetCursorPosition(25, 15);
                    Console.WriteLine("Próbáld újra legközelebb");
                    Console.SetCursorPosition(22, 17);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nyomd meg az ENTERT a kilépéshez");
                }
                else
                {
                    Console.SetCursorPosition(27, 15);
                    Console.WriteLine("Try again next time");
                    Console.SetCursorPosition(27, 17);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Press ENTER to quit");
                }
                
                while (true)
                {
                    char bill = Console.ReadKey(true).KeyChar;
                    if (bill == (char)ConsoleKey.Enter)
                    {
                        if (bill == (char)ConsoleKey.Enter)
                        {
                            menu();
                            break;
                        }
                    }
                }
            }
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
            if (Program.stopwatch_on)
            {
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
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Hátralévő idő:  " + Program.remaring_time + " mp");
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Hátralévő idő: " + Program.remaring_time + " mp");
                    }
                }
                else
                {
                    if (Program.remaring_time < 10)
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Remaring time:  " + Program.remaring_time + " sec");
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Remaring time: " + Program.remaring_time + " sec");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }



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
                Console.WriteLine("Felfedezett szobak: " + Program.felfedezett_szobak + " / " + rooms.Count);
            }
            else
            {
                Console.WriteLine("Rooms explored: " + Program.felfedezett_szobak + " / " + rooms.Count);
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
            if (rooms.ContainsKey(yPos + "," + xPos))
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
                        Console.WriteLine("Rooms explored: " + Program.felfedezett_szobak + " / " + rooms.Count);
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }
        private static void stopperora_unlimited(object o)
        {
            if (Program.stopwatch_on_ul)
            {
                TextReader tr = new StreamReader("../../../lang.txt");
                string language = tr.ReadLine();
                tr.Close();
                Program.time_unlimited += 1;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                if (language == "hu")
                {
                    if (Program.remaring_time < 10)
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Eltelt idő:  " + Program.time_unlimited + " mp");
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Eltelt idő: " + Program.time_unlimited + " mp");
                    }
                }
                else
                {
                    if (Program.remaring_time < 10)
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Time:  " + Program.time_unlimited + " sec");
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 1);
                        Console.Write("Time: " + Program.time_unlimited + " sec");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
        private static void player2_join_test(object o)
        {
            if (Program.player2_joined == false)
            {
                IFirebaseConfig ifc = new FirebaseConfig()
                {
                    AuthSecret = "qhXq6skeydxRKzsCycJlygm1psjDKLZvLudxkFI0",
                    BasePath = "https://projectlabyrinthmw-default-rtdb.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(ifc);
                var result = client.Get("GameUpdates/Player" + 2);
                FirebaseDatabase std = result.ResultAs<FirebaseDatabase>();
                if (std.action == "join_game" && std.party_id == Program.party_id)
                {
                    Program.player2_joined = true;
                }
            }
        }
        static void update_my_position(int xPos, int yPos, int player, string username)
        {
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "qhXq6skeydxRKzsCycJlygm1psjDKLZvLudxkFI0",
                BasePath = "https://projectlabyrinthmw-default-rtdb.firebaseio.com/"
            };
            IFirebaseClient client = new FirebaseClient(ifc);
            FirebaseDatabase adatok = new FirebaseDatabase() { };
            adatok = new FirebaseDatabase()
            {
                player = player,
                username = username,
                action = "move",
                party_id = Program.party_id,
                posX = xPos,
                posY = yPos,
            };
            client.Set("GameUpdates/Player" + player, adatok);
        }
        private static void update_other_player_data(object o)
        {
            if (Program.other_player_update)
            {
                IFirebaseConfig ifc = new FirebaseConfig()
                {
                    AuthSecret = "qhXq6skeydxRKzsCycJlygm1psjDKLZvLudxkFI0",
                    BasePath = "https://projectlabyrinthmw-default-rtdb.firebaseio.com/"
                };
                IFirebaseClient client = new FirebaseClient(ifc);
                var result = client.Get("GameUpdates/Player" + Program.other_player);
                FirebaseDatabase std = result.ResultAs<FirebaseDatabase>();
                if (std.action == "move")
                {
                    Console.SetCursorPosition(Program.other_player_xPos + 5, Program.other_player_yPos + 5);
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.WriteLine(" ");
                    Program.other_player_xPos = std.posX;
                    Program.other_player_yPos = std.posY;
                    Console.SetCursorPosition(Program.other_player_xPos + 5, Program.other_player_yPos + 5);
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine(" ");
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else if (std.action == "win")
                {
                    Program.other_player_update = false;
                    multiplayer_end(false);
                }
            }

        }
    }
}
