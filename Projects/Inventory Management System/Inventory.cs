public class Inventory
{
    private Dictionary<int, Product> Products = new();
    public Dictionary<int, Product> getProducts => Products;
    

    public void addProduct()
    {
        Console.Write("Enter product name: ");
        string? productName = Console.ReadLine()!;
        Console.Write("Enter product category: ");
        string? category = Console.ReadLine()!;
        Console.Write("Enter how much stock this product has: ");
        int stocks = int.Parse(Console.ReadLine()!);
        Console.Write("How much is this: ");
        double price = double.Parse(Console.ReadLine()!);
        int id = generateID();
        Products.Add(id, new Product(productName,
                                 category,
                                 stocks,
                                 price,
                                 id));
    }
    public void insertProducts(string prodName, string category, int stocks, double price, int id)
    {
        Products.Add(id, new Product(prodName, category, stocks, price, id));
        Console.WriteLine("Ind1");
    }
    private int generateID()
    {
        if (Products.Count == 0)
        {
            return 100000;
        }
        else
        {
            return Products.Keys.Max() + 1;
        }
    }

    public void searchProduct()
    {
        bool done;
        do
        {
            try
            {
                Console.Write("Enter product id(Enter '-1' to exit): ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input. Please enter a valid whole number:");
                }
                if (id == -1)
                {
                    return;
                }
                Console.WriteLine(Products[id].printProduct());
                done = true;
            }
            catch (KeyNotFoundException) { done = false; }
        } while (!done);
    }
    public void removeProduct()
    {
        Console.Write("Enter product id: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid input. Please enter a valid whole number:");
        }
        bool done;
        do
        {
            if (Products.Remove(id)) { done = true; }
            else
            {
                Console.WriteLine("Product not found.");
                done = false;
                Console.Write("Enter product id(Type '-1' to quit): ");
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input. Please enter a valid whole number:");
                }
                if (id == -1) { return; }
            }
        } while (!done);
    }
    public void viewListOfItems()
    {
        Console.WriteLine("=============================================\nID|PRODUCT NAME|PRODUCT CATEGORY|STOCKS|PRICE");
        foreach (Product product in Products.Values)
        {
            Console.WriteLine(product.listProduct());
        }
        Console.WriteLine("=============================================");

    }
    public void restockProducts()
    {
        bool done;
        do
        {
            try
            {
                Console.Write("Enter product id(Enter '-1' to exit): ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input. Please enter a valid whole number:");
                }
                
                if (id == -1)
                {
                    return;
                }
                Console.Write("Enter amount of stocks to add: ");
                int stocks = int.Parse(Console.ReadLine()!);
                Products[id].buy(stocks);
                done = true;
            }
            
            catch (KeyNotFoundException) { done = false; }
        } while (!done);
    }
    public void sellStocks()
    {
        bool done;
        do
        {
            try
            {
                Console.Write("Enter product id(Enter '-1' to exit): ");
                int id;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input. Please enter a valid whole number:");
                }
                
                if (id == -1)
                {
                    return;
                }
                Console.Write("Enter amount of stocks to sell: ");
                int stocks = int.Parse(Console.ReadLine()!);
                if(stocks > Products[id].stock)
                {
                    Console.WriteLine("Exceeded current stocks.");
                    Console.WriteLine("Selling all.");
                    Products[id].stock = 0;
                    return;
                }
                Products[id].sell(stocks);
                
                done = true;
            }
            
            catch (KeyNotFoundException) { done = false; }
        } while (!done);
    }
}