using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comp2001CW2.Models
{
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
    }
}
