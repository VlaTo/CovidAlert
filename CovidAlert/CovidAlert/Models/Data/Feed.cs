using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace CovidAlert.Models.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class Feed
    {
        [JsonPropertyName("latest")]
        public Statistic Latest
        {
            get; 
            set;
        }

        [JsonPropertyName("locations")]
        public Location[] Locations
        {
            get; 
            set;
        }

        public Feed()
        {
            Locations = new Location[0];
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public sealed class Statistic
    {
        [JsonPropertyName("confirmed")]
        public ulong Confirmed
        {
            get; 
            set;
        }

        [JsonPropertyName("deaths")]
        public ulong Deaths
        {
            get; 
            set;
        }

        [JsonPropertyName("recovered")]
        public ulong Recovered
        {
            get; 
            set;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public sealed class Location
    {
        [JsonPropertyName("id")]
        public int Id
        {
            get; 
            set;
        }

        [JsonPropertyName("countryInfo")]
        public string Country
        {
            get; 
            set;
        }

        [JsonPropertyName("country_code")]
        public string CountryCode
        {
            get; 
            set;
        }


        [JsonPropertyName("province")]
        public string Province
        {
            get; 
            set;
        }

        [JsonPropertyName("latest")]
        public Statistic Latest
        {
            get; 
            set;
        }
    }
}