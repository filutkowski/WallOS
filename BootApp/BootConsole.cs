using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Threading.Channels;
using Sys = Cosmos.System;
namespace WallOS.BootApp
{
    public static class BootConsole
    {
        public static void WriteInfo(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[INFO!]" + text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR!]" + text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WriteWarning(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[WARNING!]" + text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void WritePanic(string header, string error, bool toRestart, uint seriousness, string panicHeader, string panicError)
        {
            string text = "";
            int textRepeat = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[PANIC!]" + header);
            Console.WriteLine(error);
            Thread.Sleep(5000);
            if (seriousness >= 10)
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            Console.Clear();
            Console.WriteLine("PANIC!");
            Console.WriteLine(panicHeader);
            Console.WriteLine("-" + seriousness + panicError);
            Thread.Sleep(5000);
            if (toRestart)
            {
                Console.Clear();
                while (textRepeat != 2) {
                if (text == ".....")
                {
                    text = ""; textRepeat++;
                }
                else
                {
                    text = text + ".";
                    }
                Console.WriteLine("Rebooting" + text);
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                if (textRepeat == 2)
                {
                    Sys.Power.Reboot();
                }
            }
            else
            {
                Console.WriteLine("Do you want to turn off the device? y = yes, n = no");
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Sys.Power.Shutdown();
                }
                else
                {
                }
            }
        }
    }

    
}
