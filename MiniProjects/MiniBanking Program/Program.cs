using System.ComponentModel;

class Program
{
    static void Main(String[] args)
    {
        showMenu();
    }

    static Bank bank = new Bank();
    static void showMenu()
    {
        bool quit = false;
        while (!quit)
        {
            Console.WriteLine("Banking Program\n\n1.Create Account\n2.Select Account\n3.Print Accounts\n4.Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    bank.addBankAccount();
                    break;
                case 2:
                    Console.Write("Enter account ID: ");
                    showAccountMenu(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    bank.printAccounts();
                    break;
                case 4:
                    quit = true;
                    break;
                default:
                    break;
            }
        }
    }
    static void showAccountMenu(int accountID)
    {
        try 
        {
            BankAccount i = bank.BankAccounts[accountID];
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("==Account " + i.accountNumber + "===\n\n1.Deposit\n2.Withdraw\n3.Show Balance\n4.Exit\n");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        i.deposit(askUserAmount());
                        break;
                    case 2:
                        i.withdraw(askUserAmount());
                        break;
                    case 3:
                        Console.WriteLine("Balance: "+i.balance+"$");
                        break;
                    case 4:
                        quit = true;
                        return;
                    default:
                        break;
                }
            }
        } 
        catch (Exception) 
        { 
            Console.WriteLine("Account not found."); 
        }
        {
            
        }

    }
    static double askUserAmount()
    {
        Console.Write("Enter an amount: ");
        return double.Parse(Console.ReadLine());
    }
}