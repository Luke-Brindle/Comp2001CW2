using System.ComponentModel.DataAnnotations;

namespace Comp2001CW2.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Country { get; set; }
    }
}
