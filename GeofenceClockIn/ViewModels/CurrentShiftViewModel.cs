using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Geofence;
using Plugin.Geofence.Abstractions;

namespace GeofenceClockIn.ViewModels
{
    public class CurrentShiftViewModel : BaseViewModel
    {
        private bool _isStartShiftActive;
        public bool IsStartShiftActive
        {
            get => _isStartShiftActive;
            set { SetProperty(ref _isStartShiftActive, value); }
        }

        private bool _isEndShiftActive;
        public bool IsEndShiftActive
        {
            get => _isEndShiftActive;
            set { SetProperty(ref _isEndShiftActive, value); }
        }

        public CurrentShiftViewModel()
        {
            Title = "hello";
            _isStartShiftActive = true;
            _isEndShiftActive = false;

            GeofenceCircularRegion region = new GeofenceCircularRegion("Geo1", 10, 10, 1000);
            CrossGeofence.Current.StartMonitoring(region);
        }
    }
}
