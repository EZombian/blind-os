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
                                switch (splittedCommand0[1])
                                {
                                    case "blindos":
                                        mode = 1;
                                        break;
                                }
                                break;
                            case "color":
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
                                break;
                        }
                        break;
                    case 1: // BlindOS
                        Console.Write("Setup/BlindOS > $");
                        string command1 = Console.ReadLine();
                        string[] splittedCommand1 = command1.Split('/');
                        switch (splittedCommand1[0])
                        {
                            case "setup":
                                mode = 0;
                                break;
                            case "application":
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
                                    fr.directoryPath = splittedCommand3[1];
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    Console.WriteLine("\nERR: The path to the folder was not specified\n");
                                }
                                break;
                            case "read":
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
                                    sw.directoryPath = splittedCommand4[1];
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
                                switch (splittedCommand5[1])
                                {
                                    case "gvi":
                                        mode = 6;
                                        break;
                                }
                                break;
                        }
                        break;
                    case 6: // gVI
                        // TODO: przetłumacz na język angielski
                        Random random = new Random();

                        Console.WriteLine("gVI v2.11");
                        Console.WriteLine("Wpisz \"index\" aby poznać listę komend");
                        Console.Write("> $");
                        string CMD = Console.ReadLine();

                    EndGame:
                        Console.WriteLine("\nKomendy startowe (do stworzenia areny):");
                        Console.WriteLine("> $create <jednowyrazowa nazwa areny> - tworzy arenę " + BlindOS.Environment.GameEngine.GVI.Settings.MAX_X + " x " + BlindOS.Environment.GameEngine.GVI.Settings.MAX_Y);
                        Console.WriteLine("> $join <nazwa areny> - dołącz do areny");

                        Console.WriteLine("\nKomendy informacyjne (do uzyskania informacji):");
                        Console.WriteLine("> $pw - informacje o graczach");
                        Console.WriteLine("> $ps - rozpiska wszystcich broni (z wyłączeniem stworzonych przez użytkownika)");
                        Console.WriteLine("> $pg - rozpiska wszystcich bloków");
                        Console.WriteLine("> $sg - wydrukuj arenę wraz z lokalizacją gracza i bota");

                        Console.WriteLine("\nKomendy akcji:");
                        Console.WriteLine("> $w - idź do przodu");
                        Console.WriteLine("> $s - idź do tyłu");
                        Console.WriteLine("> $a - idź w lewo");
                        Console.WriteLine("> $d - idź w prawo");
                        Console.WriteLine("> $bb - zniszcz blok (zastępuje go \"USB\", czyli blokiem użytkowym), a ciebie prenosi kratkę w górę oraz zniszczony blok dodaje do ekwipunku");
                        Console.WriteLine("> $rb <skrót> <kierunek (w / s / a / d> - zamień blok na ... ode mnie na ... i dodaj do ekwipunku blok zamieniony");
                        Console.WriteLine("> $select <Miecz / Łuk> - wybierz broń");
                        Console.WriteLine("> $attack - atakuj (działa tylko gdy obaj gracze stoją na tym samym bloku)");
                        Console.WriteLine("> $nick <nowy jednowyrazowy nick> - zmień nick");

                        Console.Write("\n> $");
                        CMD = Console.ReadLine();
                        string[] cmdSplit = CMD.Split(new char[] { ' ' });

                        Console.WriteLine("\nUtworzono arenę. Wpisz \"$join " + cmdSplit[1] + "\" aby dołączyć\n");

                        BlindOS.Environment.GameEngine.GVI.Area board = new BlindOS.Environment.GameEngine.GVI.Area();
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
                            Console.WriteLine("\n" + cmdSplit[1] + " nie jest prawidłową nazwą areny!\n");
                            goto UndefinedArea;
                        }

                        Console.WriteLine("\nDołączono do areny!\n");

                        BlindOS.Environment.GameEngine.GVI.Entity player = new BlindOS.Environment.GameEngine.GVI.Entity();
                        BlindOS.Environment.GameEngine.GVI.Entity bot = new BlindOS.Environment.GameEngine.GVI.Entity();
                        BlindOS.Environment.GameEngine.GVI.Weapon sword = new BlindOS.Environment.GameEngine.GVI.Weapon();
                        BlindOS.Environment.GameEngine.GVI.Weapon bow = new BlindOS.Environment.GameEngine.GVI.Weapon();
                        sword.damage = 6;
                        sword.durability = 20;
                        sword.name = "Miecz";
                        sword.required[0] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[0];
                        sword.required[1] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[0];
                        sword.required[2] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[2];

                        bow.damage = 5;
                        bow.durability = 24;
                        bow.name = "Łuk";
                        bow.required[0] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[0];
                        bow.required[1] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[2];
                        bow.required[2] = BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[2];

                        int z = 0;
                        int index = 0;

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

                        Console.WriteLine("\n^^^ Oto wasza arena. Za chwilę zostaniesz wyrzucony w jej losowy punkt! ^^^\n");

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

                        Console.WriteLine("Oto wasze koordynaty:\n");
                        Console.WriteLine("Ty: X: " + player.X + "; Y: " + player.Y);
                        Console.WriteLine("Bot: X: " + bot.X + "; Y: " + bot.Y);
                        Console.WriteLine("\nPora rozpocząć zabawę!\n");

                        Console.WriteLine("Twój ruch:\n");
                        while (true)
                        {
                            Console.Write("> $");
                            CMD = Console.ReadLine();
                            Console.WriteLine("\n");
                            cmdSplit = CMD.Split(new char[] { ' ' });

                            switch (cmdSplit[0])
                            {
                                case "pw":
                                    try
                                    {
                                        Console.WriteLine("INFORMACJE:\n");
                                        Console.WriteLine(player.nick + ":");
                                        Console.WriteLine("Koordynaty (X): " + player.X);
                                        Console.WriteLine("Koordynaty (Y): " + player.Y);
                                        float hpFromMax = player.hp / BlindOS.Environment.GameEngine.GVI.Settings.MAX_HP * 100;
                                        Console.WriteLine("Punkty życia: " + player.hp + " / " + BlindOS.Environment.GameEngine.GVI.Settings.MAX_HP + " (" + hpFromMax + "% max. wartości)");
                                        Console.WriteLine("Stoi na: " + board.terrainFull[player.X - 1, player.Y - 1]);
                                        Console.WriteLine("Posiadanego tuff'u: " + player.tuff);
                                        Console.WriteLine("Posiadanego grieef'u: " + player.grieef);
                                        Console.WriteLine("Posiadanego spleef'u: " + player.spleef);

                                        Console.WriteLine("\nBot:");
                                        Console.WriteLine("Koordynaty (X): " + bot.X);
                                        Console.WriteLine("Koordynaty (Y): " + bot.Y);
                                        float hpFromMax2 = bot.hp / BlindOS.Environment.GameEngine.GVI.Settings.MAX_HP * 100;
                                        Console.WriteLine("Punkty życia: " + bot.hp + " / " + BlindOS.Environment.GameEngine.GVI.Settings.MAX_HP + " (" + hpFromMax2 + "% max. wartości)");
                                        Console.WriteLine("Stoi na: " + board.terrainFull[bot.X - 1, bot.Y - 1]);
                                    }
                                    catch (IndexOutOfRangeException)
                                    { // gdy wyrzucono bota poza arenę...
                                        Console.WriteLine("Gracz " + player.nick + " wygrał z botem, gdyż pozbawił go życia wyrzucając go poza arenę");
                                        goto EndGame;
                                    }
                                    break;

                                case "ps":
                                    Console.WriteLine(sword.name + ":");
                                    Console.WriteLine("Zadawane obrażenia: " + sword.damage);
                                    Console.WriteLine("Użyć: " + sword.durability);
                                    Console.WriteLine("Niezbędne przedmioty: " + sword.required[0] + ", " + sword.required[1] + ", " + sword.required[2]);
                                    Console.WriteLine("\n" + bow.name + ":");
                                    Console.WriteLine("Zadawane obrażenia: " + bow.damage);
                                    Console.WriteLine("Użyć: " + bow.durability);
                                    Console.WriteLine("Niezbędne przedmioty: " + bow.required[0] + ", " + bow.required[1] + ", " + bow.required[2]);
                                    break;

                                case "pg":
                                    Console.WriteLine("Bloki:");
                                    for (int i = 0; i < BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName.Length; i++)
                                    {
                                        Console.WriteLine(BlindOS.Environment.GameEngine.GVI.Stuff.blocksSimpleIcons[i] + " - " + BlindOS.Environment.GameEngine.GVI.Stuff.blocksFullName[i]);
                                    }
                                    break;

                                case "sg":
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

                                    board.terrainFull[player.X - 1, player.Y - 1] = "Blok użytkowy";
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
                                                Console.WriteLine("Nie masz wystarczającej ilości tuff'u w ekwipunku");
                                                Console.WriteLine("Ilość tuffu sprawdzisz pod $pw");
                                            }

                                            else
                                            {
                                                switch (cmdSplit[2])
                                                {
                                                    case "w":
                                                        if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Blok użytkowy")
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
                                                            Console.WriteLine("Wykonywana operacja jest bezsensowna. Podmieniasz TUFF na TUFF");
                                                        }
                                                        break;

                                                    case "s":
                                                        if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Blok użytkowy")
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
                                                            Console.WriteLine("Wykonywana operacja jest bezsensowna. Podmieniasz TUFF na TUFF");
                                                        }
                                                        break;

                                                    case "a":
                                                        if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Blok użytkowy")
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
                                                            Console.WriteLine("Wykonywana operacja jest bezsensowna. Podmieniasz TUFF na TUFF");
                                                        }
                                                        break;

                                                    case "d":
                                                        if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Blok użytkowy")
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
                                                            Console.WriteLine("Wykonywana operacja jest bezsensowna. Podmieniasz TUFF na TUFF");
                                                        }
                                                        break;
                                                }
                                            }

                                            break;

                                        case "GRF":
                                            if (player.grieef <= 0)
                                            {
                                                Console.WriteLine("Nie masz wystarczającej ilości grieef'u w ekwipunku");
                                                Console.WriteLine("Ilość grieefu sprawdzisz pod $pw");
                                            }

                                            else
                                            {
                                                switch (cmdSplit[2])
                                                {
                                                    case "w":
                                                        if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Blok użytkowy")
                                                        {
                                                            board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] = "Grieef";
                                                            board.terrain[(player.X - 1) - 1, (player.Y - 1)] = "GRF";
                                                            player.grieef--;
                                                        }

                                                        else if (board.terrainFull[(player.X - 1) - 1, (player.Y - 1)] == "Grieef")
                                                        {
                                                            Console.WriteLine("Wykonywana operacja jest bezsensowna. Podmieniasz GRIEEF na GREEF");
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
                                                        if (board.terrainFull[(player.X - 1) + 1, (player.Y - 1)] == "Blok użytkowy")
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
                                                            Console.WriteLine("Wykonywana operacja jest bezsensowna. Podmieniasz TUFF na TUFF");
                                                        }
                                                        break;

                                                    case "a":
                                                        if (board.terrainFull[(player.X - 1), (player.Y - 1) - 1] == "Blok użytkowy")
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
                                                            Console.WriteLine("Wykonywana operacja jest bezsensowna. Podmieniasz TUFF na TUFF");
                                                        }
                                                        break;

                                                    case "d":
                                                        if (board.terrainFull[(player.X - 1), (player.Y - 1) + 1] == "Blok użytkowy")
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
                                                            Console.WriteLine("Wykonywana operacja jest bezsensowna. Podmieniasz TUFF na TUFF");
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
                                        case "Miecz":
                                            player.selectedItem = "Miecz";
                                            Console.WriteLine("Wybrano przedmiot: Miecz");
                                            break;

                                        case "Łuk":
                                            player.selectedItem = "Łuk";
                                            Console.WriteLine("Wybrano przedmiot: Łuk");
                                            break;
                                    }
                                    break;

                                case "attack":
                                    if (player.X == bot.X && player.Y == bot.Y)
                                    {
                                        if (player.selectedItem == "Miecz")
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

                                        else if (player.selectedItem == "Łuk")
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

                            if (bot.hp <= 0) // FIXME: nieprawidłowa nazwa "Unknown Entity"
                            {
                                Console.WriteLine("Gracz " + player.nick + " wygrał z botem, gdyż pozbawił go życia zabijając go");
                                goto EndGame;
                            }

                            if (board.terrainFull[bot.X - 1, bot.Y - 1] == "Blok użytkowy")
                            {
                                Console.WriteLine("Gracz " + player.nick + " wygrał z botem, gdyż pozbawił go życia wyrzucając go poza arenę");
                                goto EndGame;
                            }

                            if (board.terrainFull[player.X - 1, player.Y - 1] == "Blok użytkowy")
                            {
                                Console.WriteLine("Gracz " + player.nick + " wypadł poza arenę");
                                goto EndGame;
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
            }
        }
        namespace GameEngine
        {
            public static class GVI
            {
                public class Entity
                {
                    public string nick = "Unknown BlindOS.Environment.GameEngine.GVI.Entity";

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

                    public string[,] terrain = new string[BlindOS.Environment.GameEngine.GVI.Settings.MAX_X, BlindOS.Environment.GameEngine.GVI.Settings.MAX_Y] {
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
