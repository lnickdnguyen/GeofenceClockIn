using GeofenceClockIn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeofenceClockIn.MobileAppService.Accessors
{
    public interface IGenericAccessor
    {
        List<Shift> GetAllShiftsByEmployeeId(string employeeId);

        string CreateShift(Shift shift);

        string DeleteShift(string id);

        Shift UpdateShift(string id, Shift shift);
    }
}
