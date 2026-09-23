using System.ComponentModel.DataAnnotations;
using Shared.Enums;


namespace Shared.DTOs;


public class CreateBankAccountRequest
{
    // What we need: Name, AccountType, InitialDeposit 
    [Required]
    public string Name { get; set; }
    public decimal InitialDeposit { get; set; }
    public AccountType Type {get; set; }
    
    
}