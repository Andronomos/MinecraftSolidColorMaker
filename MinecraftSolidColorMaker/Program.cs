using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;

namespace MinecraftSolidColorMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid args");
                return;
            }

            List<string> textures = new();

            if (Directory.Exists(args[0]))
            {
                textures.AddRange(Directory.GetFiles(args[0], "*.png"));
            }

            ProcessTextures(textures);
        }



        private static void ProcessTextures(List<string> textures)
        {
            foreach (string texture in textures)
            {
                using (Image<Rgba32> img = Image.Load<Rgba32>(texture))
                {
                    Rgba32 color = img[0, 0];
                }
            }
        }

        private void CreateNewTexture()
        {
            using (var newTexture = new Image<Rgba32>(16, 16))
            {
                //newTexture.Mutate(i => i.);
                //newTexture.
            }
        }


    }
}
