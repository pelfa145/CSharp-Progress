public class BankAccount
{
    public string name {get;private set;}
    public int age {get;private set;}
    public int accountNumber{get;private set;}
    public double balance{get;private set;}

    public BankAccount(string name, int age, int accountNumber, double balance)
    {
        this.name = name;
        this.age = age;
        this.accountNumber = accountNumber;
        this.balance = balance;
    }

    public void deposit(double amount)
    {
        balance += amount;
    }
    public void withdraw(double amount)
    {
         if(balance > amount)
        {
            balance -= amount;
        }
    }
}