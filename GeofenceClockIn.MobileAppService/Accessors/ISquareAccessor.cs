using Square.Connect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeofenceClockIn.MobileAppService.Accessors
{
    public interface ISquareAccessor
    {
        List<Shift> GetAllShiftsByEmployee(ShiftQuery shiftQuery);

        string CreateShift(Shift shift);

        string DeleteShift(string id);

        Shift UpdateShift(string id, Shift shift);
    }
}
