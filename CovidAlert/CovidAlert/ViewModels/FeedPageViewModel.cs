using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using CovidAlert.Core;
using Xamarin.Forms;
using CovidAlert.Models;
using CovidAlert.Services;
using CovidAlert.Views;

namespace CovidAlert.ViewModels
{
    public class FeedPageViewModel : BaseViewModel, IInitializeAsync
    {
        private readonly IDataService dataService;
        private bool busy;

        public bool IsBusy
        {
            get => busy;
            set => SetProperty(ref busy, value);
        }

        public ObservableCollection<CountryDetailsViewModel> Items
        {
            get;
        }

        public Command RefreshItems
        {
            get;
        }

        public FeedPageViewModel(IDataService dataService)
        {
            this.dataService = dataService;

            Title = "Browse";
            Items = new ObservableCollection<CountryDetailsViewModel>();
            RefreshItems = new Command(async () => await ExecuteLoadItemsCommand());

            /*MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await dataService.AddItemAsync(newItem);
            });*/
        }

        public Task InitializeAsync()
        {
            return ExecuteLoadItemsCommand();
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                //Items.Clear();

                dataService.GetStatisticsAsync()

                var items = await dataService.GetStatisticsAsync(true);
                
                foreach (var item in items)
                {
                    Items.Add(new CountryDetailsViewModel
                    {
                        CountryName = item.CountryInfo.EnglishName,
                        Confirmed = item.Latest.Confirmed,
                        LastConfirmed = item.Last.Confirmed
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}