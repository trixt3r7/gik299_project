using System;
using System.Collections.Generic;
using System.Text;

namespace gik299_project
{
    class Map
    {

        public int[,] MapArea = new int[10, 10];
        static Player player = new Player();

        public void GenerateMap()
        {
            bool playerPos = false;

            for (int i = 0; i < 10; i++)
            {
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

                    if (!playerPos)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("■ "); //■
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    if (true)
                    {
                        if (player.VisitedPosition[i] == true)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("■ ");
                            Console.ResetColor();
                        }
                    }
                }
                Console.WriteLine();  
            }
        }

        public void KeyPosition()
        {

        }
    }
}
