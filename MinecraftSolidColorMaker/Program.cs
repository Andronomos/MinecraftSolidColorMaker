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
        private static string _savePath = Environment.CurrentDirectory;
        private static bool _useOldTextureName = false;

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

            if (!string.IsNullOrEmpty(args[1]))
            {
                _useOldTextureName = args[1] == "--usetexturename";
            }

            string newSavePath = args[2];

            if(!string.IsNullOrEmpty(newSavePath))
            {
                if(IsValidPath(newSavePath))
                {
                    _savePath = newSavePath;
                    Directory.CreateDirectory(newSavePath);
                }                
            }

            

            ProcessTextures(textures);
        }

        private static void ProcessTextures(List<string> textures)
        {
            int textureCounter = 0;

            foreach (string texture in textures)
            {
                if(File.Exists(texture))
                {
                    using (Image<Rgba32> img = Image.Load<Rgba32>(texture))
                    {
                        Rgba32 color = img[0, 0];

                        using (var newTexture = new Image<Rgba32>(TextureSize, TextureSize, color))
                        {
                            string name = $"{textureCounter}";

                            if (_useOldTextureName)
                            {
                                name = Path.GetFileNameWithoutExtension(texture);
                            }
                            else
                            {
                                textureCounter++;
                            }

                            newTexture.SaveAsPng(@$"{_savePath}\{name}.png");
                        }
                    }                    
                }
            }
        }

        private static bool IsValidPath(string path)
        {
            try
            {
                Path.GetFullPath(path);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
