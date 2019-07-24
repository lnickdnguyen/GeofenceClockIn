using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeofenceClockIn.ViewModels;
using Xamarin.Forms;

namespace GeofenceClockIn.Views
{
    public partial class AllShiftsPage : ContentPage
    {
        public AllShiftsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var viewModel = (AllShiftsViewModel)BindingContext;
            Task.Run(() => viewModel.GetAllShifts());
            base.OnAppearing();
        }
    }
}
