using System;

namespace gik299_project
{
    class Control
    {
        Menu menu = new Menu();
        Map map = new Map();

        public string caseSwitch;

        public void PlayerInput(Player player)
        {
            menu.TerColor();
            menu.PadTextW($"{player.Name}: ");
            menu.ResetColor();
            caseSwitch = Console.ReadLine();
            switch (caseSwitch)
            {
                case "up":
                case "goup":
                    if (player.Position[0] == 0) //Om spelaren är högst upp i array 0 kan de inte gå högre.
                    {
                        Console.Beep(200, 150);
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
                case "right":
                case "goright":
                    if (player.Position[1] == player.MapSize - 1)
                    {
                        Console.Beep(200, 150);
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
                case "down":
                case "godown":
                    if (player.Position[0] == map.MapArea.GetLength(0) - 1)
                    {
                        Console.Beep(200, 150);
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
                case "left":
                case "goleft":
                    if (player.Position[1] == 0)
                    {
                        Console.Beep(200, 150);
                        player.Position.CopyTo(player.PrevPosition, 0);
                    }
                    else
                    {
                        player.Position.CopyTo(player.PrevPosition, 0);
                        player.Position[1]--;
                        player.Steps++;
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

            // Game Over if exeeding max steps taken
            if (player.Steps > player.MaxSteps)
            {
                menu.LoseBoss();
            }

            if (player.VisitedPosition[player.PlayerPrevPosition() - 1] == false)
            {
                player.VisitedPosition[player.PlayerPrevPosition() - 1] = true;
            }
        }
        public string PlayerAction(Player player)
        {
            string input;
            menu.Indent();
            Console.Write($"{player.Name}: ");
            input = Console.ReadLine();
            switch (input)
            {
                case "attack":
                    player.Attack();
                    menu.PadTextWL($"You kill an enemy.");
                    break;
                case "flee":
                    player.Flee();
                    // menu.PadTextWL($"You successfully flee. You return to your previous position.");
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
