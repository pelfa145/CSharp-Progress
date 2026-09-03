public class Inventory
{
    private List<Product> Products = new();

    public void addProduct()
    {
        Products.Add(new Product("Mechanical Keyboard", "Peripherals", 128, 30.99, 001));
        
    }
}