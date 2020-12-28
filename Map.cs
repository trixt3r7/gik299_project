using System;
using System.Collections.Generic;
using System.Text;

namespace gik299_project
{
    class Map
    {

        public int[,] MapArea = new int[10, 10];
        static Player player = new Player();
        public int KeyAmount = 10;
        public List<int> TotalKeys;

        public void GenerateMap()
        {
            TotalKeys = KeyPos();
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    MapArea[y, x] = (y * 10 + x) + 1;
                }
            }
        }

        public List<int> KeyPos()
        {
            List<int> randomNumbers = new List<int>();
            Random rng = new Random();

            for (int i = 0; i < 10; i++)
            {
                int numberToAdd;

                do numberToAdd = rng.Next(1,100);
                while (randomNumbers.Contains(numberToAdd) || numberToAdd == 91 || numberToAdd == 10);

                randomNumbers.Add(numberToAdd);
            }
            return randomNumbers;
        }


        //private int[] KeyPos()
        //{
        //    Random rng = new Random();

        //    int[] KeyPosition = new int[10];
        //    for (int i = 0; i < 10; i++)
        //    {
        //        KeyPosition[i] = rng.Next(1,100);
        //        //Här ska det vara något som jämför så inte samma värde skickas ut flera gånger. AKA 2 nycklar i samma ruta.
        //    }
        //    return KeyPosition; //Returns the array so it can be called as TotalKeys in the GenerateMap function.
        //}

        public void DrawMap(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t    ┌─────────────────────┬══─═══════──═════─═════──═■");
            for (int y = 0; y < MapArea.GetLength(0); y++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\t\t    │ ");
                Console.ResetColor();
                for (int x = 0; x < MapArea.GetLength(1); x++)
                {

                    MapArea[y, x] = (y * 10 + x) + 1;

                    int temp = (y * 10 + x + 1) - 1;

                    if (player.Position[0] == y && player.Position[1] == x)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    else if (true)
                    {
                        if (player.VisitedPosition[temp] == true)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("■ ");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("■ ");
                            Console.ResetColor();
                        }
                    }
                }
                if (y == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   POSITION");
                    Console.ResetColor();
                    Console.WriteLine("  [X-{0} Y-{1}]", player.Position[1], player.Position[0]);
                }
                else if (y == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("├");
                    Console.WriteLine("═─═══──════──══─═══──══■");
                    Console.ResetColor();
                }
                else if (y == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   HEALTH");
                    Console.ResetColor();
                    Console.WriteLine("    [{0:D3}/{1}]", player.Health, player.MaxHealth);
                }
                else if (y == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   KEYS");
                    Console.ResetColor();
                    Console.WriteLine("      [{0}/{1}]", player.Keys, KeyAmount);
                }
                else if (y == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   STEPS");
                    Console.ResetColor();
                    Console.WriteLine("     [{0}/{1}]", player.Steps, 80); //80 ska bytas ut mot variabeln för gameoverCondition när den finns.
                }
                else if (y == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   POSITION");
                    Console.ResetColor();
                    Console.WriteLine("  [X-{0} Y-{1}]", player.Position[1], player.Position[0]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("│");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t    └─────────────────────┴═──══─══──═══─══──══■");
            Console.ResetColor();
                
        }
            public void KeyPosition()
        {

        }
    }
}

