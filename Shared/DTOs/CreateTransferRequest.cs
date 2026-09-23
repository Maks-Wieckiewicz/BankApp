namespace Shared.DTOs;

public class CreateTransferRequest
{
    // accound ID from ,account ID to, value
    public Guid TransferFrom { get; set; }
    public Guid TransferTo { get; set; }
    public decimal Amount { get; set; }
    
}