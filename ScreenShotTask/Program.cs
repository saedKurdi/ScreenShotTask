using System;
using System.Drawing;
using System.IO;

namespace ScreenShotTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Press Enter To Take Screen Shot : ");
                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    Bitmap memoryImage = new Bitmap(2300, 1300);
                    Size s = new Size(memoryImage.Width, memoryImage.Height);

                    // Create a directory to save the screenshots if it doesn't exist
                    string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Screenshots");
                    Directory.CreateDirectory(directoryPath);

                    using (Graphics memoryGraphics = Graphics.FromImage(memoryImage))
                    {
                        memoryGraphics.CopyFromScreen(0, 0, 0, 0, s);
                    }

                    // Generate a unique file name for the screenshot
                    string fileName = $"screenshot_{DateTime.Now.ToString("yyyyMMddHHmmss")}.png";
                    string filePath = Path.Combine(directoryPath, fileName);

                    // Save the screenshot as a PNG file
                    memoryImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);

                    Console.WriteLine($"\nScreenshot saved: {filePath}");

                   Thread.Sleep(500);
                }
            }
        }
    }
}
