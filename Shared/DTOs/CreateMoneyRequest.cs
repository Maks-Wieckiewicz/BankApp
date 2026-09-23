namespace Shared.DTOs;

public class CreateMoneyRequest
{
    public Guid BankAccountNumber {get; set; }
    public decimal Amount { get; set; }
    
}