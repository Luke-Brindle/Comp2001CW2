using Comp2001CW2.Models;
using Microsoft.AspNetCore.Mvc;
using Comp2001CW2.Data;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

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


        [HttpGet("LimitedView")]
        public IActionResult LimitedView()
        {
            try
            {
                var usersView = _dbContext.LimitedView.ToList();
                return Ok(usersView);
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

        [HttpPost("UnarchiveAccount")]
        public IActionResult UnarchiveAccount(int userID)
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userID != userId)
            {
                return BadRequest("Only the logged in account can be unarchived");
            }
            else
            {
                try
                {
                    _dbContext.UnarchiveAccount(userID);
                    _dbContext.SaveChanges();
                    return Ok("Account unarchived successfully.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }


        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount(string email, string password, string username, string dateofbirth, string languageid, bool unitpref, bool timepref)
        {
            try
            {
                _dbContext.CreateAccount(email, password, username, dateofbirth, languageid, unitpref, timepref) ;
                _dbContext.SaveChanges();
                return Ok("Account created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("DeleteFavActivity")]
        public IActionResult DeleteFavActivity(int userID, int activityID)
        {
            try
            {
                _dbContext.DeleteFavActivity(userID, activityID);
                _dbContext.SaveChanges();
                return Ok("Activity removed from profile.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("NewFavActivity")]
        public IActionResult NewFavActivity(int userID, int activityID)
        {
            try
            {
                _dbContext.NewFavActivity(userID, activityID);
                _dbContext.SaveChanges();
                return Ok("Activity added to profile.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpPost("UpdateAccount")]
        public IActionResult UpdateAccount(int userID, string email, string password, string username, string dateofbirth, string languageid, int locationid, string aboutme, double height, double weight)
        {

            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userID != userId)
            {
                return BadRequest("Only the logged in account can be edited");
            }
            else
            {
                try
                {
                    _dbContext.UpdateAccount(userID, email, password, username, dateofbirth, languageid, locationid, aboutme, height, weight);
                    _dbContext.SaveChanges();
                    return Ok("Account updated.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }

        [HttpPost("UpdatePreferences")]
        public IActionResult UpdatePreferences(int userID, bool unitPref, bool timePref)
        {
            int? userId = HttpContext.Session.GetInt32("UserID");
            if (userID != userId)
            {
                return BadRequest("Only the logged in account can be edited");
            }
            else
            {
                try
                {
                    _dbContext.UpdatePreferences(userID, unitPref, timePref);
                    _dbContext.SaveChanges();
                    return Ok("Preferences updated and values converted.");
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal Server Error: {ex.Message}");
                }
            }
        }

    }

    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public AdminsController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("ArchiveAccount")]
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

        [HttpPost("EditAdminRights")]
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
    }
}