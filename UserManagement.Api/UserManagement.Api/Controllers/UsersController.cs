using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult GetUsers()
    {
        return Ok("Only Admin can access this");
    }

    [HttpGet("profile")]
    [Authorize]
    public IActionResult Profile()
    {
        return Ok(User.Identity!.Name);
    }
}
