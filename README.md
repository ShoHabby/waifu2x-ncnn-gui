# Waifu2x NCNN Gui

This is a simple cross-platform GUI for interacting with [Waifu2x NCNN](https://github.com/nihui/waifu2x-ncnn-vulkan).
The application is developped with Avalonia on .NET 9.0 and is published for win-x64, linux-x64, osx-x64, and osx-arm64.
I do not have a test setup for the Linux and OSX version, so bugs and other issues may be present.

![image](https://github.com/user-attachments/assets/047b68fe-7e2c-4468-8095-5ffd1a04425d)

## Usage
The GUI exposes mostly the same settings as the CLI tool:
- Input and output paths, either a file or a folder
- Scale factor
- Denoise level
- Output file format
- Thread counts for decode/upscale/encode
- TTA Mode
- Additionally, converting files to 8bpp grayscale after upscale has been added with ImageMagick

What is not supported currently:
- Setting model paths
- Setting the GPU ID
- Setting the tile size

Support for these may be added upon request.

## Dependencies
- [GroupBox.Avalonia](https://github.com/BinToss/GroupBox.Avalonia)
- [HanumanInstitude.MvvmDialogs](https://github.com/mysteryx93/HanumanInstitute.MvvmDialogs)
- [Magick.NET](https://github.com/dlemstra/Magick.NET?tab=Apache-2.0-1-ov-file)
