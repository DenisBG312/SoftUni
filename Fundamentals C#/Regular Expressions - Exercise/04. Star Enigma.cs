using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    internal class Program
    {
        class Message
        {
            public string PlanetName { get; set; }
            public int Population { get; set; }
            public string AttackType { get; set; }
            public int SoliderCount { get; set; }
        }

        static void Main(string[] args)
        {
            int messageCount = int.Parse(Console.ReadLine());
            List<Message> messages = new List<Message>();

            string pattern = @"[sStTaArR]";

            string msgPattern = @"\@(?<Planet>[A-Za-z]+)[^\@\-\!\:\>]*\:(?<Population>\d+)[^\@\-\!\:\>]*\!(?<Type>[AD])\![^\@\-\!\:\>]*\-\>(?<Soldiers>\d+)";

            for (int i = 0; i < messageCount; i++)
            {
                string encryptMsg = Console.ReadLine();

                int decryptionKey = Regex.Matches(encryptMsg, pattern).Count;

                StringBuilder msgBuilder = new StringBuilder();
                for (int j = 0; j < encryptMsg.Length; j++)
                {
                    msgBuilder.Append((char)(encryptMsg[j] - decryptionKey));
                }

                string decryptedMessage = msgBuilder.ToString();

                Match match = Regex.Match(decryptedMessage, msgPattern);

                if (!match.Success)
                {
                    continue;
                }

                Message message = new Message();
                message.PlanetName = match.Groups["Planet"].Value;
                message.Population = int.Parse(new string(match.Groups["Population"].Value.Where(char.IsDigit).ToArray()));
                message.AttackType = match.Groups["Type"].Value;
                message.SoliderCount = int.Parse(new string(match.Groups["Soldiers"].Value.Where(char.IsDigit).ToArray()));

                messages.Add(message);
            }

            var filteredAttackedMessages = messages
                .Where(m => m.AttackType == "A")
                .OrderBy(m => m.PlanetName)
                .ToList();

            Console.WriteLine($"Attacked planets: {filteredAttackedMessages.Count}");
            filteredAttackedMessages.ForEach(m => Console.WriteLine($"-> {m.PlanetName}"));

            var filteredDestroyedMessages = messages
                .Where(m => m.AttackType == "D")
                .OrderBy(m => m.PlanetName)
                .ToList();

            Console.WriteLine($"Destroyed planets: {filteredDestroyedMessages.Count}");
            filteredDestroyedMessages.ForEach(m => Console.WriteLine($"-> {m.PlanetName}"));
        }
    }
}
