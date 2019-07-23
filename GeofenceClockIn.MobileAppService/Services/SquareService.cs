using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeofenceClockIn.MobileAppService.Accessors;
using Square.Connect.Model;

namespace GeofenceClockIn.MobileAppService.Services
{
    public class SquareService : ISquareService
    {
        private readonly ISquareAccessor _squareAccessor;

        public SquareService(ISquareAccessor squareAccessor)
        {
            _squareAccessor = squareAccessor;
        }

        public List<Shift> GetAllShiftsByEmployeeId(string employeeId)
        {
            // Creating ShiftQuery object
            ShiftFilter shiftFilter = new ShiftFilter
            {
                EmployeeId = new List<string> { employeeId }
            };
            ShiftSort shiftSort = new ShiftSort
            {
                Field = "START_AT",
                Order = "DESC"
            };
            ShiftQuery shiftQuery = new ShiftQuery
            {
                Filter = shiftFilter,
                Sort = shiftSort
            };

            return _squareAccessor.GetAllShiftsByEmployee(shiftQuery);
        }

        public string CreateShift(Shift shift)
        {
            return _squareAccessor.CreateShift(shift);
        }

        public string DeleteShift(string id)
        {
            return _squareAccessor.DeleteShift(id);
        }


        public Shift UpdateShift(string id, Shift shift)
        {
            return _squareAccessor.UpdateShift(id, shift);
        }
    }
}
