using Microsoft.AspNetCore.Mvc;
using BankingApp.API.Models;
using BankingApp.API.Services;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BankingApp.API.DTO;

namespace BankingApp.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class AccountsController(IBankAccountsService service) : ControllerBase
{
    
    
    [HttpGet]
    [EndpointSummary("Get all accounts")]
    public async Task< ActionResult <List <BankAccountResponse>>> GetAllAsync()
    {
        var accounts = await service.GetAllAsync();
        return Ok(accounts);
    }

    [HttpGet("{bankAccountNumber}")]
    [EndpointSummary("Getting bank account by bank account number")]
    public async Task<ActionResult<BankAccountResponse>> GetBankAccountById(Guid bankAccountNumber)
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
    public async Task<ActionResult<BankAccount>> AddAsync(CreateBankAccountRequest request)
    {
        
        
        if (request == null)
        {
            return BadRequest();
        }
        
        var createdAccount = await service.AddAsync(request);
        return CreatedAtAction(nameof(GetBankAccountById), new{bankAccountNumber = createdAccount.AccountId},  createdAccount);
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