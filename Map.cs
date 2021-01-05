using System;
using System.Collections.Generic;

namespace gik299_project
{
    class Map
    {
        GUI gui = new GUI();

        public int[,] MapArea;
        public int KeyAmount;
        public List<int> KeyPositions;
        public string[] RoomInformation;
        private bool developer;

        public void MapSettings(ConsoleKeyInfo difficulty)
        {
            developer = false;
            // EASY
            if (difficulty.KeyChar == '0')
            {
                MapArea = new int[10, 5];
                RoomInformation = new string[51];
                KeyAmount = 8;
            }
            // MEDIUM
            else if (difficulty.KeyChar == '1')
            {
                MapArea = new int[10, 10];
                RoomInformation = new string[101];
                KeyAmount = 10;
            }
            // HARD
            else if (difficulty.KeyChar == '2')
            {
                MapArea = new int[10, 15];
                RoomInformation = new string[151];
                KeyAmount = 13;
            }
            // Developer
            else if (difficulty.KeyChar == '9')
            {
                MapArea = new int[10, 10];
                RoomInformation = new string[101];
                KeyAmount = 10;
                developer = true;
            }
            // SUPER EASY
            else
            {
                MapArea = new int[10, 3];
                RoomInformation = new string[31];
                KeyAmount = 5;
            }

            KeyPositions = GenerateKeys();
            RoomInformation = AssignRooms();
        }

        public void GenerateMap()
        {
            int roomNr = 1;
            // Fill the array with 1-100+ [0,0] = 1, [9,9] = 100
            for (int y = 0; y < MapArea.GetLength(0); y++)
            {
                for (int x = 0; x < MapArea.GetLength(1); x++)
                {
                    MapArea[y, x] = roomNr;
                    roomNr++;
                }
            }
        }

        public List<int> GenerateKeys()
        {
            List<int> randomNumbers = new List<int>();
            Random rng = new Random();

            for (int i = 0; i < KeyAmount; i++)
            {
                int numberToAdd;

                do numberToAdd = rng.Next(1, MapArea.Length + 1);
                while (randomNumbers.Contains(numberToAdd) || numberToAdd == (MapArea.Length + 1 - MapArea.GetLength(1)) || numberToAdd == MapArea.GetLength(1));

                randomNumbers.Add(numberToAdd);
            }
            return randomNumbers;
        }

        public void DrawMap(Player player, Enemy enemy)
        {
            int roomNr = 0; // Used to check array values 1-100+
            Console.ForegroundColor = ConsoleColor.Red;
            if (player.MapSize == 3)
            {
                gui.PadTextWL("┌───────┬══─═══════──═════─═════──═■");
            }
            else if (player.MapSize == 5)
            {
                gui.PadTextWL("┌───────────┬══─═══════──═════─═════──═■");
            }
            else if (player.MapSize == 10)
            {
                gui.PadTextWL("┌─────────────────────┬══─═══════──═════─═════──═■");
            }
            else if (player.MapSize == 15)
            {
                gui.PadTextWL("┌───────────────────────────────┬══─═══════──═════─═════──═■");
            }
            else
            {
                gui.PadTextWL("┌──────────────────────══─═══════──═════─═════──═■");
            }

            for (int y = 0; y < MapArea.GetLength(0); y++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                gui.PadTextW("│ ");
                Console.ResetColor();
                for (int x = 0; x < MapArea.GetLength(1); x++)
                {
                    roomNr++;
                    MapArea[y, x] = roomNr;

                    int visited = roomNr - 1; // VisitedPosition bool is 0-99+, therefore -1

                    if (player.Position[0] == y && player.Position[1] == x)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    else if (KeyPositions.Contains(roomNr) && enemy.Positions.Contains(roomNr) && developer == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    else if (KeyPositions.Contains(roomNr) && developer == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    else if (enemy.Positions.Contains(roomNr) && developer == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("■ ");
                        Console.ResetColor();
                    }
                    else if (player.VisitedPosition[visited] == true)
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
                    Console.WriteLine("     [{0}/{1}]", player.Steps, player.MaxSteps);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("│");
                    Console.ResetColor();
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            if (player.MapSize == 3)
            {
                gui.PadTextWL("└───────┴═──══─══──═══─══──══■");
            }
            else if (player.MapSize == 5)
            {
                gui.PadTextWL("└───────────┴═──══─══──═══─══──══■");
            }
            else if (player.MapSize == 10)
            {
                gui.PadTextWL("└─────────────────────┴═──══─══──═══─══──══■");
            }
            else if (player.MapSize == 15)
            {
                gui.PadTextWL("└───────────────────────────────┴═──══─══──═══─══──══■");
            }
            else
            {
                gui.PadTextWL("└──────────────────────══─═══════──═════─═════──═■");
            }
            Console.ResetColor();

        }

        public string CheckForKey(Player player)
        {
            if (KeyPositions.Contains(player.PlayerPosition()))
            {
                player.Keys++; //Adds a key to the player stats.
                KeyPositions.Remove(player.PlayerPosition()); //Remove picked up key so it cannot be picked up again.
                return $"ROOM {player.PlayerPosition()}: You found a keycard, you now have: {player.Keys}/{KeyAmount}";
            }
            return "";
        }

        public string[] AssignRooms()
        {
            // Randomize what to tell in each room
            Random rand = new Random();
            // Hold all the randomized info about each room
            string[] emptyRoomText = new string[MapArea.Length + 1];

            // Random strings text
            string[] roomInformation = new string[] {
                "The room is empty, where to next?",
                "Nothing here, where to next?",
                "Nothing of value in this room, where to next?",
                "You enter a storage room but there seems to be nothing of use,\n        where to next?",
                "You almost stepped on a mine but managed to avoid it, where to next?",
                "Nothing interesting here... where to next?",
                "You enter a room with a key, but an enemy steals it.",
                "You enter a room and hear Canon in D by Johann Pachelbel... but nothing\n        of value seems to exist here. Where to next?",
                "You enter a room and hear the wonderful Clair de Lune, L. 32. However, \n        nothing of value seems to exist here. Where to next?",
                "You enter a room with a single framed painting of an old man, and his   \n        eyes seem to follow you as you explore the room. However, nothing of value\n        seems to exist here. Where to next?",
                "You enter a room where the floor is covered with water,\n        you tiptoe through the puddles."
            };

            // Assign a string to each room from RoomInformation
            for (int i = 1; i < emptyRoomText.Length; i++)
            {
                if (i == MapArea.GetLength(1))
                {
                    emptyRoomText[i] = "You have reached the exit. But don't have all the keycards.\n        Check for the other keycards.";
                }
                else if (i == 69)
                {
                    emptyRoomText[i] = "You find yourself in a very   n i c e   room.";
                }
                else if (i == (MapArea.Length + 1 - MapArea.GetLength(1)))
                {
                    emptyRoomText[i] = "The holding cell where you started.";
                }
                else if (KeyPositions.Contains(i))
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
