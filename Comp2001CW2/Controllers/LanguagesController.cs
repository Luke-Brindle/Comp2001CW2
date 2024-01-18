using Comp2001CW2.Models;
using Microsoft.AspNetCore.Mvc;
using Comp2001CW2.Data;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace Comp2001CW2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public LanguagesController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("LanguagesView")]
        public IActionResult LanguagesView()
        {
            try
            {
                var languagesView = _dbContext.LanguagesView.ToList();
                return Ok(languagesView);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("CreateLanguage")]
        public IActionResult CreateLanguage(string languageID, string languageName)
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

        [HttpPut("UpdateLanguage")]
        public IActionResult UpdateLanguage(string languageID, string languageName)
        {
            try
            {
                _dbContext.UpdateLanguage(languageID, languageName);
                _dbContext.SaveChanges();
                return Ok("Language updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteLanguage")]
        public IActionResult DeleteLanguage(string languageID)
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

  }
