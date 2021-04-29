using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace BlindOS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BlindOS (TM) | Version 1.0-BETA01 | By EZombianStudio\n");

            while (true)
            {
                switch (BlindOS.mode)
                {
                    case 0: // Setup
                        Console.Write("Setup > $");
                        string command0 = Console.ReadLine();
                        string[] splittedCommand0 = command0.Split('/');
                        switch (splittedCommand0[0]) // TODO: dodaj panel administratora i info o systemie
                        {
                            case "emulator":
                                switch (splittedCommand0[1])
                                {
                                    case "blindos":
                                        BlindOS.mode = 1;
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
                                BlindOS.mode = 0;
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
                                        BlindOS.mode = 2;
                                        break;
                                    case "fr":
                                        BlindOS.mode = 3;
                                        break;
                                    case "sw":
                                        BlindOS.mode = 4;
                                        break;
                                }
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
                                BlindOS.mode = 1;
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
                                BlindOS.mode = 1;
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
                                BlindOS.mode = 1;
                                break;
                        }
                        break;
                }
            }
        }
    }

    public static class BlindOS
    {
        public static int mode = 0;
        public static class Environment
        {
            public static class Applications
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
        }
    }
}
