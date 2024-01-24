using System.IO;

namespace CopyDirectory
{
    using System;
    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath =  @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            Directory.CreateDirectory(outputPath);
            string[] files = Directory.GetFiles(inputPath);

            foreach (string file in files)
            {
                var fileName = Path.GetFileName(file);
                var copyDestination = Path.Combine(outputPath, fileName);
                File.Copy(fileName, copyDestination);
            }
        }
    }
}
