
using System;

using Android.App;
using Android.Content;
using Android.OS;

namespace GeofenceClockIn.Droid.Services
{
    [Service(Label = "GeofenceService")]
    [IntentFilter(new String[] { "com.yourname.GeofenceService" })]
    public class GeofenceService : Service
    {
        public override void OnCreate()
        {
            base.OnCreate();

            System.Diagnostics.Debug.WriteLine("Geofence Service - Created");
        }

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            System.Diagnostics.Debug.WriteLine("Geofence Service - Started");
            return StartCommandResult.Sticky;
        }

        public override Android.OS.IBinder OnBind(Android.Content.Intent intent)
        {
            System.Diagnostics.Debug.WriteLine("Geofence Service - Binded");
            return null;
        }

        public override void OnDestroy()
        {
            System.Diagnostics.Debug.WriteLine("Geofence Service - Destroyed");
            base.OnDestroy();
        }
    }

    public class GeofenceServiceBinder : Binder
    {
        readonly GeofenceService service;

        public GeofenceServiceBinder(GeofenceService service)
        {
            this.service = service;
        }

        public GeofenceService GetGeofenceService()
        {
            return service;
        }
    }
}
