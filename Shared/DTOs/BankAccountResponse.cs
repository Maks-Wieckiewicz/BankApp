using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.DTOs;

public class BankAccountResponse
{
    [Required]
    public string Name { get; set; }
    public Guid AccountId { get; set; }
    public decimal Balance { get; set; }
    public AccountType Type { get; set; }
    
}