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
                case "w":
                case "up":
                case "goup":
                    if (player.Position[0] != 0)
                    {
                        player.Position.CopyTo(player.PreviousPosition, 0);
                        player.Position[0]--;
                        player.Steps++;
                    }
                    else
                    {
                        gui.PadTextWL("You can't go any further up. Press any key and try another direction.");
                        gui.Indent();
                        Console.ReadKey();
                    }
                    break;
                case "d":
                case "right":
                case "goright":
                    if (player.Position[1] != player.MapSize - 1)
                    {
                        player.Position.CopyTo(player.PreviousPosition, 0);
                        player.Position[1]++;
                        player.Steps++;
                    }
                    else
                    {
                        gui.PadTextWL("You can't go any further right. Press any key and try another direction.");
                        gui.Indent();
                        Console.ReadKey();
                    }
                    break;
                case "s":
                case "down":
                case "godown":
                    if (player.Position[0] != 9)
                    {
                        player.Position.CopyTo(player.PreviousPosition, 0);
                        player.Position[0]++;
                        player.Steps++;
                    }
                    else
                    {
                        gui.PadTextWL("You can't go any further down. Press any key and try another direction.");
                        gui.Indent();
                        Console.ReadKey();
                    }
                    break;
                case "a":
                case "left":
                case "goleft":
                    if (player.Position[1] != 0)
                    {
                        player.Position.CopyTo(player.PreviousPosition, 0);
                        player.Position[1]--;
                        player.Steps++;
                    }
                    else
                    {
                        gui.PadTextWL("You can't go any further left. Press any key and try another direction.");
                        gui.Indent();
                        Console.ReadKey();
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
                case "iddqd": // GOD MODE, doom reference
                    player.Health = 2147483647;
                    player.MaxHealth = 2147483647;
                    player.MaxSteps = 2147483647;
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
            gui.PadTextW($"{player.Name}: ");
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
            gui.PadTextW("CHOOSE DIFFICULTY", "P");
            gui.ResetColor();
            Console.Write(" [0: Easy | 1: Medium | 2: Hard]: ");
            ConsoleKeyInfo difficulty = Console.ReadKey();
            Console.WriteLine();

            if (difficulty.KeyChar == '0')
            {
                gui.PadTextWL("Difficulty set to EASY");
            }

            else if (difficulty.KeyChar == '1')
            {
                gui.PadTextWL("Difficulty set to NORMAL");
            }

            else if (difficulty.KeyChar == '2')
            {
                gui.PadTextWL("Difficulty set to HARD");
            }
            else if (difficulty.KeyChar == '9')
            {
                gui.PadTextWL("Welcome Master [HACKER MODE] activated");
            }
            else
            {
                gui.PadTextWL($"Invalid input, Initializing SAFE MODE.", "P");
                gui.ResetColor();
            }

            player.Settings(difficulty);
            enemy.Settings(difficulty);
            map.MapSettings(difficulty);
        }
    }
}
