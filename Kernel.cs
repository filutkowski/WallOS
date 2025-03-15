using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.Listing;
using Cosmos.System.FileSystem.FAT;
using Cosmos.System.FileSystem.FAT.Listing;

namespace WallOS
{
    public class Kernel : Sys.Kernel
    {
        public static CosmosVFS fs;
        public static string Path = @"0:\";
        public static string DeafaultDosPath = @"0:\DOS";
        public static string DeafaultSystemPath = @"0:\WallOS";
        protected override void BeforeRun()
        {
            fs = new();
            VFSManager.RegisterVFS(fs);
            Console.Clear();
            Console.SetWindowSize(90, 30); 
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            Console.WriteLine("WallOS booted successfully");
        }

        protected override void Run()
        {
        }
    }
}
