using BankingApp.API.Data;
using BankingApp.API.Models;
using BankingApp.API.DTO;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.API.Services;

public class SkipTimeService(BankDbContext context) : ISkipTime
{
    public async Task<bool> SkipTimeAsync()
    {
        //Implementing method from savings class
        

       var savingsAccounts = await context.BankAccounts.OfType<InterestBankAccount>().ToListAsync();

       if (!savingsAccounts.Any())
       {
           return false;
       }
       

       foreach (var account in savingsAccounts)
       {
           account.CountInterests();
           
       }
       await context.SaveChangesAsync();
       return true;
       
    }
}