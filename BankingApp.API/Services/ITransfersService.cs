using Shared.DTOs;

namespace BankingApp.API.Services;

public interface ITransfersService
{
    Task<bool> TransferAsync(CreateTransferRequest request);
    //Adding new method to deposit and withdraw money
    Task<bool> DepositAsync(CreateMoneyRequest request);
    
    Task<bool> WithdrawAsync(CreateMoneyRequest request);
    

}