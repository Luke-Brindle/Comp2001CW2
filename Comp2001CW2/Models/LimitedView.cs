using System.ComponentModel.DataAnnotations.Schema;

namespace Comp2001CW2.Models
{
    public class LimitedView
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string AboutMe { get; set; }
        public string Location { get; set; }
        public string FavouriteActivities { get; set; }
    }
}