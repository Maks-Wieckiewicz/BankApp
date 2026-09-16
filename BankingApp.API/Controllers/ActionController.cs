using BankingApp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ActionController(ISkipTime service) : ControllerBase
{

    [HttpPost]
    [EndpointSummary("Skip time and add interests")]
    public async Task<IActionResult> SkipTimeAsync()
    {
        await service.SkipTimeAsync();
        return Ok();
        
    }
    
    
    
}