using System;
using System.Collections.Generic;
using System.Text;

namespace gik299_project
{
    class Control
    {
        Menu menu = new Menu();

        public string caseSwitch;

        public void PlayerInput(Player player)
        {
            Console.Write($"{player.Name}: ");
            caseSwitch = Console.ReadLine();
            switch (caseSwitch)
            {
                case "goup":
                    if (player.Position[0] == 0) //Om spelaren är högst upp i array 0 kan de inte gå högre.
                    {
                        Console.WriteLine("                                             You have reach the top wall");
                    }
                    else
                    {
                        player.Position.CopyTo(player.PrevPosition, 0);
                        player.Position[0]--;
                        player.Steps++;
                        Console.WriteLine("                                                      Going up");
                    }
                    break;
                case "goright":
                    if (player.Position[1] == 9)
                    {
                        Console.WriteLine("                                             You have reach the right wall");
                    }
                    else
                    {
                        player.Position.CopyTo(player.PrevPosition, 0);
                        player.Position[1]++;
                        player.Steps++;
                        Console.WriteLine("                                                     Going right");
                    }
                    break;
                case "godown":
                    if (player.Position[0] == 9)
                    {
                        Console.WriteLine("                                             You have reach the down wall");
                    }
                    else
                    {
                        player.Position.CopyTo(player.PrevPosition, 0);
                        player.Position[0]++;
                        player.Steps++;
                        Console.WriteLine("                                                     Going down");
                    }
                    break;
                case "goleft":
                    if (player.Position[1] == 0)
                    {
                        Console.WriteLine("                                             You have reach the left wall");
                    }
                    else
                    {
                        player.Position.CopyTo(player.PrevPosition, 0);
                        player.Position[1]--;
                        player.Steps++;
                        Console.WriteLine("                                                   Going left");
                    }
                    break;
                case "attack":
                    Console.WriteLine("                                   There is nothing to attack. Try another command.");
                    break;
                case "flee":
                    Console.WriteLine("                                  There is nothing to flee from. Try another command.");
                    break;
                case "menu":
                    menu.InGameMenu();
                    break;
                default:
                    Console.WriteLine("                              Unknown command, type 'help' to see a full list of commands.");
                    break;
            }

            if (player.VisitedPosition[player.PlayerPrevPosition() - 1] == false)
            {
                player.VisitedPosition[player.PlayerPrevPosition() - 1] = true;
            }
        }

        Enemy enemy = new Enemy();
        public string PlayerAction(Player player)
        {
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "attack":
                case "Attack":
                case "ATTACK":
                    Console.WriteLine($"You attack the {enemy.GetRandomName()}.");
                    player.Attack();
                    break;
                case "flee":
                case "Flee":
                case "FLEE":
                    Console.WriteLine($"You successfully flee the {enemy.GetRandomName()} and rebound to your previous location.");
                    player.Flee();
                    break;
                case "goup":
                case "godown":
                case "goleft":
                case "goright":
                    Console.WriteLine("Movement is not allowed while in combat.");
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }
            return input;
        }

    }
}
