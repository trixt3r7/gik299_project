using System;

namespace gik299_project
{
    class Control
    {
        Menu menu = new Menu();

        public string caseSwitch;

        public void PlayerInput(Player player)
        {
            menu.PadTextW($"{player.Name}: ");
            caseSwitch = Console.ReadLine();
            switch (caseSwitch)
            {
                case "goup":
                    if (player.Position[0] == 0) //Om spelaren är högst upp i array 0 kan de inte gå högre.
                    {
                        Console.Beep(200, 150);
                        menu.CenterText("You have reach the top wall");
                        player.Position.CopyTo(player.PrevPosition, 0);
                    }
                    else
                    {
                        player.Position.CopyTo(player.PrevPosition, 0);
                        player.Position[0]--;
                        player.Steps++;
                        menu.CenterText("Going up");
                    }
                    break;
                case "goright":
                    if (player.Position[1] == 9)
                    {
                        Console.Beep(200, 150);
                        menu.CenterText("You have reach the right wall");
                        player.Position.CopyTo(player.PrevPosition, 0);
                    }
                    else
                    {
                        player.Position.CopyTo(player.PrevPosition, 0);
                        player.Position[1]++;
                        player.Steps++;
                        menu.CenterText("Going right");
                    }
                    break;
                case "godown":
                    if (player.Position[0] == 9)
                    {
                        Console.Beep(200, 150);
                        menu.CenterText("You have reach the down wall");
                        player.Position.CopyTo(player.PrevPosition, 0);
                    }
                    else
                    {
                        player.Position.CopyTo(player.PrevPosition, 0);
                        player.Position[0]++;
                        player.Steps++;
                        menu.CenterText("Going down");
                    }
                    break;
                case "goleft":
                    if (player.Position[1] == 0)
                    {
                        Console.Beep(200, 150);
                        menu.CenterText("You have reach the left wall");
                        player.Position.CopyTo(player.PrevPosition, 0);
                    }
                    else
                    {
                        player.Position.CopyTo(player.PrevPosition, 0);
                        player.Position[1]--;
                        player.Steps++;
                        menu.CenterText("Going left");
                    }
                    break;
                case "attack":
                    menu.CenterText("There is nothing to attack. Try another command.");
                    break;
                case "flee":
                    menu.CenterText("There is nothing to flee from. Try another command.");
                    break;
                case "menu":
                    menu.InGameMenu();
                    break;
                default:
                    menu.CenterText("Unknown command, type 'help' to see a full list of commands.");
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
            menu.Indent();
            string input = Console.ReadLine();

            switch (input)
            {
                case "attack":
                case "Attack":
                case "ATTACK":
                    menu.PadTextWL($"You attack the {enemy.GetRandomName()}.");
                    player.Attack();
                    break;
                case "flee":
                case "Flee":
                case "FLEE":
                    menu.PadTextWL($"You successfully flee the {enemy.GetRandomName()} and rebound to your previous location.");
                    player.Flee();
                    break;
                case "goup":
                case "godown":
                case "goleft":
                case "goright":
                    menu.PadTextWL("Movement is not allowed while in combat.");
                    break;
                default:
                    menu.PadTextWL("Invalid input, please try again.");
                    break;
            }
            return input;
        }

    }
}
