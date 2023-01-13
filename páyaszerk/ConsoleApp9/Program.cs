using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;




namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> elemek = new List<char>() { '█', '║', '═', '╬', '╣', '╠', '╦', '╩', '╔', '╗', '╚', '╝', '.' };
            char[,] map = Generate(5, 10);
            while (true)
            {
                switch (Menu())
                {
                    case '1':
                        Console.Write("\nHány sorból álljon ? :");
                        int sorSzam = Convert.ToInt32(Console.ReadLine());
                        Console.Write("\nHány oszlopból álljon ? :");
                        int oszlopSzam = Convert.ToInt32(Console.ReadLine());
                        map = Generate(sorSzam, oszlopSzam);
                        UpdateConsole(map, true);
                        break;
                    case '2':
                        int sor;
                        int oszlop;
                        int hely;
                        do
                        {
                            try
                            {
                                Console.WriteLine(">>A kilépéshez nyomd meg az Entert<<");
                                Console.Write("Add meg a sort ahova le szeretnéd rakni a pálya elemet: ");
                                sor = Convert.ToInt32(Console.ReadLine()) - 1;
                                Console.WriteLine();
                                Console.WriteLine(">>A kilépéshez nyomd meg az Entert<<");
                                Console.Write("Add meg oszlopot, ahova le szeretnéd rakni a pálya elemet: ");
                                oszlop = Convert.ToInt32(Console.ReadLine()) - 1;
                                Console.WriteLine();
                                Console.WriteLine("(0)█ (1)║ (2)═ (3)╬ (4)╣ (5)╠ (6)╦ (7)╩ (8)╔ (9)╗ (10)╚ (11)╝ (12).");
                                Console.Write("Add meg, melyik pálya elemet szeretnéd lerakni: ");
                                hely = Convert.ToInt32(Console.ReadLine());
                                map[sor, oszlop] = elemek[hely];
                                UpdateConsole(map, true);

                            }
                            catch (System.FormatException)
                            {
                                break;
                            }

                        } while (true);
                        Console.Clear();
                        UpdateConsole(map, true);
                        break;
                    case '3':
                        Console.Clear();
                        map = Load(@"C:\\Labyrinth Map Creator\\Maps\\Map.txt");
                        UpdateConsole(map, true);
                        break;
                    case '4':
                        Save(map, @"C:\\Labyrinth Map Creator\\Maps\\Map.txt");
                        Thread.Sleep(3000);
                        Console.Clear();
                        break;
                    case '5':
                        System.Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }
        }

        static char Menu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================================");
            Console.WriteLine("     Labyrinth Map Creator Main Menu    ");
            Console.WriteLine("=========================================");
            Console.ResetColor();
            Console.WriteLine("\t[1] Új pálya generálása");
            Console.WriteLine("\t[2] Pálya elemek elhelyezése");
            Console.WriteLine("\t[3] Pálya betöltése");
            Console.WriteLine("\t[4] Pálya mentése");
            Console.WriteLine("\t[5] Kilépés");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\nKérlem válasszon egy opciót:  ");
            Console.ResetColor();
            int selection;
            do
            {
                int.TryParse(Console.ReadLine(), out selection);
                if (selection >= 1 && selection <= 5)
                {
                    break;
                }
            } while (true);
            return (char)('0' + selection);
        }


        static char[,] Generate(int rowcount, int colcount)
        {
            char[,] newMap = new char[rowcount, colcount];
            Default(newMap);
            return newMap;
        }


        static void Default(char[,] palya)
        {
            for (int row = 0; row < palya.GetLength(0); row++)
            {
                for (int col = 0; col < palya.GetLength(1); col++)
                {
                    palya[row, col] = '.';
                }
            }
        }

        static char[,] Load(string path)
        {

            string[] lines = System.IO.File.ReadAllLines(path);
            char[,] map = new char[lines.Length, lines[0].Length];
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    map[row, col] = lines[row][col];
                }
            }
            
            return map;
        }
        static void Save(char[,] map, string mapName)
        {
            string[] lines = new string[map.GetLength(0)];
            string line = "";
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    line += map[row, col];
                }
                lines[row] = line;
                line = "";
            }

            string folderName = @"C:\\Labyrinth Map Creator";
            string pathString = System.IO.Path.Combine(folderName, "Maps");
            System.IO.Directory.CreateDirectory(pathString);
            string fileName = "Map.txt";
            pathString = System.IO.Path.Combine(pathString, fileName);
            File.WriteAllLines(pathString, lines);
            Console.WriteLine($"Sikeres mentés! A file a következő helyen mentésre került: {pathString} " );
          
        }
        static void UpdateConsole(char[,] map, bool border = false)
        {
            Console.Clear();
            if (border)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(' ');
                for (int col = 1; col <= map.GetLength(1); col++)
                {
                    if (col % 10 == 0)
                    {
                        Console.Write('.');
                    }
                    else
                    {
                        Console.Write(col % 10);
                    }
                }
            }
            Console.WriteLine();
            for (int row = 0; row < map.GetLength(0); row++)
            {
                if (border)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if ((row + 1) % 10 == 0)
                    {
                        Console.Write('.');
                    }
                    else
                    {
                        Console.Write((row + 1) % 10);
                    }
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                for (int coli = 0; coli < map.GetLength(1); coli++)
                {
                    Console.Write(map[row, coli]);
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}

