using BankingApp.API.Models;
using BankingApp.API.Data;

namespace BankingApp.API.Services;

public interface IBankAccountsService
{
    
    // Implementing Crud here
    
    Task<List<BankAccount>> GetAllAsync();
    Task<BankAccount?> GetByIdAsync(Guid bankAccountNumber);
    Task<BankAccount> AddAsync(BankAccount account);
    
    //return updated bank account
    Task<BankAccount> UpdateAsync(string owner, Guid bankAccountNumber);
    Task<bool> DeleteAsync(Guid bankAccountNumber);
    
    
}   