namespace _06._Store_Boxes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Box> boxes = new List<Box>();
            while ((input = Console.ReadLine()) != "end")
            {
                string[] token = input.Split();
                string serialNumber = token[0];
                string itemName = token[1];
                int itemQuantity = int.Parse(token[2]);
                decimal itemPrice = decimal.Parse(token[3]);

                Item item = new Item()
                {
                    Name = itemName,
                    Price = itemPrice,
                };

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    Item = item,
                    ItemQuantity = itemQuantity,
                    PriceForBox = itemPrice * itemQuantity
                };
                boxes.Add(box);
            }

            foreach (Box box in boxes.OrderByDescending(e => e.PriceForBox))
            {
                //{boxSerialNumber}
                // -- {boxItemName} – ${boxItemPrice}: {boxItemQuantity}
                // -- ${boxPrice}
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForBox:f2}");
            }
        }
    }

    class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }

        public int ItemQuantity { get; set; }
        public decimal PriceForBox { get; set; }
    }
    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

    }
}
