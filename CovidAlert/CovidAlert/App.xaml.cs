using CovidAlert.Db;
using CovidAlert.Models;
using CovidAlert.Services;
using CovidAlert.ViewModels;
using CovidAlert.Views;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace CovidAlert
{
    public partial class App
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<IDataProvider, RemoteDataProvider>();
            DependencyService.Register<IDataService, CovidDataService>();
            DependencyService.Register<CovidDbContext>();
            DependencyService.Register<FeedPageViewModel>();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            var db = DependencyService.Resolve<CovidDbContext>();

            db.Database.EnsureCreated();
            db.Database.Migrate();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
