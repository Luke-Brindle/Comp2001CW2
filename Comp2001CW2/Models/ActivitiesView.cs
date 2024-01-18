using System.ComponentModel.DataAnnotations;

namespace Comp2001CW2.Models
{
    public class ActivitiesView
    {
        [Key]
        public int ActivityID { get; set; }
        public string ActivityName { get; set; }
    }
}
