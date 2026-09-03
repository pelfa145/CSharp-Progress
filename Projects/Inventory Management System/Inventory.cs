public class Inventory
{
    private List<Product> Products = new();
    private Dictionary<int, Product> prodDict = new();

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
        Products.Add(new Product(productName,
                                 category,
                                 stocks,
                                 price,
                                 id));
        prodDict.Add(id, Products[^1]);
    }
    private int generateID()
    {
        if(Products.Count == 0)
        {
            return 0001;
        }
        else
        {
            return Products[^1].id + 1;
        }
    }

    public void searchProduct()
    {
        Console.Write("Enter product id: ");
        Console.WriteLine(prodDict[int.Parse(Console.ReadLine())].printProduct());
    }
}