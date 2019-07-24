using GeofenceClockIn.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace GeofenceClockIn.Views
{
    public partial class CurrentShiftPage : ContentPage
    {
        public CurrentShiftPage()
        {
            InitializeComponent();

            var location = Geolocation.GetLastKnownLocationAsync().Result;

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(5)));

            MyMap.Pins.Add(new Pin { Label="Work", Position=new Position(41.43,-97.36) });
        }

        private void UpdateLocationProcess()
        {
            while (true)
            {
                Task.Delay(1000).Wait();

                var location = Geolocation.GetLastKnownLocationAsync().Result;

                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMiles(5)));
            }
        }
    }
}
