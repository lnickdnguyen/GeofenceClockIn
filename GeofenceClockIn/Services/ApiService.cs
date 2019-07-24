﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using GeofenceClockIn.Models;
using Newtonsoft.Json;

namespace GeofenceClockIn.Services
{
    public class ApiService
    {
        string baseUrl = "https://geofenceclockinmobileappservice20190723035228.azurewebsites.net/shifts/";
        HttpClient httpClient;

        public ApiService()
        {
            httpClient = new HttpClient();
        }

        public void CreateShift(Shift shift)
        {
            HttpContent body = new StringContent(JsonConvert.SerializeObject(shift),System.Text.Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync($"{baseUrl}/create", body).Result;

            int i = 88;
        }

        public void DeleteShift(string shiftId)
        {
            var response = httpClient.DeleteAsync($"{baseUrl}/delete/{shiftId}").Result;

            int i = 88;
        }

        public List<Shift> GetAllShifts(string employeeId)
        {
            var response = httpClient.GetAsync($"{baseUrl}/get/{employeeId}").Result;

            List<Shift> shifts = JsonConvert.DeserializeObject<List<Shift>>(response.Content.ToString());

            return shifts;
        }
    }
}
