using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GeofenceClockIn.Views;
using Plugin.Geofence;
using Plugin.Geofence.Abstractions;

namespace GeofenceClockIn
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            GeofenceCircularRegion region = new GeofenceCircularRegion("Geo1", 10, 10, 1000);

            CrossGeofence.Current.StartMonitoring(region);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
