using BankingApp.API.DTO;

namespace BankingApp.API.Models;
using System.ComponentModel.DataAnnotations;
public enum bankAccountType

{
    standard ,
    saving
        
}
public class BankAccount
{
    // jak na moje tutaj powinnismy dodac konstruktor zeby nie tworzyc klas widmo
    [Required]
    public string Name { get; init; }
    
    [Key]
    public Guid AccountId { get; private set; }
    public decimal Balance { get; protected set; }
    
    public bankAccountType Type { get; protected set; }

    public decimal InterestRate {get; protected set; } 
    

    public BankAccount(string name, decimal balance = 0)
    {
        Name = name;
        AccountId = Guid.NewGuid();
        Balance = balance;
        Type = bankAccountType.standard;
        InterestRate = 0;
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