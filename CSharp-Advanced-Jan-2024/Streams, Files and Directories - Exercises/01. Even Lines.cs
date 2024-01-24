namespace EvenLines
{
    using System;
    using System.Reflection.PortableExecutable;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string line = reader.ReadLine();
                int counter = 0;
                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        line = Replace(line);
                        line = Reverse(line);
                        Console.WriteLine(line);
                    }

                    counter++;
                    line = reader.ReadLine();
                }
            }

            return string.Empty;
        }

        private static string Reverse(string line)
        {
            string[] parts = line.Split().Reverse().ToArray();
            return string.Join(" ", parts);
        }

        private static string Replace(string line)
        {
            return line.Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("?", "@");
        }
    }
}
