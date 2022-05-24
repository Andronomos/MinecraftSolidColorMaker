using System;
using System.IO;

namespace MinecraftSolidColorMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
                if (Directory.Exists(args[0]))
                    workPath = args[0];
        }
    }
}
