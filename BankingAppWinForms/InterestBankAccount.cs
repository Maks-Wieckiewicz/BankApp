namespace BankingAppWinForms;

public class InterestBankAccount : BankAccount
{
    public decimal InterestRate { get; private set; }
    
    

    public InterestBankAccount(string name, decimal interests) : base(name + $"(Saving({interests}))")
    {
        InterestRate = interests;
    }
    
    public override void Deposit(decimal amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount cannot be negative");
        }

        if (amount > 10000)
        {
            throw new InvalidOperationException("Amount must be less than 10000");
        }
        
        decimal interestAmount = amount  * InterestRate;
        Balance += amount;
    }
    
    
}