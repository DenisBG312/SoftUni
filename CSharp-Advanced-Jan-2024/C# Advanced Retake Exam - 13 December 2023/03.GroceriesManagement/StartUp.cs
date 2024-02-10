namespace GroceriesManagement
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Initialize new repository (GroceriesStore) 
            GroceriesStore store = new(5);

            //Initialize entities (Product)
            Product apples = new("Apples", 1.20);
            Product oranges = new("Oranges", 2.80);
            Product bananas = new("Bananas", 1.50);
            Product grapes = new("Grapes", 2.20);
            Product watermelon = new("Watermelon", 1.90);

            //Add products to the store
            store.AddProduct(apples);
            store.AddProduct(oranges);
            store.AddProduct(bananas);
            store.AddProduct(grapes);
            store.AddProduct(watermelon);

            //Attempt to add a sixth product which should be skipped due to capacity
            Product cherries = new("Cherries", 5.70);
            store.AddProduct(cherries);

            //Remove existing Product
            Console.WriteLine(store.RemoveProduct("Grapes")); //True

            //Try to delete not existing Product
            Console.WriteLine(store.RemoveProduct("Pears")); //False

            //Try to add once again, if there is enough Capacity
            store.AddProduct(cherries);

            //Sell some products
            Console.WriteLine(store.SellProduct("Apples", 1.5)); //Apples = 1.80$
            Console.WriteLine(store.SellProduct("Bananas", 2.4)); //Banans = 3.60$
            Console.WriteLine(store.SellProduct("Grapes", 2)); //Product not found
            Console.WriteLine(store.SellProduct("Apples", 2.5)); //Apples = 3.00$
            Console.WriteLine(store.SellProduct("Watermelon", 15)); //Watermelon = 28.50$
            Console.WriteLine(store.SellProduct("Cherries", 0.5)); //Cherries = 2.85$

            //Get the most expensive product
            Console.WriteLine(store.GetMostExpensive()); //Cherries: 5.70$

            // Generate and display a cash report
            Console.WriteLine(store.CashReport());
            // "Total Turnover: 39.75$"

            //Display the price list
            Console.WriteLine(store.PriceList());
            // "Groceries Price List:
            // Apples: 1.20$
            // Oranges: 2.80$
            // Bananas: 1.50$
            // Watermelon: 1.90$
            // Cherries: 5.70$"

        }
    }
}