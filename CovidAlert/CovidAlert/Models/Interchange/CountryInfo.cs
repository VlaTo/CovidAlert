namespace CovidAlert.Models.Interchange
{
    public sealed class CountryInfo
    {
        public string EnglishName
        {
            get;
        }

        public string Code
        {
            get;
        }

        public string Province
        {
            get;
        }

        public CountryInfo(string code, string province, string englishName)
        {
            Code = code;
            Province = province;
            EnglishName = englishName;
        }
    }
}