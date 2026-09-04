class Product
{
    public string productName{get;private set;}
    public string category{get;set;}
    public int stock{get; set;}
    public double price{get;private set;}
    public int id {get;}

    public Product(string productName, string category, int stock, double price, int id)
    {
        this.productName = productName;
        this.category = category;
        this.stock = stock;
        this.price = price;
        this.id = id;
    }

    public string printProduct()
    {
        return "Product ID: "+this.id+"\nProduct: "+this.productName+"\nCategory: "+this.category+"\nStock: "+this.stock+"\nPrice: "+this.price+"$\n";
    }

    public void buy(int AmountOfNewStocks)
    {
        stock += AmountOfNewStocks;
    }
    public void sell(int AmountOfSelled)
    {
        stock -= AmountOfSelled;
    }
    public string listProduct()
    {
        return id+"|"+productName+"|"+category+"|"+stock+"|"+price+"$|";
    }
}