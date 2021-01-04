using System;

namespace gik299_project
{
    class Control
    {
        GUI gui = new GUI();

        public string caseSwitch;

        public void PlayerInput(Player player)
        {
            gui.TertiaryColor();
            gui.PadTextW($"{player.Name}: ");
            gui.ResetColor();
            caseSwitch = Console.ReadLine();
            switch (caseSwitch)
            {
                case "u":
                case "up":
                case "goup":
                    if (player.Position[0] != 0)
                    {
                        player.Position.CopyTo(player.PreviousPosition, 0);
                        player.Position[0]--;
                        player.Steps++;
                    }
                    break;
                case "r":
                case "right":
                case "goright":
                    if (player.Position[1] != player.MapSize - 1)
                    {
                        player.Position.CopyTo(player.PreviousPosition, 0);
                        player.Position[1]++;
                        player.Steps++;
                    }
                    break;
                case "d":
                case "down":
                case "godown":
                    if (player.Position[0] != 9)
                    {
                        player.Position.CopyTo(player.PreviousPosition, 0);
                        player.Position[0]++;
                        player.Steps++;
                    }
                    break;
                case "l":
                case "left":
                case "goleft":
                    if (player.Position[1] != 0)
                    {
                        player.Position.CopyTo(player.PreviousPosition, 0);
                        player.Position[1]--;
                        player.Steps++;
                    }
                    break;
                case "attack":
                    gui.CenterText("There is nothing to attack. Try another command.");
                    break;
                case "flee":
                    gui.CenterText("There is nothing to flee from. Try another command.");
                    break;
                case "menu":
                    gui.InGameMenu();
                    break;
                default:
                    gui.CenterText("Unknown command, type 'help' to see a full list of commands.");
                    break;
            }

            // Game Over if exeeding max steps taken
            if (player.Steps > player.MaxSteps)
            {
                gui.LoseBoss();
            }

            // Sets previous position to a visited position.
            if (player.VisitedPosition[player.PlayerPreviousPosition() - 1] == false)
            {
                player.VisitedPosition[player.PlayerPreviousPosition() - 1] = true;
            }
        }
        public string PlayerAction(Player player)
        {
            string input;
            gui.Indent();
            Console.Write($"{player.Name}: ");
            input = Console.ReadLine();
            switch (input)
            {
                case "attack":
                case "a":
                    player.Attack();
                    player.CheckHealth();
                    gui.PadTextWL($"You kill an enemy.");
                    break;
                case "flee":
                case "f":
                    player.Flee();
                    break;
                case "goup":
                case "godown":
                case "goleft":
                case "goright":
                    gui.PadTextWL("Movement is not allowed while in combat.");
                    break;
                default:
                    gui.PadTextWL("Invalid input, please try again.");
                    break;
            }
            return input;
        }

        public void SetDifficultyLevel(Player player, Enemy enemy, Map map)
        {
            
            gui.PadTextWL("Choose difficulty level: ");
            gui.PadTextWL("0: Easy | 1: Medium | 2: Hard");
            gui.HrLine();
            ConsoleKeyInfo difficulty = Console.ReadKey();
            Console.Clear();
            gui.GameLogo();

            if (!(difficulty.KeyChar == '0' || difficulty.KeyChar == '1' || difficulty.KeyChar == '2'))
            {
                gui.HrLine();
                gui.PadTextWL($"Invalid input, difficulty set to S U P E R E A S Y mode.");
            }

            else if (difficulty.KeyChar == '0')
            {
                gui.HrLine();
                gui.PadTextWL("Difficulty set to E A S Y");
            }

            else if (difficulty.KeyChar == '1')
            {
                gui.HrLine();
                gui.PadTextWL("Difficulty set to M E D I U M");
            }

            else if (difficulty.KeyChar == '2')
            {
                gui.HrLine();
                gui.PadTextWL("Difficulty set to H A R D");
            }
            player.Settings(difficulty);
            enemy.Settings(difficulty);
            map.MapSettings(difficulty);
        }
    }
}
