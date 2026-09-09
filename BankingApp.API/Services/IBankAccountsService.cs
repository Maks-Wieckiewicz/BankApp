using BankingApp.API.Models;
using BankingApp.API.Data;
using BankingApp.API.DTO;

namespace BankingApp.API.Services;

public interface IBankAccountsService
{
    
    // Implementing Crud here
    
    Task<List<BankAccountResponse>> GetAllAsync();
    Task<BankAccountResponse?> GetByIdAsync(Guid bankAccountNumber);
    Task<BankAccount> AddAsync(CreateBankAccountRequest request);
    
    //return updated bank account
    //Task<BankAccount> UpdateAsync(string owner, Guid bankAccountNumber);
    Task<bool> DeleteAsync(Guid bankAccountNumber);
    
    
}   