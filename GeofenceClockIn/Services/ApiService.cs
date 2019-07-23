using System;
using System.Net.Http;

namespace GeofenceClockIn.Services
{
    public class ApiService
    {
        string baseUrl = "https://localhost:5001/shifts/";
        HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient();
        }

        public void CreateShift(string shift)
        {

        }

        public void DeleteShift(string shiftId)
        {

        }

        public void GetAllShifts(string employeeId)
        {

        }
    }
}
