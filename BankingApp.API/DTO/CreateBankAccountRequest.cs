using System.ComponentModel.DataAnnotations;

namespace BankingApp.API.DTO;

public enum AccountType
{
    standard ,
    saving
}
public class CreateBankAccountRequest
{
    // What we need: Name, AccountType, InitialDeposit 
    [Required]
    public string Name { get; set; }
    public decimal InitialDeposit { get; set; }
    public AccountType Type {get; set; }
    
    
}