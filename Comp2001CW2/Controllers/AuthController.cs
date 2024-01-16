using Comp2001CW2.Models;
using Microsoft.AspNetCore.Mvc;
using Comp2001CW2.Data;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly DatabaseContext _dbContext;

    public AuthController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginModel login)
    {
        if (login == null)
        {
            return BadRequest("Invalid client request");
        }

        var user = _dbContext.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);

        if (user != null)
        {
            HttpContext.Items["UserID"] = user.UserID;
            HttpContext.Items["Email"] = user.Email;
            HttpContext.Items["AdminRights"] = user.AdminRights;

            return Ok("Login successful!");
        }
        else
        {
            return Unauthorized("Incorrect login details");
        }
    }
}