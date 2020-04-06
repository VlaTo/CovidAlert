namespace CovidAlert.Models.Data
{
    public class CountryInfo
    {
        public string Code
        {
            get;
        }

        public string Province
        {
            get;
        }

        public string EnglishName
        {
            get;
        }

        public CountryInfo(string code, string englishName, string province)
        {
            Code = code;
            EnglishName = englishName;
            Province = province;
        }
    }

    public class StatisticItem
    {
        public int Id
        {
            get;
        }

        public CountryInfo Country
        {
            get;
        }


        public ulong Confirmed
        {
            get;
        }

        public StatisticItem(
            int id, 
            CountryInfo countryInfo,
            ulong confirmed)
        {
            Id = id;
            Country = countryInfo;
            Confirmed = confirmed;
        }
    }
}