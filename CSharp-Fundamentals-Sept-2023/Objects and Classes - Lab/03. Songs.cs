using System.Threading.Channels;

namespace _03._Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> songsList = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split("_");
                string typeList = inputs[0];
                string name = inputs[1];
                string time = inputs[2];

                Song song = new Song();
                song.TypeList = typeList;
                song.Name = name;
                song.Time = time;

                songsList.Add(song);
            }

            string typeListChosen = Console.ReadLine();
            if (typeListChosen == "all")
            {
                foreach (var song in songsList)
                {
                    Console.WriteLine(song.Name);
                }
            }
            else
            {
                foreach (var song in songsList)
                {
                    if (song.TypeList == typeListChosen)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }

        public class Song
        {
            public string TypeList { get; set; }
            public string Name { get; set; }
            public string Time { get; set; }
        }
    }
}
