using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GeofenceClockIn.Views;
using Plugin.Geofence;
using Plugin.Geofence.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using GeofenceClockIn.Services;

namespace GeofenceClockIn
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            CheckPermissions();

            MainPage = new AppShell();
        }

        private async void CheckPermissions()
        {
            bool locationStatus = (await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location)) == PermissionStatus.Granted;
            bool locationAlwaysStatus = (await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways)) == PermissionStatus.Granted;

            if (!(locationStatus && locationAlwaysStatus))
            {
                //Shell.Current.DisplayAlert("Permissions Needed", "For this app to run properly we need some permissions. When requested please grant location permissions. If you do not grant these permissions the app will not run.", "Will do buckaroo!").RunSynchronously();
                locationStatus = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location))[Permission.Location] == PermissionStatus.Granted;
                locationAlwaysStatus = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationAlways))[Permission.LocationAlways] == PermissionStatus.Granted;
            }

            if (locationStatus && locationAlwaysStatus)
            {
                //GeofenceCircularRegion region = new GeofenceCircularRegion("Geo1", 10, 10, 1000);
                //CrossGeofence.Current.StartMonitoring(region);
            }
            else
            {
                await Shell.Current.DisplayAlert("Permissions Needed", "App will not function since you did not grant permission data. Please grant permission to location to 'GeofenceClockIn' in settings.", "Yeah man, shore.");
            }
        }

        protected override void OnStart()
        {
			// Handle when your app starts
			SettingsService.CurrentShift = null;
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
