using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.API.Services;

public class BankAccountsService(DbContext context) : IBankAccountsService
{
    
    static List<BankAccount> bankAccounts = new List<BankAccount>
    {
        new BankAccount("maciek") ,
        new BankAccount("marcin"),
        new BankAccount("michael")
    };
    
    
    public async Task<List<BankAccount>> GetAllAsync()
        => await Task.FromResult(bankAccounts);
    
    

    public async Task<BankAccount?> GetByIdAsync(Guid bankAccountNumber)
    {

        var result = bankAccounts.FirstOrDefault(b => b.AccountId == bankAccountNumber);
        return await Task.FromResult(result);

        // throw new NotImplementedException();
    }

    public Task<BankAccount> AddAsync(BankAccount account)
    {
        bankAccounts.Add(account);
        return Task.FromResult(account);
    }

    public Task<bool> UpdateAsync(string newOwner, Guid bankAccountNumber)
    {
        var temp = false;
        for (var i = 0; i < bankAccounts.Count; i++)
        {
            if(bankAccounts[i].AccountId == bankAccountNumber)
            {
                temp = true;
                //account.AccountId = bankAccounts[i].AccountId;
                // replacing account in a list 
                
                bankAccounts[i].ChangeOwner(newOwner);
                break;
            }
            
                
        }
        return Task.FromResult(temp);
        
        
        //throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid bankAccountNumber)
    {
        var accountToRemove = bankAccounts.FirstOrDefault(b => b.AccountId == bankAccountNumber);

        if (accountToRemove == null)
        {
            return Task.FromResult(false);
        }
        bankAccounts.Remove(accountToRemove);
        
        return Task.FromResult(true);
        
    }
}