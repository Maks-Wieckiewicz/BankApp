using BankingApp.API.DTO;
using BankingApp.API.Services;

namespace BankingApp.API.Controllers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]


public class TransfersController(ITransfersService service) : ControllerBase
{
    
    [HttpPost("transfer")]
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

    [HttpPost("deposit")]
    [EndpointSummary("Deposit credit")]
    public async Task<ActionResult> DepositAsync(CreateMoneyRequest request)
    {
        var isTransfer = await service.DepositAsync(request);

        if (!isTransfer)
        {
            return NotFound("Account not found");
        }
        return Ok("Money successfully transferred");
    }

    [HttpPost("withdraw")]
    [EndpointSummary("Withdraw credit")]
    public async Task<ActionResult> WithdrawAsync(CreateMoneyRequest request)
    {
        var isTransfer = await service.WithdrawAsync(request);
        if (!isTransfer)
        {
            return BadRequest("Not enough money ");
        }
        
        return Ok("Money successfully transferred");
        
    }



}