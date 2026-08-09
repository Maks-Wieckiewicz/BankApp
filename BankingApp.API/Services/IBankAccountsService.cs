using BankingApp.API.Models;

namespace BankingApp.API.Services;

public interface IBankAccountsService
{
    
    // Implementing Crud here
    
    Task<List<BankAccount>> GetAllAsync();
    Task<BankAccount?> GetByIdAsync(Guid bankAccountNumber);
    Task<BankAccount> AddAsync(BankAccount account);
    Task<bool> UpdateAsync(string owner, Guid bankAccountNumber);
    Task<bool> DeleteAsync(Guid bankAccountNumber);
    
    
}   