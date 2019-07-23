using System;
using System.Windows.Input;
using Plugin.Geofence;
using Plugin.Geofence.Abstractions;
using Xamarin.Forms;

namespace GeofenceClockIn.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));

            GeofenceCircularRegion region = new GeofenceCircularRegion("Geo1", 10, 10, 1000);
            CrossGeofence.Current.StartMonitoring(region);
        }

        public ICommand OpenWebCommand { get; }
    }
}