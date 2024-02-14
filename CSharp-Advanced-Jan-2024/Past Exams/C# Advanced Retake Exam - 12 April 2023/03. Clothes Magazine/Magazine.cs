using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClothesMagazine
{
    public class Magazine
    {
        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; private set; }

        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new List<Cloth>();
        }

        public void AddCloth(Cloth cloth)
        {
            if (Clothes.Count < Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            Cloth cloth = Clothes.FirstOrDefault(x => x.Color == color);
            if (cloth == null)
            {
                return false;
            }

            return Clothes.Remove(cloth);
        }

        public Cloth GetSmallestCloth()
        {
            return Clothes.MinBy(x => x.Size);
        }

        public Cloth GetCloth(string color)
        {
            return Clothes.Find(x => x.Color == color);
        }

        public int GetClothCount()
        {
            return Clothes.Count;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Type} magazine contains:");
            foreach (var cloth in Clothes
                         .OrderBy(x => x.Size))
            {
                sb.AppendLine(cloth.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
