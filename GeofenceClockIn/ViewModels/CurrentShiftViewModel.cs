using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GeofenceClockIn.Models;
using GeofenceClockIn.Services;
using Plugin.Geofence;
using Plugin.Geofence.Abstractions;
using Xamarin.Forms;

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

        private TimeSpan _clockedInTime;
        public TimeSpan ClockedInTime
        {
            get => _clockedInTime;
            set => SetProperty(ref _clockedInTime, value);
        }

        public Command StartShiftCommand { get; set; }
        public Command EndShiftCommand { get; set; }

        public ApiService _apiService;

        public CurrentShiftViewModel()
        {
            _isStartShiftActive = true;
            _isEndShiftActive = false;

            StartShiftCommand = new Command(OnStartShift);
            EndShiftCommand = new Command(OnEndShift);

            GeofenceCircularRegion region = new GeofenceCircularRegion("Geo1", 47.637, -122.133, 200);
            CrossGeofence.Current.StartMonitoring(region);
            _apiService = new ApiService();

            Task.Run(() => ShiftGoingListener());

            ClockedInTime = DateTime.Now.TimeOfDay;
        }

        private void ShiftGoingListener()
        {
            while (true)
            {
                Task.Delay(1000).Wait();
                if(App.ShiftGoing != IsEndShiftActive)
                {
                    IsStartShiftActive = !App.ShiftGoing;
                    IsEndShiftActive = App.ShiftGoing;
                    ClockedInTime = DateTime.Now.TimeOfDay;
                }
            }
        }

        private void OnStartShift()
        {
            Shift newShift = new Shift
            {
                CompanyId = "Yo",
                EmployeeId = "Jarod",
                LocationId = "YoCity",
                StartTime = DateTime.Now,
                Wage = new ShiftWage { Title = "Prankster", HourlyRate = 500 }
            };
            SettingsService.CurrentShift = newShift;

            IsStartShiftActive = false;
            IsEndShiftActive = true;
            App.ShiftGoing = true;
        }

        private void OnEndShift()
        {
            IsStartShiftActive = true;
            IsEndShiftActive = false;
            App.ShiftGoing = false;

            if (SettingsService.CurrentShift == null)
                return;

            Shift currentShift = SettingsService.CurrentShift;
            currentShift.EndTime = DateTime.Now;
            _apiService.CreateShift(currentShift);
        }
    }
}
