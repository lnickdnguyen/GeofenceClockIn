using System;
using System.Diagnostics;
using GeofenceClockIn.Models;
using Plugin.Geofence.Abstractions;

namespace GeofenceClockIn.Services
{
    public class GeofenceListenerService : IGeofenceListener
    {
        private ApiService apiService;

        public GeofenceListenerService()
        {
            apiService = new ApiService();
        }

        public void OnAppStarted()
        {
            Debug.WriteLine("App started");
        }

        public void OnError(string error)
        {
            Debug.WriteLine($"Error: {error}");
        }

        public void OnLocationChanged(GeofenceLocation location)
        {
            Debug.WriteLine($"Location Changed to {location.Latitude},{location.Longitude}");
        }

        public void OnMonitoringStarted(string identifier)
        {
            Debug.WriteLine($"Monitoring Started on {identifier}");
        }

        public void OnMonitoringStopped()
        {
            Debug.WriteLine("Monitoring Stopped");
        }

        public void OnMonitoringStopped(string identifier)
        {
            Debug.WriteLine($"Monitoring Stopped on {identifier}");
        }

        public void OnRegionStateChanged(GeofenceResult result)
        {
            Debug.WriteLine($"Region State changed to {result.TransitionName} for region {result.RegionId}.");

            if(result.Transition == GeofenceTransition.Entered)
            {
                Shift newShift = new Shift
                {
                    CompanyId = "Yo",
                    EmployeeId = "Jarod",
                    LocationId = "YoCity",
                    StartTime = DateTime.Now,
                    Wage = new ShiftWage { Title = "Prankster", HourlyRate=500 }
                };

                SettingsService.CurrentShift = newShift;
            }
            else if(result.Transition == GeofenceTransition.Exited)
            {
                if (SettingsService.CurrentShift == null)
                    return;

                Shift currentShift = SettingsService.CurrentShift;
                currentShift.EndTime = DateTime.Now;

                apiService.CreateShift(currentShift);
            }
        }
    }
}
