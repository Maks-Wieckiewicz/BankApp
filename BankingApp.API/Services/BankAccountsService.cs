using BankingApp.API.Data;
using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Update;

namespace BankingApp.API.Services;

public class BankAccountsService(BankDbContext context) : IBankAccountsService
{
    
  
    // Showing all caracters 
    public async Task<List<BankAccount>> GetAllAsync()
    { 
        var result = await context.BankAccounts.ToListAsync();
        return result;
    }
        
    
    

    public async Task<BankAccount?> GetByIdAsync(Guid bankAccountNumber)
    {

        var result =  await context.BankAccounts.Where(c => c.AccountId == bankAccountNumber).FirstOrDefaultAsync();
        return  result;
    }

    
    //
    public async Task<BankAccount> AddAsync(BankAccount account)
    {
        BankAccount new_account = new BankAccount(account.Name, account.Balance);
        
         context.BankAccounts.Add(new_account);
         await context.SaveChangesAsync();
        
        return new_account;

    }
    // Update account
    public async Task<BankAccount> UpdateAsync(string newOwner, Guid bankAccountNumber)
    {
        
        // User can only change Name
        var entity = await context.BankAccounts.FindAsync(bankAccountNumber);
        
        if (entity == null)
        {
            return entity;
        }
        
        entity.UpdateName(newOwner);
        await context.SaveChangesAsync();
        return entity;
        
    }

    public async Task<bool> DeleteAsync(Guid bankAccountNumber)
    {
        var accountToRemove = await context.BankAccounts.Where(b => b.AccountId == bankAccountNumber).FirstOrDefaultAsync();
        
        if (accountToRemove == null)
        {
            return false;
        }
        context.BankAccounts.Remove(accountToRemove);
        await context.SaveChangesAsync();
        
        return true;
         
    }
}