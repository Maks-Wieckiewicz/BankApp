namespace BankingAppWinForms;

public class BankAccount
{
    // jak na moje tutaj powinnismy dodac konstruktor zeby nie tworzyc klas widmo
    public string Name { get; private set; }
    public Guid AccountId { get; private set; }
    public decimal Balance { get; protected set; }

    public BankAccount(string name)
    {
        Name = name;
        AccountId = Guid.NewGuid();
        Balance = 0;
    }

    public virtual void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        if (amount > 10000)
        {
            throw new InvalidOperationException("Amount must be less than 10000");
        }
        
        
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {

        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        if (amount > Balance)
        {
            throw new InvalidOperationException("Amount can't be greater than Balance");
        }
        
        Balance -= amount;
    }
    
    
    
}