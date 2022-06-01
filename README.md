# MinecraftSolidColorMaker
A small utility for converting Minecraft textures to solid colors

While working on my mods I often need to create solid color textures from vanilla textures (wool, glass, etc). This program automates that task by sampling the top left pixel of the texture and uses it to create a new one.

### Usage

Drop the `MinecraftSolidColorMaker.exe` into the folder with the Minecraft textures you want to convert and run it. Converted textures will be placed in a `output` folder in the same location.

### Dependencies
SixLabors.ImageSharp
