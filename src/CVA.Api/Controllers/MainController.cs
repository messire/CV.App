using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CVA.Api;

[ApiController]
[AllowAnonymous]
public class MainController: ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<HttpStatusCode>> CreateUserAsync([FromBody] UserDto userDto)
    {
        await Task.FromResult("Hello World!");
        return new ActionResult<HttpStatusCode>(HttpStatusCode.OK);
    }
}