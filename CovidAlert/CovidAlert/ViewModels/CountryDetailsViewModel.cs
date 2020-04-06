namespace CovidAlert.ViewModels
{
    public class CountryDetailsViewModel : BindableBase
    {
        private string countryName;
        private ulong confirmed;
        private ulong lastConfirmed;

        public string CountryName
        {
            get => countryName;
            set => SetProperty(ref countryName, value);
        }

        public ulong Confirmed
        {
            get => confirmed;
            set => SetProperty(ref confirmed, value);
        }

        public ulong LastConfirmed
        {
            get => lastConfirmed;
            set => SetProperty(ref lastConfirmed, value);
        }
    }
}
