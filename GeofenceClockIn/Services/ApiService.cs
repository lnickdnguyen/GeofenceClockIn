using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GeofenceClockIn.Models;
using Newtonsoft.Json;

namespace GeofenceClockIn.Services
{
    public class ApiService
    {
        string baseUrl = "https://geofenceclockinmobileappservice20190723035228.azurewebsites.net/shifts";
        HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient();
        }

        public void CreateShift(Shift shift)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(shift));
            var response = httpClient.PostAsync($"{baseUrl}/create", body).Result;

            int i = 88;
        }

        public void DeleteShift(string shiftId)
        {
            var response = httpClient.DeleteAsync($"{baseUrl}/delete/{shiftId}").Result;

            int i = 88;
        }

        public async Task<List<Shift>> GetAllShifts(string employeeId)
        {
            /*var response = httpClient.GetAsync($"{baseUrl}/get/{employeeId}").Result;
            var uri = "https://geofenceclockinmobileappservice20190723035228.azurewebsites.net/shifts/get/Jarod";
            var response = httpClient.GetAsync(uri).Result;

            var temp = response.Content.ToString();
            List<Shift> shifts = JsonConvert.DeserializeObject<List<Shift>>(temp);

            return shifts;*/

            string apiRequest = $"{baseUrl}/get/{employeeId}";

            try
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiRequest);

                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.SendAsync(request);

                string content = await response.Content.ReadAsStringAsync();
                var shifts = JsonConvert.DeserializeObject<Shift[]>(content);
                return shifts.ToList<Shift>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
