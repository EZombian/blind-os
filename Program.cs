using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var mode = 0;
            Console.WriteLine("BlindOS (TM) | Version 1.1 | By EZombianStudio\n");

            while (true)
            {
                switch (mode)
                {
                    case 0: // Setup
                        Console.Write("Setup > $");
                        string command0 = Console.ReadLine();
                        string[] splittedCommand0 = command0.Split('/');
                        switch (splittedCommand0[0])
                        {
                            case "emulator":
                                try
                                {
                                    switch (splittedCommand0[1])
                                    {
                                        case "blindos":
                                            mode = 1;
                                            break;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("\nERR: Incomplete command\n");
                                }
                                break;
                            case "color":
                                try
                                {
                                    switch (splittedCommand0[1])
                                    {
                                        case "black":
                                            Console.ForegroundColor = ConsoleColor.Black;
                                            break;
                                        case "blue":
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            break;
                                        case "cyan":
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            break;
                                        case "darkblue":
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            break;
                                        case "darkcyan":
                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                            break;
                                        case "darkgray":
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            break;
                                        case "darkgreen":
                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            break;
                                        case "darkmagenta":
                                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                            break;
                                        case "darkred":
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            break;
                                        case "darkyellow":
                                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                                            break;
                                        case "gray":
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            break;
                                        case "green":
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            break;
                                        case "magenta":
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            break;
                                        case "red":
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            break;
                                        case "white":
                                            Console.ForegroundColor = ConsoleColor.White;
                                            break;
                                        case "yellow":
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            break;
                                        case "reset":
                                            Console.ResetColor();
                                            break;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("\nERR: Incomplete command\n");
                                }
                                break;
                        }
                        break;
                    case 1: // BlindOS
                    BlindOS:
                        Console.Write("Setup/BlindOS > $");
                        string command1 = Console.ReadLine();
                        string[] splittedCommand1 = command1.Split('/');
                        switch (splittedCommand1[0])
                        {
                            case "setup":
                                mode = 0;
                                break;
                            case "application":
                                try
                                {
                                    switch (splittedCommand1[1])
                                    {
                                        case "info":
                                            Console.WriteLine("\nList of applications:\n");
                                            Console.WriteLine(" > Clock (clock)");
                                            Console.WriteLine(" > FileReader (fr)");
                                            Console.WriteLine(" > StreanWriter (sw)");
                                            Console.WriteLine();
                                            break;
                                        case "clock":
                                            mode = 2;
                                            break;
                                        case "fr":
                                            mode = 3;
                                            break;
                                        case "sw":
                                            mode = 4;
                                            break;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("\nERR: Incomplete command\n");
                                }
                                break;
                            case "gameengine":
                                mode = 5;
                                break;
                        }
                        break;
                    case 2: // Clock
                        var clock = new BlindOS.Environment.Applications.Clock();
                        Console.Write("Setup/BlindOS/Clock > $");
                        string command2 = Console.ReadLine();
                        string[] splittedCommand2 = command2.Split('/');
                        switch (splittedCommand2[0])
                        {
                            case "info":
                                Console.WriteLine("\nCLOCK - list of commands:\n");
                                Console.WriteLine(" > time = get current time");
                                Console.WriteLine();
                                break;
                            case "time":
                                clock.UpdateTime();
                                Console.WriteLine("\nCurrent Time > {0}\n", clock.GetTime());
                                break;
                            case "exit":
                                mode = 1;
                                break;
                        }
                        break;
                    case 3: // FileReader
                        var fr = new BlindOS.Environment.Applications.FileReader();
                        Console.Write("Setup/BlindOS/FileReader > $");
                        string command3 = Console.ReadLine();
                        string[] splittedCommand3 = command3.Split('/');
                        switch (splittedCommand3[0])
                        {
                            case "info":
                                Console.WriteLine("\nFILE_READER - list of commands:\n");
                                Console.WriteLine(" > path/[full path] = set path of directory");
                                Console.WriteLine(" > read/[filename] = read the file as text");
                                Console.WriteLine();
                                break;
                            case "path":
                                try
                                {
                                    fr.SetPath(splittedCommand3[1]); // FIXME: nie ustawia ścieżki
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("\nERR: The path to the folder was not specified\n");
                                }
                                break;
                            case "read":
                                Console.WriteLine(fr.directoryPath);
                                try
                                {
                                    Console.WriteLine("\nSource of file {0}:\n", splittedCommand3[1]);
                                    var fileSource = fr.Read(splittedCommand3[1]);
                                    foreach (var line in fileSource)
                                    {
                                        Console.WriteLine(line);
                                    }
                                    Console.WriteLine();
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("\nERR: The filename was not specified!\n");
                                }
                                catch (FileNotFoundException)
                                {
                                    Console.WriteLine("\nERR: No such file was found. Are you sure the filename / path is correct and that you entered the file extension?\n");
                                }
                                catch (IOException)
                                {
                                    Console.WriteLine("\nERR: An internal error prevented the file from being read. Please try again later.\n");
                                }
                                break;
                            case "exit":
                                mode = 1;
                                break;
                        }
                        break;
                    case 4: // StreamWriter
                        var sw = new BlindOS.Environment.Applications.StreamWriter();
                        Console.Write("Setup/BlindOS/StreamWriter > $");
                        string command4 = Console.ReadLine();
                        string[] splittedCommand4 = command4.Split('/');
                        switch (splittedCommand4[0])
                        {
                            case "info":
                                Console.WriteLine("\nSTREAM_WRITER - list of commands:\n");
                                Console.WriteLine(" > path/[full path] = set path of directory");
                                Console.WriteLine(" > write/filename = write a text file, #END ends");
                                Console.WriteLine();
                                break;
                            case "path":
                                try
                                {
                                    sw.SetPath(splittedCommand4[1]);
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("\nERR: The path to the folder was not specified\n");
                                }
                                break;
                            case "write":
                                var file = sw.WriteText();
                                sw.Stream(splittedCommand4[1], file.ToArray());
                                break;
                            case "exit":
                                mode = 1;
                                break;
                        }
                        break;
                    case 5: // GameEngine Setup
                        Console.Write("Setup/BlindOS/GameEngine > $");
                        string command5 = Console.ReadLine();
                        string[] splittedCommand5 = command5.Split('/');
                        switch (splittedCommand5[0])
                        {
                            case "info":
                                Console.WriteLine("\nGameEngine Games:\n");
                                Console.WriteLine(" > gVI (language - polish) [gvi]");
                                Console.WriteLine();
                                break;
                            case "launch":
                                try
                                {
                                    switch (splittedCommand5[1])
                                    {
                                        case "gvi":
                                            mode = 6;
                                            break;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("\nERR: Incomplete command\n");
                                }
                                break;
                            case "exit":
                                mode = 1;
                                break;
                        }
                        break;
                    case 6: // gVI
                        {
                            Random random = new Random();

                            Console.WriteLine("gVI by GameEngine");
                            Console.WriteLine("Type \"index\" to get command list");
                            Console.Write("> $");
                            string CMD = Console.ReadLine();

                        EndGame:
                            Console.WriteLine("\nStart commands:");
                            Console.WriteLine("> $create <name> - create area " + BlindOS.Environment.GameEngine.GVI.Settings.MAX_X + " x " + BlindOS.Environment.GameEngine.GVI.Settings.MAX_Y);
                            Console.WriteLine("> $join <area name> - join area");

                            Console.WriteLine("\nWhile-game info commands:");
                            Console.WriteLine("> $player - player and bot info");
                            Console.WriteLine("> $weapon - info about weapons");
                            Console.WriteLine("> $blocks - block and their icon list");
                            Console.WriteLine("> $area - print area with player and bot pos");

                            Console.WriteLine("\nWhile-game action commands:");
                            Console.WriteLine("> $w - go forward");
                            Console.WriteLine("> $s - go back");
                            Console.WriteLine("> $a - go left");
                            Console.WriteLine("> $d - go right");
                            Console.WriteLine("> $bb - break block");
                            Console.WriteLine("> $rb <shortcut> <direction (w / s / a / d> - replace block");
                            Console.WriteLine("> $select <Sword / Bow> - select weapon");
                            Console.WriteLine("> $attack - attack (only works when the player and the bot are on the same field)");
                            Console.WriteLine("> $nick <new nick> - change nickname");
                            Console.WriteLine("> $exit - exit the game");

                        IncompleteCommand1:
                            Console.Write("\n> $");
                            CMD = Console.ReadLine();
                            string[] cmdSplit = CMD.Split(new char[] { ' ' });

                            Console.WriteLine("\nArea successfully created. Type \"$join " + cmdSplit[1] + "\" to join area\n");
                            BlindOS.Environment.GameEngine.GVI.Area board = new BlindOS.Environment.GameEngine.GVI.Area();
                            try
                            {
                                board.name = cmdSplit[1];

                            UndefinedArea:
                                Console.Write("> $");
                                CMD = Console.ReadLine();
                                cmdSplit = CMD.Split(new char[] { ' ' });

                                if (cmdSplit[1] == board.name)
                                {
                                }
                                else
                                {
                                    Console.WriteLine("\n" + cmdSplit[1] + " is not a valid arena name!\n");
                                    goto UndefinedArea;
                                }
                            }
                            catch (IndexOutOfRangeException)
                            {
                                Console.WriteLine("\nERR: Incomplete command!\n");
                                goto IncompleteCommand1;
                            }

                            Console.WriteLine("\nSuccessfully joined to area!\n");

                            BlindOS.Environment.GameEngine.GVI.Entity player = new BlindOS.Environment.GameEngine.GVI.Entity();
                            BlindOS.Environment.GameEngine.GVI.Entity bot = new BlindOS.Environment.GameEngine.GVI.Entity();
                            BlindOS.Environment.GameEngine.GVI.Weapon sword = new BlindOS.Environment.GameEngine.GVI.Weapon();
                            BlindOS.Environment.GameEngine.GVI.Weapon bow = new BlindOS.Environment.GameEngine.GVI.Weapon();
                            sword.damage = 6;
                            sword.durability = 20;
                            sword.name = "Sword";
                            sword.required[0] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[0];
                            sword.required[1] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[0];
                            sword.required[2] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[2];

                            bow.damage = 5;
                            bow.durability = 24;
                            bow.name = "Bow";
                            bow.required[0] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[0];
                            bow.required[1] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[2];
                            bow.required[2] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[2];

                            int z = 0;
                            int index;
                            while (z < BlindOS.Environment.GameEngine.GVI.Settings.MAX_X)
                            {
                                for (int i = 0; i < BlindOS.Environment.GameEngine.GVI.Settings.MAX_Y; i++)
                                {
                                    index = random.Next(BlindOS.Environment.GameEngine.GVI.Stuff.blocksSimpleIcons.Length);
                                    board.terrain[z, i] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksSimpleIcons[index];
                                    board.terrainFull[z, i] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[index];
                                    Console.Write(board.terrain[z, i] + " ");
                                }
                                Console.WriteLine();
                                z++;
                            }

                            Console.WriteLine("\n^^^ Here is your arena. In a moment you will be thrown at its random point! ^^^\n");

                        InvalidSpawn:
                            player.X = random.Next(BlindOS.Environment.GameEngine.GVI.Settings.MAX_X) + 1;
                            player.Y = random.Next(BlindOS.Environment.GameEngine.GVI.Settings.MAX_Y) + 1;
                            bot.X = random.Next(BlindOS.Environment.GameEngine.GVI.Settings.MAX_X) + 1;
                            bot.Y = random.Next(BlindOS.Environment.GameEngine.GVI.Settings.MAX_Y) + 1;

                            if (board.terrain[player.X - 1, player.Y - 1] == "USB" || board.terrain[bot.X - 1, bot.Y - 1] == "USB")
                            {
                                goto InvalidSpawn;
                            }

                            board.terrain[player.X - 1, player.Y - 1] = "_Y_";
                            board.terrain[bot.X - 1, bot.Y - 1] = "_B_";

                            Console.WriteLine("It's your coordinates:\n");
                            Console.WriteLine("You: X: " + player.X + "; Y: " + player.Y);
                            Console.WriteLine("Bot: X: " + bot.X + "; Y: " + bot.Y);
                            Console.WriteLine("\nSTART!\n");

                            Console.WriteLine("Your Turn!\n");
                            while (true)
                            {
                                Console.Write("> $");
                                CMD = Console.ReadLine();
                                Console.WriteLine("\n");
                                cmdSplit = CMD.Split(new char[] { ' ' });

                                switch (cmdSplit[0])
                                {
                                    case "exit":
                                        goto BlindOS;
                                    case "player":
                                        try
                                        {
                                            Console.WriteLine("INFO: \n");
                                            Console.WriteLine(player.nick + ":");
                                            Console.WriteLine("Coordinates (X):" + player.X);
                                            Console.WriteLine("Coordinates (Y):" + player.Y);
                                            float hpFromMax = player.hp / BlindOS.Environment.GameEngine.GVI.Settings.MAX_HP * 100;
                                            Console.WriteLine("Health points:" + player.hp + "/" + BlindOS.Environment.GameEngine.GVI.Settings.MAX_HP + "(" + hpFromMax + "% max. Values)");
                                            Console.WriteLine("Standing on:" + board.terrainFull[player.X - 1, player.Y - 1]);
                                            Console.WriteLine("Owned tuff:" + player.tuff);
                                            Console.WriteLine("Grieef you have:" + player.grieef);
                                            Console.WriteLine("Spleef you have:" + player.spleef);

                                            Console.WriteLine("\nBot:");
                                            Console.WriteLine("(X) coordinates:" + bot.X);
                                            Console.WriteLine("Coordinates (Y):" + bot.Y);
                                            float hpFromMax2 = bot.hp / BlindOS.Environment.GameEngine.GVI.Settings.MAX_HP * 100;
                                            Console.WriteLine("Health points:" + bot.hp + "/" + BlindOS.Environment.GameEngine.GVI.Settings.MAX_HP + "(" + hpFromMax2 + "% max. Values)");
                                            Console.WriteLine("Stands on:" + board.terrainFull[bot.X - 1, bot.Y - 1]);
                                        }
                                        catch (IndexOutOfRangeException)
                                        { // when the bot was thrown out of the arena ...
                                            Console.WriteLine("Player" + player.nick + "won against the bot because it killed it throwing it outside the arena");
                                            goto EndGame;
                                        }
                                        break;

                                    case "weapon":
                                        Console.WriteLine(sword.name + ":");
                                        Console.WriteLine("Damage dealt:" + sword.damage);
                                        Console.WriteLine("Durability:" + sword.durability);
                                        Console.WriteLine("Necessary items:" + sword.required[0] + "," + sword.required[1] + "," + sword.required[2]);
                                        Console.WriteLine("\n" + bow.name + ":");
                                        Console.WriteLine("Damage dealt:" + bow.damage);
                                        Console.WriteLine("Durability:" + bow.durability);
                                        Console.WriteLine("Necessary items:" + bow.required[0] + "," + bow.required[1] + "," + bow.required[2]);
                                        break;

                                    case "blocks":
                                        Console.WriteLine("Blocks:");
                                        for (int i = 0; i < BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName.Length; i++)
                                        {
                                            Console.WriteLine(BlindOS.Environment.GameEngine.GVI.Stuff.blocksSimpleIcons[i] + " - " + BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[i]);
                                        }
                                        break;

                                    case "area":
                                        z = 0;
                                        index = 0;

                                        while (z < BlindOS.Environment.GameEngine.GVI.Settings.MAX_X)
                                        {
                                            for (int i = 0; i < BlindOS.Environment.GameEngine.GVI.Settings.MAX_Y; i++)
                                            {
                                                Console.Write(board.terrain[z, i] + " ");
                                            }
                                            Console.WriteLine();
                                            z++;
                                        }
                                        break;

                                    case "w":
                                        board.terrain[player.X - 1, player.Y - 1] = "SPF";
                                        board.terrainFull[player.X - 1, player.Y - 1] = "Spleef";
                                        player.X--;
                                        board.terrain[player.X - 1, player.Y - 1] = "_Y_";
                                        break;

                                    case "s":
                                        board.terrain[player.X - 1, player.Y - 1] = "SPF";
                                        board.terrainFull[player.X - 1, player.Y - 1] = "Spleef";
                                        player.X++;
                                        board.terrain[player.X - 1, player.Y - 1] = "_Y_";
                                        break;

                                    case "a":
                                        board.terrain[player.X - 1, player.Y - 1] = "SPF";
                                        board.terrainFull[player.X - 1, player.Y - 1] = "Spleef";
                                        player.Y--;
                                        board.terrain[player.X - 1, player.Y - 1] = "_Y_";
                                        break;

                                    case "d":
                                        board.terrain[player.X - 1, player.Y - 1] = "SPF";
                                        board.terrainFull[player.X - 1, player.Y - 1] = "Spleef";
                                        player.Y++;
                                        board.terrain[player.X - 1, player.Y - 1] = "_Y_";
                                        break;

                                    case "bb":
                                        if (board.terrainFull[player.X - 1, player.Y - 1] == "Tuff")
                                        {
                                            ++player.tuff;
                                        }
                                        else if (board.terrainFull[player.X - 1, player.Y - 1] == "Grieef")
                                        {
                                            ++player.grieef;
                                        }
                                        else if (board.terrainFull[player.X - 1, player.Y - 1] == "Spleef")
                                        {
                                            ++player.spleef;
                                        }

                                        board.terrainFull[player.X - 1, player.Y - 1] = "Using block";
                                        board.terrain[player.X - 1, player.Y - 1] = "   ";
                                        player.X--;
                                        board.terrain[player.X - 1, player.Y - 1] = "_Y_";
                                        break;

                                    case "rb":
                                        switch (cmdSplit[1])
                                        {
                                            case "TUF":
                                                if (player.tuff <= 0)
                                                {
                                                    Console.WriteLine("You don't have enough tuff in your inventory");
                                                    Console.WriteLine("You will check the amount of tuff under $ pw");
                                                }

                                                else
                                                {
                                                    switch (cmdSplit[2])
                                                    {
                                                        case "in":
                                                            if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Utility Block")
                                                            {
                                                                board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] = "Tuff";
                                                                board.terrain[(player.X - 1) - 1, (player.Y - 1)] = "TUF";
                                                                player.tuff--;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Grieef")
                                                            {
                                                                board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] = "Tuff";
                                                                board.terrain[(player.X - 1) - 1, (player.Y - 1)] = "TUF";
                                                                player.tuff--;
                                                                player.grieef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Spleef")
                                                            {
                                                                board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] = "Tuff";
                                                                board.terrain[(player.X - 1) - 1, (player.Y - 1)] = "TUF";
                                                                player.tuff--;
                                                                player.spleef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Tuff")
                                                            {
                                                                Console.WriteLine("The operation you are performing is meaningless. You are replacing TUFF with TUFF");
                                                            }
                                                            break;

                                                        case "s":
                                                            if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Utility Block")
                                                            {
                                                                board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] = "Tuff";
                                                                board.terrain[(player.X - 1) + 1, (player.Y - 1)] = "TUF";
                                                                player.tuff--;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Grieef")
                                                            {
                                                                board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] = "Tuff";
                                                                board.terrain[(player.X - 1) + 1, (player.Y - 1)] = "TUF";
                                                                player.tuff--;
                                                                player.grieef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Spleef")
                                                            {
                                                                board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] = "Tuff";
                                                                board.terrain[(player.X - 1) + 1, (player.Y - 1)] = "TUF";
                                                                player.tuff--;
                                                                player.spleef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Tuff")
                                                            {
                                                                Console.WriteLine("The operation you are performing is meaningless. You are replacing TUFF with TUFF");
                                                            }
                                                            break;

                                                        case "a":
                                                            if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Utility Block")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) - 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) - 1] = "TUF";
                                                                player.tuff--;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Grieef")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) - 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) - 1] = "TUF";
                                                                player.tuff--;
                                                                player.grieef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Spleef")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) - 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) - 1] = "TUF";
                                                                player.tuff--;
                                                                player.spleef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Tuff")
                                                            {
                                                                Console.WriteLine("The operation you are performing is meaningless. You are replacing TUFF with TUFF");
                                                            }
                                                            break;

                                                        case "d":
                                                            if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Utility Block")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) + 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) + 1] = "TUF";
                                                                player.tuff--;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Grieef")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) + 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) + 1] = "TUF";
                                                                player.tuff--;
                                                                player.grieef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Spleef")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) + 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) + 1] = "TUF";
                                                                player.tuff--;
                                                                player.spleef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Tuff")
                                                            {
                                                                Console.WriteLine("The operation you are performing is meaningless. You are replacing TUFF with TUFF");
                                                            }
                                                            break;
                                                    }
                                                }

                                                break;

                                            case "GRF":
                                                if (player.grieef <= 0)
                                                {
                                                    Console.WriteLine("You don't have enough grieef in your inventory");
                                                    Console.WriteLine("You can check the number of grieefs under $ pw");
                                                }

                                                else
                                                {
                                                    switch (cmdSplit[2])
                                                    {
                                                        case "in":
                                                            if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Utility Block")
                                                            {
                                                                board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] = "Grieef";
                                                                board.terrain[(player.X - 1) - 1, (player.Y - 1)] = "GRF";
                                                                player.grieef--;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Grieef")
                                                            {
                                                                Console.WriteLine("The operation being performed is pointless. You are replacing GRIEEF with GREEF");
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Spleef")
                                                            {
                                                                board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] = "Grieef";
                                                                board.terrain[(player.X - 1) - 1, (player.Y - 1)] = "GRF";
                                                                player.grieef--;
                                                                player.spleef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Tuff")
                                                            {
                                                                board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] = "Grieef";
                                                                board.terrain[(player.X - 1) - 1, (player.Y - 1)] = "GRF";
                                                                player.grieef--;
                                                                player.tuff++;
                                                            }
                                                            break;

                                                        case "s":
                                                            if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Utility Block")
                                                            {
                                                                board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] = "Tuff";
                                                                board.terrain[(player.X - 1) + 1, (player.Y - 1)] = "TUF";
                                                                player.tuff--;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Grieef")
                                                            {
                                                                board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] = "Tuff";
                                                                board.terrain[(player.X - 1) + 1, (player.Y - 1)] = "TUF";
                                                                player.tuff--;
                                                                player.grieef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Spleef")
                                                            {
                                                                board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] = "Tuff";
                                                                board.terrain[(player.X - 1) + 1, (player.Y - 1)] = "TUF";
                                                                player.tuff--; player.spleef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Tuff")
                                                            {
                                                                Console.WriteLine("The operation you are performing is meaningless. You are replacing TUFF with TUFF");
                                                            }
                                                            break;

                                                        case "a":
                                                            if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Utility Block")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) - 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) - 1] = "TUF";
                                                                player.tuff--;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Grieef")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) - 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) - 1] = "TUF";
                                                                player.tuff--;
                                                                player.grieef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Spleef")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) - 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) - 1] = "TUF";
                                                                player.tuff--;
                                                                player.spleef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Tuff")
                                                            {
                                                                Console.WriteLine("The operation you are performing is meaningless. You are replacing TUFF with TUFF");
                                                            }
                                                            break;

                                                        case "d":
                                                            if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Utility Block")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) + 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) + 1] = "TUF";
                                                                player.tuff--;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Grieef")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) + 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) + 1] = "TUF";
                                                                player.tuff--;
                                                                player.grieef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Spleef")
                                                            {
                                                                board.terrainFull[(player.X - 1), (player.Y - 1) + 1] = "Tuff";
                                                                board.terrain[(player.X - 1), (player.Y - 1) + 1] = "TUF";
                                                                player.tuff--; player.spleef++;
                                                            }

                                                            else if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Tuff")
                                                            {
                                                                Console.WriteLine("The operation you are performing is meaningless. You are replacing TUFF with TUFF");
                                                            }
                                                            break;
                                                    }
                                                }

                                                break;
                                        }
                                        break;

                                    case "select":
                                        switch (cmdSplit[1])
                                        {
                                            case "Sword":
                                                player.selectedItem = "Sword";
                                                Console.WriteLine("Item Selected: Sword");
                                                break;

                                            case "Bow":
                                                player.selectedItem = "Bow";
                                                Console.WriteLine("Item Selected: Bow");
                                                break;
                                        }
                                        break;

                                    case "attack":
                                        if (player.X == bot.X && player.Y == bot.Y)
                                        {
                                            if (player.selectedItem == "Sword")
                                            {
                                                int compass = random.Next(1, 5);

                                                switch (compass)
                                                {
                                                    case 1:
                                                        bot.X -= 2;
                                                        break;

                                                    case 2:
                                                        bot.X += 2;
                                                        break;

                                                    case 3:
                                                        bot.Y -= 2;
                                                        break;

                                                    case 4:
                                                        bot.Y += 2;
                                                        break;
                                                }
                                                bot.hp -= sword.damage;
                                                sword.durability--;
                                                sword.damage -= 0.1F;
                                            }

                                            else if (player.selectedItem == "Arc")
                                            {
                                                int compass = random.Next(1, 5);

                                                switch (compass)
                                                {
                                                    case 1:
                                                        bot.X -= 4;
                                                        break;

                                                    case 2:
                                                        bot.X += 4;
                                                        break;

                                                    case 3:
                                                        bot.Y -= 4;
                                                        break;

                                                    case 4:
                                                        bot.Y += 4;
                                                        break;
                                                }

                                                bot.hp -= bow.damage;
                                                bow.durability--;
                                                bow.damage -= 0.1F;
                                            }

                                            else
                                            {
                                                bot.X--;
                                                bot.hp -= 1;
                                            }
                                        }
                                        else
                                        {
                                            // ***
                                        }
                                        break;

                                    case "nick":
                                        player.nick = cmdSplit[1];
                                        break;
                                }

                                if (bot.hp <= 0)
                                {
                                    Console.WriteLine("Player" + player.nick + "won against the bot because it killed it by killing it");
                                    goto EndGame;
                                }

                                if (board.terrainFull[bot.X - 1, bot.Y - 1] == "Utility Block")
                                {
                                    Console.WriteLine("Player" + player.nick + "won against the bot because it killed it throwing it outside the arena");
                                    goto EndGame;
                                }

                                if (board.terrainFull[player.X - 1, player.Y - 1] == "Utility Block")
                                {
                                    Console.WriteLine("Player" + player.nick + "fell out of the arena");
                                    goto EndGame;
                                }
                            }
                        }

                }
            }
        }

    }
}

namespace BlindOS
{
    namespace Environment
    {
        namespace Applications
        {
            public class Clock
            {
                public DateTime time = DateTime.Now;
                public string culture = "de-DE";

                public void UpdateTime()
                {
                    time = DateTime.Now;
                }

                public string GetTime()
                {
                    var cultureInfo = new CultureInfo(culture);
                    return time.ToString(cultureInfo);
                }
            }

            public class FileReader
            {
                public string directoryPath = Directory.GetCurrentDirectory();

                public string[] Read(string fileName)
                {
                    var path = directoryPath + @"\" + fileName;
                    return File.ReadAllLines(path);
                }
                public void SetPath(string path)
                {
                    directoryPath = path;
                }
            }

            public class StreamWriter
            {
                public string directoryPath = Directory.GetCurrentDirectory();

                public List<String> WriteText()
                {
                    List<String> file = new List<String>();
                    string line = "";
                    while (line != "#END")
                    {
                        line = Console.ReadLine();
                        file.Add(line);
                    }
                    return file;
                }
                public void Stream(string path, string[] text)
                {
                    try
                    {
                        var streamWriter = new System.IO.StreamWriter(directoryPath + @"\" + path);
                        foreach (var line in text)
                        {
                            if (line != "#END") streamWriter.WriteLine(line);
                        }
                        streamWriter.Close();
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("\nERR: The antivirus blocked the ability to edit the file.\n");
                    }
                }
                public void SetPath(string path)
                {
                    directoryPath = path;
                }
            }
        }
        namespace GameEngine
        {
            public static class GVI
            {
                public class Entity
                {
                    public string nick = "Unknown Entity";

                    public int X = 0;
                    public int Y = 0;

                    public float hp = BlindOS.Environment.GameEngine.GVI.Settings.MAX_HP;

                    public string selectedItem = "Miecz";

                    public int tuff = 0;
                    public int grieef = 0;
                    public int spleef = 0;
                }
                public class Weapon
                {
                    public string name = "";
                    public string[] required =
                    {"", "", ""};
                    public float damage = 0F;
                    public int durability = 0;
                }
                public static class Settings
                {
                    public const int MAX_X = 32;
                    public const int MAX_Y = 32;
                    public const int MAX_HP = 20;
                }
                public class Area
                {
                    public string name = "";

                    public string[,] terrain = new string[Settings.MAX_X, BlindOS.Environment.GameEngine.GVI.Settings.MAX_Y] {
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                };

                    public string[,] terrainFull = new string[BlindOS.Environment.GameEngine.GVI.Settings.MAX_X, BlindOS.Environment.GameEngine.GVI.Settings.MAX_Y] {
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                    {"0", "0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0","0",},
                };
                }
                public static class Stuff
                {
                    public static string[] blocksFullName =
                    {
                    "Tuff", "Grieef", "Spleef", "Blok użytkowy"
                };

                    public static string[] blocksSimpleIcons =
                    {
                    "TUF", "GRF", "SPF", "   "
                };

                    public static string[] items =
                    {
                    "Kilof"
                };
                }
            }
        }
    }
}
