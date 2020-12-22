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

        public void GenerateMap()
        {
            bool playerPos = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t    ┌─────────────────────┬══─═══════──═════─═════──═■");
            Console.ResetColor();
            for (int i = 0; i < 100; i++)
            {
                if (i % 3 == 1)
                {
                    player.VisitedPosition[i] = true;
                }
                //Console.WriteLine(player.VisitedPosition[i]);
            }

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\t\t    │ ");
                Console.ResetColor();
                for (int j = 0; j < 10; j++)
                {

                    MapArea[i, j] = (i * 10 + j) + 1;

                    if (player.Position[0] == i && player.Position[1] == j)
                    {
                        playerPos = true;
                    }
                    else
                    {
                        playerPos = false;
                    }

                    int temp = (i * 10 + j + 1) - 1;

                    if (playerPos)
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
                if (i == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   POSITION");
                    Console.ResetColor();
                    Console.WriteLine("  [X-{0} Y-{1}]", player.Position[1], player.Position[0]);
                }
                else if (i == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("├");
                    Console.WriteLine("═─═══──════──══─═══──══■");
                    Console.ResetColor();
                }
                else if (i == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   HEALTH");
                    Console.ResetColor();
                    Console.WriteLine("    [{0:D3}/{1}]", player.Health, player.MaxHealth);
                }
                else if (i == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   KEYS");
                    Console.ResetColor();
                    Console.WriteLine("      [{0}/{1}]", player.Keys, KeyAmount);
                }
                else if (i == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   STEPS");
                    Console.ResetColor();
                    Console.WriteLine("     [{0}/{1}]", player.Steps, 80); //80 ska bytas ut mot variabeln för gameoverCondition när den finns.
                }
                else if (i == 7)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("│");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("   POSITION");
                    Console.ResetColor();
                    Console.WriteLine("  [X-{0} Y-{1}]", player.Position[1], player.Position[0]);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("│");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t    └─────────────────────┴═──══─══──═══─══──══■");
            Console.ResetColor();
        }

        public void KeyPosition()
        {

        }
    }
}
