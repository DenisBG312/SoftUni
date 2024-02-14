namespace ClothesMagazine
{
    public class Cloth
    {
        public string Color { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }

        public Cloth(string color, int size, string type)
        {
            Color = color;
            Size = size;
            Type = type;
        }

        public override string ToString()
        {
            return $"Product: {Type} with size {Size}, color {Color}";
        }
    }
}
