using BankingApp.API.DTO;

namespace BankingApp.API.Services;

public interface ITransfersService
{
    Task<bool> TransferAsync(CreateTransferRequest request);
    
}