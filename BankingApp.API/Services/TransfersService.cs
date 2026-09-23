using Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BankingApp.API.Services;
using BankingApp.API.Data;

public class TransfersService(BankDbContext context) : ITransfersService
{
    public async Task<bool> TransferAsync(CreateTransferRequest request)
    {
        //need to find a user by id - needed balance of both users
        var receiver_account = await context.BankAccounts.FirstOrDefaultAsync(a => a.AccountId == request.TransferTo);
        var sender_account = await context.BankAccounts.FirstOrDefaultAsync(a => a.AccountId == request.TransferFrom);
        
        if(sender_account == null || receiver_account == null)
            throw new Exception("Account not found");
        
        if (sender_account.Balance < request.Amount)
        {
            return false;
        }
        
        sender_account.Withdraw(request.Amount);
        receiver_account.Deposit(request.Amount);
        
        await context.SaveChangesAsync();
        
        return true;
    }

  
    
    public async Task<bool> DepositAsync(CreateMoneyRequest request)
    {
        
        var account = await context.BankAccounts.FirstOrDefaultAsync(a => a.AccountId == request.BankAccountNumber);

        if (account == null)
        {
            return false;
            
        }
        account.Deposit(request.Amount);
        await context.SaveChangesAsync();

        return true;
        
    }

    public async Task<bool> WithdrawAsync(CreateMoneyRequest request)
    {
        var account = await context.BankAccounts.FirstOrDefaultAsync(a => a.AccountId == request.BankAccountNumber);

        if (account == null)
        {
            throw new Exception("Account not found");
        }

        if (account.Balance < request.Amount)
        {
            return false;
        }
        
        account.Withdraw(request.Amount);
        await context.SaveChangesAsync();
        
        return true;
        
        
    }
}