class Program
{
    public static Inventory inventory = new(); 
    public static InventoryRepo inventoryRepo = new(inventory);
    static void Main(string[] args)
    {
        showMenu();
    }
    static void showMenu()
    {
        inventoryRepo.initialize();
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("=== INVENTORY SYSTEM ===\n\n1. Add Product\n2. Remove Product\n3. Search Products\n4. View All Products\n5. Restock Products\n6. Sell Product\n7. Exit");
            Console.Write("Enter your choice: ");
            switch (int.Parse(Console.ReadLine()!))
            {
                case 1: 
                    inventory.addProduct();
                    inventoryRepo.Save();
                    break;
                case 2: 
                    inventory.removeProduct();
                    inventoryRepo.Save();
                    break;
                case 3: 
                    inventory.searchProduct();
                    break;
                case 4:
                    inventory.viewListOfItems();
                    break;
                case 5:
                    inventory.restockProducts();
                    inventoryRepo.Save();
                    break;
                case 6:
                    inventory.sellStocks();
                    inventoryRepo.Save();
                    break;
                case 7:
                    quit = true;
                    inventoryRepo.Save();
                    break;
                default:
                    Console.WriteLine("Choose an option between 1-7.");
                    break;
            }
        }
        inventoryRepo.close();
    }
}