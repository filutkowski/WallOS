using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WallOS.BootApp
{
    public static class BootConsole
    {
        public static void WriteInfo(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[INFO!]" + text);
        }

    }

    
}
