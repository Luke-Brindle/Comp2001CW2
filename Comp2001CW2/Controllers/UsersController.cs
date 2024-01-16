using Comp2001CW2.Models;
using Microsoft.AspNetCore.Mvc;
using Comp2001CW2.Data;

namespace Comp2001CW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public UsersController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("ActiveUsers")]
        public IActionResult GetActiveUsers()
        {
            try
            {
                var activeUsers = _dbContext.ActiveUsersView.ToList();
                return Ok(activeUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("ArchivedAccounts")]
        public IActionResult ArchivedAccounts()
        {
            try
            {
                var archivedUsers = _dbContext.ArchivedAccounts.ToList();
                return Ok(archivedUsers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("ActiveUsersFavouriteActivities")]
        public IActionResult ActiveUsersFavouriteActivities()
        {
            try
            {
                var usersActivities = _dbContext.ActiveUsersFavouriteActivities.ToList();
                return Ok(usersActivities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("RegionBreakdown")]
        public IActionResult RegionBreakdown()
        {
            try
            {
                var usersRegions = _dbContext.RegionBreakdown.ToList();
                return Ok(usersRegions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}