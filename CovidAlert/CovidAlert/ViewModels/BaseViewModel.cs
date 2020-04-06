namespace CovidAlert.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        string title = string.Empty;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
