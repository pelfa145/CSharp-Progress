class Product
{
    public string productName{get;private set;}
    public string category{get;set;}
    public int stock{get;private set;}
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

}