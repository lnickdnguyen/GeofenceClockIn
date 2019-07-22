
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
        IBinder binder;

        public override StartCommandResult OnStartCommand(Android.Content.Intent intent, StartCommandFlags flags, int startId)
        {
            // start your service logic here

            // Return the correct StartCommandResult for the type of service you are building
            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            binder = new GeofenceServiceBinder(this);
            return binder;
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
