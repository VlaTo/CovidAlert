using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CovidAlert.Db.Models
{
    [Table("statistic")]
    public class Statistics
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get;
            set;
        }

        [Column("country_id")]
        public int CountryId
        {
            get;
            set;
        }

        [ForeignKey(nameof(CountryId))]
        public Country Country
        {
            get;
            set;
        }

        [Column("confirmed")]
        public ulong Confirmed
        {
            get;
            set;
        }

        [Column("deaths")]
        public ulong Deaths
        {
            get;
            set;
        }

        [Column("recovered")]
        public ulong Recovered
        {
            get;
            set;
        }

        [Column("updated")]
        public DateTimeOffset LastUpdated
        {
            get;
            set;
        }
    }
}