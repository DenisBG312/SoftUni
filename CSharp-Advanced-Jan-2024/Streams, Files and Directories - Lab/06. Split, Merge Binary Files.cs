using System;
using System.IO;
using System.Linq;

namespace SplitMergeBinaryFile
{
    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            using (FileStream sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                long fileSize = sourceFile.Length;
                int partSize = (int)Math.Ceiling(fileSize / 2.0);

                using (FileStream partOneFile = new FileStream(partOneFilePath, FileMode.Create))
                using (FileStream partTwoFile = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead;
                    int totalBytesWritten = 0;

                    while ((bytesRead = sourceFile.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        if (totalBytesWritten + bytesRead <= partSize)
                        {
                            partOneFile.Write(buffer, 0, bytesRead);
                        }
                        else
                        {
                            int remainingBytes = partSize - totalBytesWritten;
                            partOneFile.Write(buffer, 0, remainingBytes);
                            partTwoFile.Write(buffer, remainingBytes, bytesRead - remainingBytes);
                        }

                        totalBytesWritten += bytesRead;
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (FileStream partOneFile = new FileStream(partOneFilePath, FileMode.Open))
            using (FileStream partTwoFile = new FileStream(partTwoFilePath, FileMode.Open))
            using (FileStream joinedFile = new FileStream(joinedFilePath, FileMode.Create))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = partOneFile.Read(buffer, 0, buffer.Length)) > 0)
                {
                    joinedFile.Write(buffer, 0, bytesRead);
                }

                while ((bytesRead = partTwoFile.Read(buffer, 0, buffer.Length)) > 0)
                {
                    joinedFile.Write(buffer, 0, bytesRead);
                }
            }
        }
    }
}
