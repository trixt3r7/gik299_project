using System;
using System.Collections.Generic;

namespace gik299_project
{
    class Enemy
    {
        public string[] Names = new string[] { "Grunt", "Guard", "Assault", "Sniper", "Brute", "Netrunner" };
        public List<int> Positions;
        public int[] EnemyCounts = new int[10];
        private int MapSize;
        private int count = 10;

        Control control = new Control();
        GUI gui = new GUI();

        public string GetRandomName()
        {
            Random rdm = new Random();
            int index = rdm.Next(Names.Length);
            string RandomName = Names[index];
            return RandomName;
        }

        public void Settings()
        {
            MapSize = 100;
            Positions = GenerateEnemies();
            EnemyCounts = EnemyAmount();
        }

        public int[] EnemyAmount()
        {
            Random rnd = new Random();
            int[] amount = new int[count];
            for (int i = 0; i < count; i++)
            {
                amount[i] = rnd.Next(1, 4);
            }
            return amount;
        }

        public string CheckForEnemies(Player player)
        {
            string actionEvent = "";
            for (int i = 0; i < count; i++)
            {
                if (player.PlayerPosition() == Positions[i])
                {
                    Console.Clear();
                    gui.SmallGameLogo();
                    Console.WriteLine();
                    gui.HrLine2();

                    if (EnemyCounts[i] == 1)
                    {
                        AsciiArt1();
                        gui.HrLine2();
                        gui.PadTextWL($"You enter a room where a {GetRandomName()} sees you. What do you do?");
                        gui.FightMenu();
                        actionEvent = CheckEnemiesLeft(player, i);
                        break;
                    }

                    else if (EnemyCounts[i] == 2)
                    {
                        AsciiArt2();
                        gui.HrLine2();
                        gui.PadTextWL($"You enter a room with 2 enemies, a {GetRandomName()} and a {GetRandomName()}. What do you do?");
                        gui.FightMenu();
                        actionEvent = CheckEnemiesLeft(player, i);
                        break;
                    }
                    else if (EnemyCounts[i] == 3)
                    {
                        AsciiArt3();
                        gui.HrLine2();
                        gui.PadTextWL($"You enter a room with 3 enemies, a {GetRandomName()}, a {GetRandomName()} and a {GetRandomName()}. What do you do?");
                        gui.FightMenu();
                        actionEvent = CheckEnemiesLeft(player, i);
                        break;
                    }
                }
            }
            return actionEvent;
        }

        public string CheckEnemiesLeft(Player player, int i)
        {
            string actionEvent;

            while (EnemyCounts[i] > 0)
            {
                actionEvent = control.PlayerAction(player);
                if (actionEvent == "attack" || actionEvent == "a")
                {
                    EnemyCounts[i]--;
                    player.EnemiesKilled++;
                    if (EnemyCounts[i] > 0)
                    {
                        gui.PadTextWL($"There are {EnemyCounts[i]} enemies left to fight.");
                    }
                    else if (EnemyCounts[i] == 0)
                    {
                        return ("You have eliminated all enemies in this room. Where to next?");
                    }
                }
                else if (actionEvent == "flee" || actionEvent == "f")
                {
                    return ("You successfully flee and rebound to your previous location.");
                }
            }
            return "";
        }

        public List<int> GenerateEnemies()
        {
            List<int> randomNumbers = new List<int>();
            Random rng = new Random();

            for (int i = 0; i < count; i++)
            {
                int numberToAdd;

                do numberToAdd = rng.Next(1, MapSize);
                while (randomNumbers.Contains(numberToAdd) || numberToAdd == (MapSize + 1 - (MapSize / 10)) || numberToAdd == MapSize / 10);

                randomNumbers.Add(numberToAdd);
            }
            return randomNumbers;
        }

