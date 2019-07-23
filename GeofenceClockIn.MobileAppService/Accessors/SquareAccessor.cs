using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Square.Connect.Api;
using Square.Connect.Client;
using Square.Connect.Model;

namespace GeofenceClockIn.MobileAppService.Accessors
{
    public class SquareAccessor : ISquareAccessor
    {
        private readonly LaborApi _laborApi;
        
        public SquareAccessor(Configuration configuration)
        {
            _laborApi = new LaborApi(configuration);
        }

        public List<Shift> GetAllShiftsByEmployee(ShiftQuery shiftQuery)
        {
            SearchShiftsRequest request = new SearchShiftsRequest(Query: shiftQuery);

            return _laborApi.SearchShifts(request).Shifts;
        }

        public string CreateShift(Shift shift)
        {
            CreateShiftRequest request = new CreateShiftRequest(Shift: shift, IdempotencyKey: Guid.NewGuid().ToString()) ;

            var temp = _laborApi.CreateShiftWithHttpInfo(request);
            return "";
        }

        public string DeleteShift(string id)
        {
            try
            {
                _laborApi.DeleteShift(id);
                return id;
            }
            catch (Exception)
            {
                return default;
            }
        }

        public Shift UpdateShift(string id, Shift shift)
        {
            UpdateShiftRequest request = new UpdateShiftRequest(Shift: shift);

            return _laborApi.UpdateShift(id, request).Shift;
        }
    }

}
