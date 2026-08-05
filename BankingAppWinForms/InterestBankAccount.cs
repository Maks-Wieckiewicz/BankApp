namespace BankingAppWinForms;

public class InterestBankAccount : BankAccount
{
    //public decimal InterestRate { get; private set; }
    
    public InterestBankAccount(string name) : base(name)
    {
        // Interest rate is constant at the first place but bank can change it later 
        Type = bankAccountType.saving;
        InterestRate = 2;
    }

    public void CountInterests()
    {
        if (Balance > 0)
        {
            decimal InterestAmount = Decimal.Round(((InterestRate / 100) * Balance), 2);
            Balance += InterestAmount;
        }
        
    }
    
    
    // Public method which allows to change interest rate
    public void ChangeInterest(decimal new_interest)
    {
        InterestRate = new_interest;
    }
    
    
}