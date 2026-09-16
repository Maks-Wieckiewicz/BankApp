using BankingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.API.Controllers;


[ApiController]
[Route("api/[controller]")]

public class ActionController(ISkipTime service) : ControllerBase
{

    [HttpPost("add-interests")]
    [EndpointSummary("Skip time and add interests")]
    public async Task<IActionResult> SkipTimeAsync()
    {
        var result = await service.SkipTimeAsync();
        if (!result)
        {
            return NotFound("Account not found");
        }
        
        return Ok();
        
    }
    
    
    
}