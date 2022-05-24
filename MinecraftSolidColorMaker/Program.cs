using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing.Extensions;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;

namespace MinecraftSolidColorMaker
{
    class Program
    {
        private const int TextureSize = 16;

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Invalid args");
                Console.ReadLine();
                return;
            }

            List<string> textures = new();

            if (Directory.Exists(args[0]))
            {
                textures.AddRange(Directory.GetFiles(args[0], "*.png"));
            }

            ProcessTextures(textures);

            Console.ReadLine();
        }

        private static void ProcessTextures(List<string> textures)
        {
            foreach (string texture in textures)
            {
                using (Image<Rgba32> img = Image.Load<Rgba32>(texture))
                {
                    Rgba32 color = img[0, 0];

                    //using (var img2 = img.Clone(ctx => ctx.(font, "A short piece of text", Color.HotPink, 5, false)))
                    //{
                    //    img2.Save("output/simple.png");
                    //}


                    CreateNewTexture(color);


                }
            }
        }

        private static void CreateNewTexture(Rgba32 color)
        {
            using (var newTexture = new Image<Rgba32>(TextureSize, TextureSize, color))
            {
                //newTexture.Mutate(i => i.);
                //var rectangle = new RectangleF(0, 0, TextureSize, TextureSize);
                //newTexture.Mutate(i => i.);
                newTexture.SaveAsPng(@"C:\Users\User\Desktop\1.png");
            }
        }
    }
}