        public void AsciiArt1()
        {
            gui.SecondaryColor();
            gui.PadTextWL("                 .&&&&%%%%&&).                                         ");
            gui.PadTextWL("              .#%%#%%#&&&&&&%%#.                                       ");
            gui.PadTextWL("              &#&&&&%%%&&&&&@@%%(                                        ");
            gui.PadTextWL("             ,%#&%&%#&&##@/****)##                                         ");
            gui.PadTextWL("             %#%#%%#%%&&/(**()**)#                                      ");
            gui.PadTextWL("            ,%#%#@%#@@@@@/(****)/@                                    ");
            gui.PadTextWL("         %%##%%###(&@@&&&%&@@@%##%@%        __                           ");
            gui.PadTextWL("       &#&#*##((##(%@@@@%#%%#&&%%%%%@&/    &&%#                        ");
            gui.PadTextWL("     %%/##@%(####((&@@@&&&%%%%&%%@&&&&&%&%%#&&&&@&&&#&&%&&%&##              ");
            gui.PadTextWL("    #%(#%%@%%%@@##(#&(#(#(/(&@%%%@@@&%@@%&&&&&%&&(//            ");
            gui.PadTextWL("   %%#(@%#%%@%@&/%%#(((#(#(#%&&&&@&&%/((@##(       ");
            gui.PadTextWL("  ##((%%#%&@(#((&%(%%#((##%%####(&%&((/(/((/,     ");
            gui.PadTextWL("  *#%((#(((##&/&&&%#&%&%##@%#####%@(%/(((//&/#*                         ");
            gui.PadTextWL("  %&%##((#%#%#((&%#@@%%##(@######(%&%@&#///&/(&//                       ");
            gui.PadTextWL("  %(#@##%@(@#@#%&@@@@&&&@@@&&%%#%#%%(&%%%%@#(//(%(                      ");
            gui.PadTextWL("  &#((&####(#%&(#%%%@#%###@((###@@(#(#//###%@%#%*                       ");
            gui.PadTextWL("     &%%((%((%@#####@(((((@###%%@@%#@/(#  %(##%                        ");
            gui.PadTextWL("     &%&@&#%##@#((##&#(#((@####(%#(%%%@%                               ");
            gui.PadTextWL("     %#&(%#%%%%%######((##%###%#@%%%%####*                              ");
            gui.PadTextWL("       %#@@%@######@@%&%@@#%@#@#%%%######%(                             ");
            gui.PadTextWL("       (%%(###%@&#@@@%#%&&@%@%%%%#&&##%(/%%# ");
            gui.ResetColor();
        }
        public void AsciiArt2()
        {
            gui.SecondaryColor();
            gui.PadTextWL(@"                                    -+oo+.                                       ");
            gui.PadTextWL(@"                                  .dMMMMMM/                        sddyo`        ");
            gui.PadTextWL(@"                                  .oMoMMMoo\\.                    yMMMMMm.       ");
            gui.PadTextWL(@"   aAmmmmmmmAa                     BoMMMMN` \\                    oNoMMMs\\      ");
            gui.PadTextWL(@"   |MMMMMMMNMMMdNmh:-.`             oNMMMMNNM}}o/                 vOMMMMds\\     ");
            gui.PadTextWL(@"         \OsyMMMMMMMMMMMmhhhhhhhhhhdNMMMMMMMMMMMMh`                 `dMMMMM}}    ");
            gui.PadTextWL(@"             ./+ooooshNMMMMMMMMMMMMMMMMMMMMMMMMMMMm`                -MMMMMMMMh   ");
            gui.PadTextWL(@"                       .:oydmNNMMMMMMMMMMMMMMMMMMMMm.               yMMMMMMMMM+  ");
            gui.PadTextWL(@"                                `/hMMMMMMMMMMMMMMMMMMs              sMMMMMMMMMm  ");
            gui.PadTextWL(@"                                    /NMMMMMMMMMMN:oNMMMd-           /yNMMMMMMMMM`");
            gui.PadTextWL(@"                                    .MMMMMMMMMMy  `yMMMy          /msMMMMMMMMMM. ");
            gui.PadTextWL(@"                                    .MMMMMMMMMMs    oNMMs        +MMMMMMMMMMMMMo ");
            gui.PadTextWL(@"                                    hMMMMMMMMMMy     .hMM/      dMMMMhyMMMMMMMMd ");
            gui.PadTextWL(@"                                   /MMMMMMMMMMMMd`     NMN`     /MM/ `mMMMMMMMMh ");
            gui.PadTextWL(@"                                   hMMMMMMMMMMMMMd     sNMo    /MM/  `MMMMMMMMM- ");
            gui.PadTextWL(@"                                  -MMMMMMMMMMMMMMMs     `-.   /MM/   yMMMMMMMMs  ");
            gui.PadTextWL(@"                                  /MMMMMMMMMMMMMMMM:         /M/    sMMMMMMMMh   ");
            gui.PadTextWL(@"                                  -MMMMMMMMyMMMMMMMm        /X/    `yMMMMMMMMM/  ");
            gui.PadTextWL(@"                                  .MMMMMMMy /MMMMMMM/            .mMMMMMMMMMM`   ");
            gui.ResetColor();
        }
        public void AsciiArt3()
        {
            gui.SecondaryColor();
            gui.PadTextWL(@"                                      MMMMMMN                                    ");
            gui.PadTextWL(@"             ::.                    .MMMMMMMMm                    -/:            ");
            gui.PadTextWL(@"            hMMMd`                  `NMMMMMMmm                   smMMy           ");
            gui.PadTextWL(@"            dNmMM+                   hM_aMa_M/                   dMMMs           ");
            gui.PadTextWL(@"            /NMMm:             ___.-:mmMMMMMMN_                `:dMMMms+-        ");
            gui.PadTextWL(@"         `+ydMMMMMMmd-        /ydNMMMMMAmmmAMN++\             :NMMMMMMMMMo       ");
            gui.PadTextWL(@"         mMMMMMMMMMMMM-      +MMMMMMMMMMMMMMMMMd+`       \\  -MMMMMMMMMMMh    _  ");
            gui.PadTextWL(@"       :MMMMMMMMMMMMMm.    `NMMMMMMMMMMMMMMMMMMMN:        \\.NMhNMMMMMMMMM\/sh/  ");
            gui.PadTextWL(@"       oMMMMMMMMMMmMMMs    `MMMMMMMMMMMMMMMMMMMMMN.        yMM MMMMMMMMMMMMN+/   ");
            gui.PadTextWL(@"       .NMNNMMMMMMMshMM+    .MMMMMMMMMMMMMMMMMMMMMMm.       `hMMMMMMMMMMMo:o+    ");
            gui.PadTextWL(@"      /yMM+mMMMMMMMmdMM.    sMMMM MMMMMMMMMMMMMM MMMNo       `yMMMMMMMMMM`/y     ");
            gui.PadTextWL(@"     /+MMd:MMMMMMMMMMMh    `mMMMMM MMMMMMMMMMMMM MMMN`       `NMMMMMMMMMh+       ");
            gui.PadTextWL(@"    //+mMmNMMMMMMMMMMN.     `dMMMMM MMMMMMMMMMMMM MMMMm:       mMMMMMMMMM`       ");
            gui.PadTextWL(@"   //+/MNohMMMMMMMMMM+       -NMMXXXXXMMMMMMMXXXXXMMMMMd/:.`   hmMMdMMMMd        ");
            gui.PadTextWL(@"   /+/    +MMMMMMMMMm         `:sMXXXXXMMMMMMXXXXXXXXXXXXXXXXXXXXXXXXXXXX|-      ");
            gui.PadTextWL(@"  /+/     -MMMMyMMMMo           oMMMMMmmmm\MMMXXXXXXXXXXXXXXXXXXXXXXXXXX|-       ");
            gui.PadTextWL(@"           NMMM:MMMM/          /MMMMMMMMMM|mmmmmmmmmmmM.`    `.so+..-///+        ");
            gui.PadTextWL(@"           NMMN mMMM:          NMMMMMMMMMMMMMMMMMMMMMMM`      -MMM. +MMM.        ");
            gui.PadTextWL(@"           NMMy /MMM-         -MMMMMMMMMMMMMMMMMMMMMMMM-      `NMm  `NMM.        ");
            gui.ResetColor();
        }
    }
}
