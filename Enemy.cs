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
        public int count = 10;

        Control control = new Control();
        Menu menu = new Menu();

        public string GetRandomName()
        {
            Random rdm = new Random();
            int index = rdm.Next(Names.Length);
            string RandomName = Names[index];
            return RandomName;
        }

        public void GenerateEnemies()
        {
            MapSize = 100;
            Positions = EnemyPosition();
            EnemyCounts = EnemyCount();
        }

        public int[] EnemyCount()
        {
            Random rnd = new Random();
            int[] enemyCount = new int[count];
            for (int i = 0; i < count; i++)
            {
                enemyCount[i] = rnd.Next(1, 4);
            }
            return enemyCount;
        }

        public void ComparePos()
        {

        }

        public string CheckForEnemies(Player player)
        {
            string ActionEvent = "";
            for (int i = 0; i < count; i++)
            {
                if (player.PlayerPosition() == Positions[i])
                {
                    Console.Clear();
                    menu.SmallGameLogo();
                    Console.WriteLine();
                    menu.HrLine2();

                    if (EnemyCounts[i] == 1)
                    {
                        AsciiArt1();
                        menu.HrLine2();
                        menu.PadTextWL($"You enter a room where a {GetRandomName()} sees you. What do you do?");
                        menu.FightMenu();
                        ActionEvent = CheckEnemiesLeft(player, i);
                        break;
                    }

                    else if (EnemyCounts[i] == 2)
                    {
                        AsciiArt2();
                        menu.HrLine2();
                        menu.PadTextWL($"You enter a room with 2 enemies, a {GetRandomName()} and a {GetRandomName()}. What do you do?");
                        menu.FightMenu();
                        ActionEvent = CheckEnemiesLeft(player, i);
                        break;
                    }
                    else if (EnemyCounts[i] == 3)
                    {
                        AsciiArt3();
                        menu.HrLine2();
                        menu.PadTextWL($"You enter a room with 3 enemies, a {GetRandomName()}, a {GetRandomName()} and a {GetRandomName()}. What do you do?");
                        menu.FightMenu();
                        ActionEvent = CheckEnemiesLeft(player, i);
                        break;
                    }
                }
            }
            return ActionEvent;
        }

        public string CheckEnemiesLeft(Player player, int i)
        {
            string ActionEvent;

            while (EnemyCounts[i] > 0)
            {
                ActionEvent = control.PlayerAction(player);
                if (ActionEvent == "attack")
                {
                    EnemyCounts[i]--;
                    player.EnemiesKilled++;
                    if (EnemyCounts[i] > 0)
                    {
                        menu.PadTextWL($"There are {EnemyCounts[i]} enemies left to fight.");
                    }
                    else if (EnemyCounts[i] == 0)
                    {
                        return ("You have eliminated all enemies in this room. Where to next?");
                    }
                }
                else if (ActionEvent == "flee")
                {
                    return ("You successfully flee and rebound to your previous location.");
                }
            }
            return "";
        }

        public List<int> EnemyPosition()
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
            menu.SecColor();
            menu.PadTextWL("                 .&&&&%%%%&&).                                         ");
            menu.PadTextWL("              .#%%#%%#&&&&&&%%#.                                       ");
            menu.PadTextWL("              &#&&&&%%%&&&&&@@%%(                                        ");
            menu.PadTextWL("             ,%#&%&%#&&##@/****)##                                         ");
            menu.PadTextWL("             %#%#%%#%%&&/(**()**)#                                      ");
            menu.PadTextWL("            ,%#%#@%#@@@@@/(****)/@                                    ");
            menu.PadTextWL("         %%##%%###(&@@&&&%&@@@%##%@%        __                           ");
            menu.PadTextWL("       &#&#*##((##(%@@@@%#%%#&&%%%%%@&/    &&%#                        ");
            menu.PadTextWL("     %%/##@%(####((&@@@&&&%%%%&%%@&&&&&%&%%#&&&&@&&&#&&%&&%&##              ");
            menu.PadTextWL("    #%(#%%@%%%@@##(#&(#(#(/(&@%%%@@@&%@@%&&&&&%&&(//            ");
            menu.PadTextWL("   %%#(@%#%%@%@&/%%#(((#(#(#%&&&&@&&%/((@##(       ");
            menu.PadTextWL("  ##((%%#%&@(#((&%(%%#((##%%####(&%&((/(/((/,     ");
            menu.PadTextWL("  *#%((#(((##&/&&&%#&%&%##@%#####%@(%/(((//&/#*                         ");
            menu.PadTextWL("  %&%##((#%#%#((&%#@@%%##(@######(%&%@&#///&/(&//                       ");
            menu.PadTextWL("  %(#@##%@(@#@#%&@@@@&&&@@@&&%%#%#%%(&%%%%@#(//(%(                      ");
            menu.PadTextWL("  &#((&####(#%&(#%%%@#%###@((###@@(#(#//###%@%#%*                       ");
            menu.PadTextWL("     &%%((%((%@#####@(((((@###%%@@%#@/(#  %(##%                        ");
            menu.PadTextWL("     &%&@&#%##@#((##&#(#((@####(%#(%%%@%                               ");
            menu.PadTextWL("     %#&(%#%%%%%######((##%###%#@%%%%####*                              ");
            menu.PadTextWL("       %#@@%@######@@%&%@@#%@#@#%%%######%(                             ");
            menu.PadTextWL("       (%%(###%@&#@@@%#%&&@%@%%%%#&&##%(/%%# ");
            menu.ResetColor();
        }
        public void AsciiArt2()
        {
            menu.SecColor();
            menu.PadTextWL(@"                                    -+oo+.                                       ");
            menu.PadTextWL(@"                                  .dMMMMMM/                        sddyo`        ");
            menu.PadTextWL(@"                                  .oMoMMMoo\\.                    yMMMMMm.       ");
            menu.PadTextWL(@"   aAmmmmmmmAa                     BoMMMMN` \\                    oNoMMMs\\      ");
            menu.PadTextWL(@"   |MMMMMMMNMMMdNmh:-.`             oNMMMMNNM}}o/                 vOMMMMds\\     ");
            menu.PadTextWL(@"         \OsyMMMMMMMMMMMmhhhhhhhhhhdNMMMMMMMMMMMMh`                 `dMMMMM}}    ");
            menu.PadTextWL(@"             ./+ooooshNMMMMMMMMMMMMMMMMMMMMMMMMMMMm`                -MMMMMMMMh   ");
            menu.PadTextWL(@"                       .:oydmNNMMMMMMMMMMMMMMMMMMMMm.               yMMMMMMMMM+  ");
            menu.PadTextWL(@"                                `/hMMMMMMMMMMMMMMMMMMs              sMMMMMMMMMm  ");
            menu.PadTextWL(@"                                    /NMMMMMMMMMMN:oNMMMd-           /yNMMMMMMMMM`");
            menu.PadTextWL(@"                                    .MMMMMMMMMMy  `yMMMy          /msMMMMMMMMMM. ");
            menu.PadTextWL(@"                                    .MMMMMMMMMMs    oNMMs        +MMMMMMMMMMMMMo ");
            menu.PadTextWL(@"                                    hMMMMMMMMMMy     .hMM/      dMMMMhyMMMMMMMMd ");
            menu.PadTextWL(@"                                   /MMMMMMMMMMMMd`     NMN`     /MM/ `mMMMMMMMMh ");
            menu.PadTextWL(@"                                   hMMMMMMMMMMMMMd     sNMo    /MM/  `MMMMMMMMM- ");
            menu.PadTextWL(@"                                  -MMMMMMMMMMMMMMMs     `-.   /MM/   yMMMMMMMMs  ");
            menu.PadTextWL(@"                                  /MMMMMMMMMMMMMMMM:         /M/    sMMMMMMMMh   ");
            menu.PadTextWL(@"                                  -MMMMMMMMyMMMMMMMm        /X/    `yMMMMMMMMM/  ");
            menu.PadTextWL(@"                                  .MMMMMMMy /MMMMMMM/            .mMMMMMMMMMM`   ");
            menu.ResetColor();
        }
        public void AsciiArt3()
        {
            menu.SecColor();
            menu.PadTextWL(@"                                      MMMMMMN                                    ");
            menu.PadTextWL(@"             ::.                    .MMMMMMMMm                    -/:            ");
            menu.PadTextWL(@"            hMMMd`                  `NMMMMMMmm                   smMMy           ");
            menu.PadTextWL(@"            dNmMM+                   hM_aMa_M/                   dMMMs           ");
            menu.PadTextWL(@"            /NMMm:             ___.-:mmMMMMMMN_                `:dMMMms+-        ");
            menu.PadTextWL(@"         `+ydMMMMMMmd-        /ydNMMMMMAmmmAMN++\             :NMMMMMMMMMo       ");
            menu.PadTextWL(@"         mMMMMMMMMMMMM-      +MMMMMMMMMMMMMMMMMd+`       \\  -MMMMMMMMMMMh    _  ");
            menu.PadTextWL(@"       :MMMMMMMMMMMMMm.    `NMMMMMMMMMMMMMMMMMMMN:        \\.NMhNMMMMMMMMM\/sh/  ");
            menu.PadTextWL(@"       oMMMMMMMMMMmMMMs    `MMMMMMMMMMMMMMMMMMMMMN.        yMM MMMMMMMMMMMMN+/   ");
            menu.PadTextWL(@"       .NMNNMMMMMMMshMM+    .MMMMMMMMMMMMMMMMMMMMMMm.       `hMMMMMMMMMMMo:o+    ");
            menu.PadTextWL(@"      /yMM+mMMMMMMMmdMM.    sMMMM MMMMMMMMMMMMMM MMMNo       `yMMMMMMMMMM`/y     ");
            menu.PadTextWL(@"     /+MMd:MMMMMMMMMMMh    `mMMMMM MMMMMMMMMMMMM MMMN`       `NMMMMMMMMMh+       ");
            menu.PadTextWL(@"    //+mMmNMMMMMMMMMMN.     `dMMMMM MMMMMMMMMMMMM MMMMm:       mMMMMMMMMM`       ");
            menu.PadTextWL(@"   //+/MNohMMMMMMMMMM+       -NMMXXXXXMMMMMMMXXXXXMMMMMd/:.`   hmMMdMMMMd        ");
            menu.PadTextWL(@"   /+/    +MMMMMMMMMm         `:sMXXXXXMMMMMMXXXXXXXXXXXXXXXXXXXXXXXXXXXX|-      ");
            menu.PadTextWL(@"  /+/     -MMMMyMMMMo           oMMMMMmmmm\MMMXXXXXXXXXXXXXXXXXXXXXXXXXX|-       ");
            menu.PadTextWL(@"           NMMM:MMMM/          /MMMMMMMMMM|mmmmmmmmmmmM.`    `.so+..-///+        ");
            menu.PadTextWL(@"           NMMN mMMM:          NMMMMMMMMMMMMMMMMMMMMMMM`      -MMM. +MMM.        ");
            menu.PadTextWL(@"           NMMy /MMM-         -MMMMMMMMMMMMMMMMMMMMMMMM-      `NMm  `NMM.        ");
            menu.ResetColor();
        }
    }
}
