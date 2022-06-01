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
        private static string _savePath = @$"{Environment.CurrentDirectory}\output\";
        private static bool _useOldTextureName = true;

        static void Main(string[] args)
        {
            List<string> textures = new();
            textures.AddRange(Directory.GetFiles(Environment.CurrentDirectory, "*.png"));
            Directory.CreateDirectory(_savePath);
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
    }
}
