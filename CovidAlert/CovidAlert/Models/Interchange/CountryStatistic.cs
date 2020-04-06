namespace CovidAlert.Models.Interchange
{
    public class CountryStatistic
    {
        public int Id
        {
            get;
        }

        public CountryInfo CountryInfo
        {
            get;
        }

        public StatisticInfo Latest
        {
            get;
        }

        public StatisticInfo Last
        {
            get;
        }

        public CountryStatistic(int id, CountryInfo countryInfo, StatisticInfo latest, StatisticInfo last)
        {
            Id = id;
            CountryInfo = countryInfo;
            Latest = latest;
            Last = last;
        }
    }
}