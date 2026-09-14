using BankingApp.API.DTO;
using BankingApp.API.Services;

namespace BankingApp.API.Controllers;
using Microsoft.AspNetCore.Mvc;


[Route("api/[controller]")]
[ApiController]

public class TransfersController(ITransfersService service) : ControllerBase
{
    
    [HttpPost]
    [EndpointSummary("Transfer money")]
    public async Task< ActionResult > TransfersAsync(CreateTransferRequest request)
    {
        var isTransfer = await service.TransferAsync(request);
        
        if (!isTransfer)
        {
            return BadRequest("Not enough money");
        }
        return Ok();
    }
    
    
    
}