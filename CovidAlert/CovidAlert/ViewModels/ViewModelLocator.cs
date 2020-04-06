using CovidAlert.Services;
using Xamarin.Forms;

namespace CovidAlert.ViewModels
{
    public sealed class ViewModelLocator
    {
        public FeedPageViewModel FeedPageViewModel
        {
            get
            {
                var dataStore = DependencyService.Resolve<IDataService>();
                return new FeedPageViewModel(dataStore);
            }
        }
    }
}