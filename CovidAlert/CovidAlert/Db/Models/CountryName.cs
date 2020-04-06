using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Permissions;

namespace CovidAlert.Db.Models
{
    [Table("country_names")]
    public class CountryName
    {
        [Key, Required]
        [Column("code")]
        public string Code
        {
            get;
            set;
        }

        [Required]
        [Column("english_name")]
        public string EnglishName
        {
            get;
            set;
        }
    }
}