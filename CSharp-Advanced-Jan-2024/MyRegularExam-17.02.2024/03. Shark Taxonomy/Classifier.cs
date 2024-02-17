using System.Text;

namespace SharkTaxonomy
{
    public class Classifier
    {
        public int Capacity { get; set; }
        public List<Shark> Species { get; set; }

        public int GetCount => Species.Count;

        public Classifier(int capacity)
        {
            Capacity = capacity;
            Species = new List<Shark>();
        }

        public void AddShark(Shark shark)
        {
            if (Capacity > Species.Count)
            {
                if (!Species.Any(x => x.Kind == shark.Kind))
                {
                    Species.Add(shark);
                }
            }
        }

        public bool RemoveShark(string kind)
        {
            Shark shark = Species.FirstOrDefault(x => x.Kind == kind);
            if (shark != null)
            {
                Species.Remove(shark);
                return true;
            }

            return false;
        }

        public string GetLargestShark()
        {
            Shark longestShark = Species.OrderByDescending(x => x.Length).First();

            return longestShark.ToString().TrimEnd();
        }

        public double GetAverageLength()
        {
            double average = Species.Average(x => x.Length);

            return average;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Species.Count} sharks classified:");
            foreach (var shark in Species)
            {
                sb.AppendLine(shark.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
