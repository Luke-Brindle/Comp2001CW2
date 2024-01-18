using Comp2001CW2.Models;
using Microsoft.AspNetCore.Mvc;
using Comp2001CW2.Data;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly DatabaseContext _dbContext;
    private readonly HttpClient _httpClient;

    public AuthController(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _httpClient = new HttpClient();
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {
        if (login == null)
        {
            return BadRequest("Invalid client request");
        }

        string apiString = "https://web.socem.plymouth.ac.uk/COMP2001/auth/api/users";
        string loginDetails = Newtonsoft.Json.JsonConvert.SerializeObject(login);
        var stringContent = new StringContent(loginDetails, Encoding.UTF8, "application/json");

        HttpResponseMessage apiResponse = await _httpClient.PostAsync(apiString, stringContent).ConfigureAwait(false);

        var user = _dbContext.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
        string apiData = await apiResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

        if (user != null)
        {
            HttpContext.Session.SetInt32("UserID", user.UserID);
            HttpContext.Session.SetInt32("AdminRights", user.AdminRights ? 1 : 0);

            if (apiData.Contains("True"))
            {
                return Ok("Login successful! Account Authenticated");
            }
            else
            {
                return Ok("Login successful! Account Unauthenticated");
            }
        }
        else
        {
            return Unauthorized("Incorrect login details");
        }
    }


    [HttpPost("LogOut")]
    public async Task<IActionResult> LogOut()
    {
        HttpContext.Session.SetInt32("UserID", -1);
        HttpContext.Session.SetInt32("AdminRights", -1);
        return Ok("Logged Out");
    }


}