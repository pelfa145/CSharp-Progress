using MySql.Data.MySqlClient;
public class InventoryRepo(Inventory inventory)
{
    static string connString = "Server=localhost;Port=3306;Database=inventory_management;User ID=root;Password=1234;";
    static MySqlConnection connection = new MySqlConnection(connString);
    public void initialize()
    {

        try
        {
            connection.Open();
            string sql = """
                        SELECT * FROM inventory;
                        """;
            using (MySqlCommand command = new MySqlCommand(sql, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Ind2");
                        inventory.insertProducts((string)reader["product_name"], (string)reader["category"], (int)reader["stock"], (double)reader["price"], (int)reader["id"]);
                    }
                }
            }
        }
        catch (MySqlException e)
        {
            Console.WriteLine($"MySQL Error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"General Error: {e.Message}");
        }

    }
    public void Save()
    {
        string sql = """
                    INSERT INTO inventory (product_name, category, stock, price, id)
                    VALUES (@name, @cat, @stock, @price, @id) 
                    ON DUPLICATE KEY UPDATE
                    product_name = @name,
                    category = @cat,
                    stock = @stock,
                    price = @price;
                    """;
        using(MySqlCommand command = new MySqlCommand(sql, connection)){
        int rowsAffected=0;
        foreach (Product i in inventory.getProducts.Values)
        {
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@name", i.productName);
            command.Parameters.AddWithValue("@cat", i.category);
            command.Parameters.AddWithValue("@stock", i.stock);
            command.Parameters.AddWithValue("@price", i.price);
            command.Parameters.AddWithValue("@id", i.id);
            rowsAffected = command.ExecuteNonQuery();
        }
        if(rowsAffected > 0)
            {
                Console.WriteLine("Saved Successfully.");
            }
        }
    }
    public void close()
    {
        connection.Close();
    }
}