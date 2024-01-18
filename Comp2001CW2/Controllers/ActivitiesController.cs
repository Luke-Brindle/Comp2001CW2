using Comp2001CW2.Models;
using Microsoft.AspNetCore.Mvc;
using Comp2001CW2.Data;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Comp2001CW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public ActivitiesController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("ActivitiesView")]
        public IActionResult ActivitiesView()
        {
            try
            {
                var activitiesView = _dbContext.ActivitiesView.ToList();
                return Ok(activitiesView);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("CreateActivity")]
        public IActionResult CreateActivity(string activityName)
        {
            try
            {
                _dbContext.CreateActivity(activityName);
                _dbContext.SaveChanges();
                return Ok("Activity created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("UpdateActivity")]
        public IActionResult UpdateActivity(int activityID, string activityName)
        {
            try
            {
                _dbContext.UpdateActivity(activityID, activityName);
                _dbContext.SaveChanges();
                return Ok("Activity updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteActivity")]
        public IActionResult DeleteActivity(int activityID)
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
