using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CovidAlert.Droid
{
    [Activity(Label = "CovidAlert", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private bool doubleBackToExitPressedOnce;
        private Toast toast;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            toast = Toast.MakeText(Application.Context, "Press Back to exit", ToastLength.Long);

            LoadApplication(new App());
        }

        public override void OnBackPressed()
        {
            if (doubleBackToExitPressedOnce)
            {
                toast.Cancel();
                base.OnBackPressed();
            }

            toast.Show();

            doubleBackToExitPressedOnce = true;

            new Handler().PostDelayed(() => doubleBackToExitPressedOnce = false, 2000);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}