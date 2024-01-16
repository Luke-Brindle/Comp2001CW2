using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comp2001CW2.Models
{
    public class User 
    {
        [Key]
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public bool AdminRights { get; set; }
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        [ForeignKey("LanguageID")]
        public string LanguageID { get; set; }
        [ForeignKey("LocationID")]
        public int LocationID { get; set; }
        public string AboutMe { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public bool UnitPref { get; set; }
        public bool TimePref { get; set; }
    }
}