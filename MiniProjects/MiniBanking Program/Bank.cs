using System.Dynamic;

public class Bank
{
    private Dictionary<int, BankAccount> bankAccounts = new Dictionary<int, BankAccount>();
    public Dictionary<int, BankAccount> BankAccounts => bankAccounts;

    public void addBankAccount()
    {
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        int id = generateID();
        double balance = 0;

        bankAccounts.Add(id, new BankAccount(name, age, id, balance));
        Console.WriteLine("Added account");
    }
    public int generateID()
    {
        if (bankAccounts.Count == 0)
        {
            return 2026000;
        }
        else { return 2026000 + bankAccounts.Count; }
    }
    public void printAccounts()
    {
        foreach(BankAccount i in bankAccounts.Values)
        {
            Console.WriteLine("______________________________\nName: "+i.name+"\nAge: "+i.age+"\nBank Account Number: "+i.accountNumber+"\n______________________________");
        }
    }
}