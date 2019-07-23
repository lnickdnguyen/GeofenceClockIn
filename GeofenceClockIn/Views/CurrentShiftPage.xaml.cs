using GeofenceClockIn.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace GeofenceClockIn.Views
{
    public partial class CurrentShiftPage : ContentPage
    {
        private readonly CurrentShiftViewModel _currentShiftViewModel;

        public CurrentShiftPage()
        {
            InitializeComponent();

            _currentShiftViewModel = new CurrentShiftViewModel();
        }

        private void StartShiftButton_Clicked(object sender, EventArgs e)
        {
            _currentShiftViewModel.IsStartShiftActive = false;
            _currentShiftViewModel.IsEndShiftActive = true;
        }

        private void EndShiftButton_Clicked(object sender, EventArgs e)
        {
            _currentShiftViewModel.IsStartShiftActive = true;
            _currentShiftViewModel.IsEndShiftActive = false;
        }
    }
}
