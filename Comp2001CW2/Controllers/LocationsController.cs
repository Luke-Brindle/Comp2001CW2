using Comp2001CW2.Models;
using Microsoft.AspNetCore.Mvc;
using Comp2001CW2.Data;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Comp2001CW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public LocationsController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("LocationsView")]
        public IActionResult LanguagesView()
        {
            try
            {
                var locationsView = _dbContext.LocationsView.ToList();
                return Ok(locationsView);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("CreateLocation")]
        public IActionResult CreateLocation(string town, string county, string country)
        {
            try
            {
                _dbContext.CreateLocation(town, county, country);
                _dbContext.SaveChanges();
                return Ok("Location created successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("UpdateLocation")]
        public IActionResult UpdateLocation(int locationID, string town, string county, string country)
        {
            try
            {
                _dbContext.UpdateLocation(locationID, town, county, country);
                _dbContext.SaveChanges();
                return Ok("Location updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteLocation")]
        public IActionResult DeleteLocation(int locationID)
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

}