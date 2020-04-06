using System;
using System.ComponentModel;

namespace CovidAlert.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class FeedPage
    {
        public FeedPage()
        {
            InitializeComponent();
        }

        void OnItemSelected(object sender, EventArgs args)
        {
            /*var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            await Navigation.PushAsync(new ItemDetailPage(new CountryDetailsViewModel()));*/
        }
    }
}