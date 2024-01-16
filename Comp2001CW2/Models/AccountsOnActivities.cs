using System.ComponentModel.DataAnnotations.Schema;

namespace Comp2001CW2.Models
{
    public class AccountsOnActivities
    {
        [ForeignKey("UserID")]
        public int UserID { get; set; }
        [ForeignKey("ActivityID")]
        public int ActivityID { get; set; }
    }
}
