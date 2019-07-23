using System;
using System.Diagnostics;
using Plugin.Geofence.Abstractions;

namespace GeofenceClockIn.Services
{
    public class GeofenceListenerService : IGeofenceListener
    {
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
        }
    }
}
