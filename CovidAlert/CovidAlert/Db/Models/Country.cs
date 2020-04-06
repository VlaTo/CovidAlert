using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidAlert.Db.Models
{
    [Table("country")]
    public class Country
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }



        [Column("country_code")]
        [Required]
        public string Code
        {
            get;
            set;
        }

        [Column("province")]
        public string Province
        {
            get;
            set;
        }

        [Column("is_show")]
        public bool DoNotShow
        {
            get;
            set;
        }

        [Column("population")]
        public ulong Population
        {
            get;
            set;
        }

        [ForeignKey(nameof(Code))]
        public CountryName CountryName
        {
            get;
            set;
        }
    }
}