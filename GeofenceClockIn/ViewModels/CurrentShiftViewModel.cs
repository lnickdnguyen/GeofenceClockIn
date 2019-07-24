using System;
using System.Collections.Generic;
using System.Text;
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

        public Command StartShiftCommand { get; set; }
        public Command EndShiftCommand { get; set; }

        public ApiService _apiService;

        public CurrentShiftViewModel()
        {
            Title = "hello";

            _isStartShiftActive = true;
            _isEndShiftActive = false;

            StartShiftCommand = new Command(OnStartShift);
            EndShiftCommand = new Command(OnEndShift);

            GeofenceCircularRegion region = new GeofenceCircularRegion("Geo1", 10, 10, 1000);
            CrossGeofence.Current.StartMonitoring(region);
            _apiService = new ApiService();
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
        }

        private void OnEndShift()
        {
            _isStartShiftActive = true;
            _isEndShiftActive = false;
<<<<<<< HEAD
=======

            if (SettingsService.CurrentShift == null)
                return;

            Shift currentShift = SettingsService.CurrentShift;
            currentShift.EndTime = DateTime.Now;
            _apiService.CreateShift(currentShift);
>>>>>>> cea992d5414a675019f19e9a14dfd42c519f1b3a
        }
    }
}
