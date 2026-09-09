using BankingApp.API.Data;
using BankingApp.API.DTO;
using BankingApp.API.Models;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Update;

namespace BankingApp.API.Services;

public class BankAccountsService(BankDbContext context) : IBankAccountsService
{
    
  
    // Showing all caracters 
    public async Task<List<BankAccountResponse>> GetAllAsync()
    { 
        var result = await context.BankAccounts.ToListAsync();
        
        var DTO_list = result.Select(account => new BankAccountResponse
            {
                AccountId = account.AccountId,
                Balance = account.Balance, 
                Type = account.Type
            }
        ).ToList();
        
        return DTO_list;
    }
        
    
    

    public async Task<BankAccountResponse?> GetByIdAsync(Guid bankAccountNumber)
    {

        var result =  await context.BankAccounts.Where(c => c.AccountId == bankAccountNumber).FirstOrDefaultAsync();
        var response = new BankAccountResponse
        {
            AccountId = result.AccountId,
            Balance = result.Balance,
            Type = result.Type
        };
            
        return  response;
    }

    
    //
    public async Task<BankAccount> AddAsync(CreateBankAccountRequest request)
    {
        BankAccount new_account;

        if (request.Type == bankAccountType.standard)
        {
             new_account = new BankAccount(request.Name, request.InitialDeposit);
        }
        
        else
        {
             new_account = new InterestBankAccount(request.Name, request.InitialDeposit);
            
        }
        
        
         context.BankAccounts.Add(new_account);
         await context.SaveChangesAsync();
        
        return new_account;

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