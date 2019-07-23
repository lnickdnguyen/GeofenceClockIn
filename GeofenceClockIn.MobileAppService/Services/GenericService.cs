using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeofenceClockIn.MobileAppService.Accessors;
using GeofenceClockIn.Models;

namespace GeofenceClockIn.MobileAppService.Services
{
    public class GenericService : IGenericService
    {
        private readonly IGenericAccessor _genericAccessor;

        public GenericService(IGenericAccessor genericAccessor)
        {
            _genericAccessor = genericAccessor;
        }

        public List<Shift> GetAllShiftsByEmployeeId(string employeeId)
        {
            return _genericAccessor.GetAllShiftsByEmployeeId(employeeId);
        }

        public string CreateShift(Shift shift)
        {
            return _genericAccessor.CreateShift(shift);
        }

        public string DeleteShift(string id)
        {
            return _genericAccessor.DeleteShift(id);
        }


        public Shift UpdateShift(string id, Shift shift)
        {
            return _genericAccessor.UpdateShift(id, shift);
        }
    }
}
