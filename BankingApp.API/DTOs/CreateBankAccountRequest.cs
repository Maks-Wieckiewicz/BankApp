using System.ComponentModel.DataAnnotations;
using BankingApp.API.Models;

namespace BankingApp.API.DTO;


public class CreateBankAccountRequest
{
    // What we need: Name, AccountType, InitialDeposit 
    [Required]
    public string Name { get; set; }
    public decimal InitialDeposit { get; set; }
    public bankAccountType Type {get; set; }
    
    
}