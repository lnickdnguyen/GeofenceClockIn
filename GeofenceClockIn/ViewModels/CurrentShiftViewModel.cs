using System;
using System.Collections.Generic;
using System.Text;
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

        public CurrentShiftViewModel()
        {
            Title = "hello";

            _isStartShiftActive = true;
            _isEndShiftActive = false;

            StartShiftCommand = new Command(OnStartShift);
            EndShiftCommand = new Command(OnEndShift);
        }

        private void OnStartShift()
        {
            IsStartShiftActive = false;
            IsEndShiftActive = true;
        }

        private void OnEndShift()
        {
            _isStartShiftActive = true;
            _isEndShiftActive = false;
        }
    }
}
