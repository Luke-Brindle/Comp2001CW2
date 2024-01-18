using Comp2001CW2.Models;
using Microsoft.AspNetCore.Mvc;
using Comp2001CW2.Data;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Comp2001CW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public AdminController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpDelete("ArchiveAccount")]
        public IActionResult ArchiveAccount(int userID)
        {
            int? adminRights = HttpContext.Session.GetInt32("AdminRights");

            if (adminRights != 1)
            {
                return BadRequest("Administrative rights required to archive accounts");
            }
            else
            {
                try
                {
                    _dbContext.ArchiveAccount(userID);
                    _dbContext.SaveChanges();
                    return Ok("Account archived successfully.");

                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }

        [HttpPut("EditAdminRights")]
        public IActionResult EditAdminRights(int userID, bool adminRights)
        {
            int? loggedInAdminRights = HttpContext.Session.GetInt32("AdminRights");

            if (loggedInAdminRights != 1)
            {
                return BadRequest("Administrative rights required to edit admin rights");
            }
            else
            {
                try
                {
                    _dbContext.EditAdminRights(userID, adminRights);
                    _dbContext.SaveChanges();
                    return Ok($"User admin rights set to {adminRights}");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }

        [HttpGet("ActiveUsers")]
        public IActionResult GetActiveUsers()
        {
            int? loggedInAdminRights = HttpContext.Session.GetInt32("AdminRights");

            if (loggedInAdminRights != 1)
            {
                return BadRequest("Administrative rights required to see this View");
            }
            else
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
        }

        [HttpGet("ArchivedAccounts")]
        public IActionResult ArchivedAccounts()
        {
            int? loggedInAdminRights = HttpContext.Session.GetInt32("AdminRights");

            if (loggedInAdminRights != 1)
            {
                return BadRequest("Administrative rights required to see this View");
            }
            else
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
        }

        [HttpPost("CreateLanguage")]
        public IActionResult CreateLanguage(string languageID, string languageName)
        {
            int? adminRights = HttpContext.Session.GetInt32("AdminRights");

            if (adminRights != 1)
            {
                return BadRequest("Administrative rights required to create languages");
            }
            else
            {
                try
                {
                    _dbContext.CreateLanguage(languageID, languageName);
                    _dbContext.SaveChanges();
                    return Ok("Language created successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }

        [HttpDelete("DeleteLanguage")]
        public IActionResult DeleteLanguage(string languageID)
        {
            int? adminRights = HttpContext.Session.GetInt32("AdminRights");

            if (adminRights != 1)
            {
                return BadRequest("Administrative rights required to delete languages");
            }
            else
            {
                try
                {
                    _dbContext.DeleteLanguage(languageID);
                    _dbContext.SaveChanges();
                    return Ok("Language deleted successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }

        [HttpDelete("DeleteLocation")]
        public IActionResult DeleteLocation(int locationID)
        {
            int? adminRights = HttpContext.Session.GetInt32("AdminRights");

            if (adminRights != 1)
            {
                return BadRequest("Administrative rights required to delete locations");
            }
            else
            {
                try
                {
                    _dbContext.DeleteLocation(locationID);
                    _dbContext.SaveChanges();
                    return Ok("Location deleted successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }

        [HttpDelete("DeleteActivity")]
        public IActionResult DeleteActivity(int activityID)
        {
            int? adminRights = HttpContext.Session.GetInt32("AdminRights");

            if (adminRights != 1)
            {
                return BadRequest("Administrative rights required to delete activities");
            }
            else
            {
                try
                {
                    _dbContext.DeleteActivity(activityID);
                    _dbContext.SaveChanges();
                    return Ok("Activity deleted successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }

    }
}
