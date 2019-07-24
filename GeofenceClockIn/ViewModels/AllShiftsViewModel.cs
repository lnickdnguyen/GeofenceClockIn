using GeofenceClockIn.Models;
using GeofenceClockIn.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
            AllShiftsList = AllShiftsList.Select(s =>
            {
                return new Shift
                {
                    CompanyId = s.CompanyId,
                    EmployeeId = s.EmployeeId,
                    LocationId = s.LocationId,
                    Wage = s.Wage,
                    StartTime = s.StartTime.ToLocalTime(),
                    EndTime = s.EndTime.ToLocalTime()
                };
            }).ToList();
        }
    }
}
