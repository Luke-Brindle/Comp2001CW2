using System.ComponentModel.DataAnnotations;

namespace Comp2001CW2.Models
{
    public class Language
    {
        [Key]
        public string LanguageID { get; set; }
        public string LanguageName { get; set; }
    }
}
