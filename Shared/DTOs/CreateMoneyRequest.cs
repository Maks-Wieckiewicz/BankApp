namespace BankingApp.API.DTO;

public class CreateMoneyRequest
{
    public Guid BankAccountNumber {get; set; }
    public int Amount { get; set; }
    
}