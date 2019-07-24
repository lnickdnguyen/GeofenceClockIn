using GeofenceClockIn.Models;
using GeofenceClockIn.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeofenceClockIn.ViewModels
{
    class AllShiftsViewModel : BaseViewModel
    {
        private List<Shift> _allShiftsList;
        public List<Shift> AllShiftsList
        {
            get => _allShiftsList;
            set { SetProperty(ref _allShiftsList, value); }
        }

        public ApiService _apiService;

        public AllShiftsViewModel()
        {
            _apiService = new ApiService();
            //GetAllShifts();
        }

        public async void GetAllShifts()
        {
            AllShiftsList = await _apiService.GetAllShifts("Jarod");
        }
    }
}
