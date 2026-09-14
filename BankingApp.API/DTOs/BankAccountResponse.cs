using System.ComponentModel.DataAnnotations;
using BankingApp.API.Models;

namespace BankingApp.API.DTO;

public class BankAccountResponse
{
    [Required]
    public string Name { get; set; }
    public Guid AccountId { get; set; }
    public decimal Balance { get; set; }
    public bankAccountType Type { get; set; }
    
}