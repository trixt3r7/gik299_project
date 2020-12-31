using System;
using System.Collections.Generic;

namespace gik299_project
{
    class Map
    {
        //static Player player = new Player();
        Menu menu = new Menu();

        public int[,] MapArea;
        public int KeyAmount = 10;
        public List<int> TotalKeys;
        public string[] RoomInformation;

        public void MapSettings()
        {
            MapArea = new int[10, 10];
            KeyAmount = 10;
            TotalKeys = KeyPos();
            RoomInformation = AssignRooms();
        }

        public void GenerateMap()
        {
            // TotalKeys = KeyPos();
            for (int y = 0; y < MapArea.GetLength(0); y++)
            {
                for (int x = 0; x < MapArea.GetLength(1); x++)
                {
                    MapArea[y, x] = (y * MapArea.GetLength(0) + x) + 1;
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

                do numberToAdd = rng.Next(1, 100);
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

        private int CalcNum(int y, int x)
        {
            return y * 10 + x + 1;
        }

        public void DrawMap(Player player, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            menu.PadTextWL("┌─────────────────────┬══─═══════──═════─═════──═■");
            for (int y = 0; y < MapArea.GetLength(0); y++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                menu.PadTextW("│ ");
                Console.ResetColor();
                for (int x = 0; x < MapArea.GetLength(1); x++)
                {

                    MapArea[y, x] = CalcNum(y, x);

                    int temp = CalcNum(y, x) - 1;

                    if (player.Position[0] == y && player.Position[1] == x)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    else if (TotalKeys.Contains(CalcNum(y, x)))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    else if (enemy.Positions.Contains(CalcNum(y, x)))
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
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
            menu.PadTextWL("└─────────────────────┴═──══─══──═══─══──══■");
            Console.ResetColor();

        }

        public string CheckForKey(Player player)
        {
            for (int i = 0; i < 10; i++)
            {
                if (player.PlayerPosition() == TotalKeys[i])
                {
                    player.Keys++; //Adds a key to the player stats.
                    TotalKeys[i] = 0; //Puts the picked up key outside of the map so it cannot be picked up again.
                    return $"ROOM {player.PlayerPosition()}: You found a keycard, you now have: {player.Keys}/{KeyAmount}";
                }
            }
            return "";
        }

        public string[] AssignRooms()
        {
            // Randomize what to tell in each room
            Random rand = new Random();
            // Hold all the randomized info about each room
            string[] emptyRoomText = new string[101];

            // Random strings text
            string[] roomInformation = new string[] {
                "The room is empty, where to next?",
                "Nothing here, where to next?",
                "Nothing of value in this room, where to next?",
                "You enter a storage room but there seems to be nothing of use,\n        where to next?",
                "You almost stepped on a mine but managed to avoid it, where to next?"
            };

            // Assign a string to each room from RoomInformation
            for (int i = 1; i < emptyRoomText.Length; i++)
            {
                if (i == 10)
                {
                    emptyRoomText[i] = "You have reached the exit. But don't have all the keycards.\n        Check for the other keycards.";
                }
                else if (i == 91)
                {
                    emptyRoomText[i] = "The holding cell where you started.";
                }
                else if (TotalKeys.Contains(i))
                {
                    emptyRoomText[i] = "You have picked up a keycard in this room earlier.\n        There is nothing more of use here.";
                }
                else
                {
                    emptyRoomText[i] = roomInformation[rand.Next(0, roomInformation.Length)];
                }
            }
            return emptyRoomText;
        }

    }
}
