using Microsoft.AspNetCore.Mvc;
using BankingApp.API.Models;
using BankingApp.API.Services;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingApp.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AccountsController(IBankAccountsService service) : ControllerBase
{
    
    
    [HttpGet]
    [EndpointSummary("Get all accounts")]
    public async Task< ActionResult <List <BankAccount>>> GetAllAsync()
    {
        return  await Task.FromResult(Ok(service.GetAllAsync())) ;
    }

    [HttpGet("{bankAccountNumber}")]
    [EndpointSummary("Getting bank account by bank account number")]
    public async Task<ActionResult<BankAccount>> GetBankAccountById(Guid bankAccountNumber)
    {
        var bankAccount = await service.GetByIdAsync(bankAccountNumber);
        if (bankAccount == null)
        {
            return NotFound();
        }
        return Ok(bankAccount);
        
    }

    [HttpPost]
    [EndpointSummary("Adding new account")]
    public async Task<ActionResult<BankAccount>> AddAsync(BankAccount account)
    {
        if (account == null)
        {
            return BadRequest();
        }
        
        var createdAccount = await service.AddAsync(account);
        return CreatedAtAction(nameof(GetBankAccountById), new{bankAccountNumber = createdAccount.AccountId},  account);
    }
    // Implement upadate method
    [HttpPut("{bankAccountNumber}")]
    [EndpointSummary("Updating bank account")]
    public async Task<ActionResult> UpdateAsync(Guid bankAccountNumber, [FromBody] string newOwner)
    {
        if (string.IsNullOrEmpty(newOwner))
        {
            return BadRequest("New owner is required");
        }
        
        var isUpdated = await service.UpdateAsync(newOwner, bankAccountNumber);
        if (!isUpdated)
        {
            return NotFound();
        }
        
        return NoContent();
        
    }

    [HttpDelete("{bankAccountNumber}")]
    [EndpointSummary("Deleting bank account")]
    public async Task<ActionResult> DeleteAsync(Guid bankAccountNumber)
    {
        var isDeleted = await service.DeleteAsync(bankAccountNumber);

        if (!isDeleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
}