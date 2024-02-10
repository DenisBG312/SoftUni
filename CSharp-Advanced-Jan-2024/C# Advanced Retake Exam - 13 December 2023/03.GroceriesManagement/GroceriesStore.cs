using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore //: IComparable<Product>
    {
        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }

        public GroceriesStore(int capacity)
        {
            Capacity = capacity;
            Turnover = 0;
            Stall = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (Capacity > 0)
            {
                if (!Stall.Contains(product))
                {
                    Stall.Add(product);
                    Capacity--;
                }
            }
        }

        public bool RemoveProduct(string name)
        {
            foreach (var stall in Stall)
            {
                string[] check = stall.ToString().Split(":");
                if (check[0] == name)
                {
                    Stall.Remove(stall);
                    Capacity++;
                    return true;
                }
            }
            return false;
        }

        public string SellProduct(string name, double quantity)
        {
            bool isFound = false;
            double productPrice = 0;
            foreach (var stall in Stall)
            {
                string[] check = stall.ToString().Split(":");
                if (check[0] == name)
                {
                    productPrice = stall.Price * quantity;
                    Turnover += stall.Price * quantity;
                    isFound = true;
                    break;
                }
            }

            if (isFound)
            {
                return $"{name} - {productPrice:F2}$".TrimEnd();
            }

            return $"Product not found".TrimEnd();
        }

        public string GetMostExpensive()
        {
            return Stall.MaxBy(x => x.Price).ToString();
        }

        public string CashReport()
        {
            return $"Total Turnover: {Turnover:f2}$".TrimEnd();
        }

        public string PriceList()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Groceries Price List:");
            foreach (var stall in Stall)
            {
                sb.AppendLine(stall.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
