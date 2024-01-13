namespace _03._Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();

            string fileName = string.Empty;
            string fileExtension = string.Empty;

            int fileNameIndex = filePath.LastIndexOf('\\');
            int fileExtensionIndex = filePath.LastIndexOf('.');

            if (fileNameIndex != -1 &&
                fileExtensionIndex != -1 &&
                fileExtensionIndex > fileNameIndex)
            {
                fileName = filePath.Substring(fileNameIndex + 1,
                    fileExtensionIndex - fileNameIndex - 1);
                fileExtension = filePath.Substring(fileExtensionIndex + 1);
            }

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
