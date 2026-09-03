public class Inventory
{
    private Dictionary<int, Product> Products = new();

    public void addProduct()
    {
        Console.Write("Enter product name: ");
        string productName = Console.ReadLine();
        Console.Write("Enter product category: ");
        string category = Console.ReadLine();
        Console.Write("Enter how much stock this product has: ");
        int stocks = int.Parse(Console.ReadLine());
        Console.Write("How much is this: ");
        double price = double.Parse(Console.ReadLine());
        int id = generateID();
        Products.Add(id, new Product(productName,
                                 category,
                                 stocks,
                                 price,
                                 id));
    }
    private int generateID()
    {
        if(Products.Count == 0)
        {
            return 1000;
        }
        else
        {
            return Products[Products.Count].id + 1;
        }
    }

    public void searchProduct()
    {
        Console.Write("Enter product id: ");
        Console.WriteLine(Products[int.Parse(Console.ReadLine())].printProduct());
    }
}