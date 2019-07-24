using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using GeofenceClockIn.Droid.Services;
using Plugin.Geofence;
using GeofenceClockIn.Services;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;
using Plugin.Permissions;

namespace GeofenceClockIn.Droid
{
    [Activity(Label = "GeofenceClockIn", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            // Initalize the permissions plugin
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, savedInstanceState);

            global::Xamarin.Forms.Forms.SetFlags("Shell_Experimental", "Visual_Experimental", "CollectionView_Experimental", "FastRenderers_Experimental");
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState); //Initialize Mapview
            LoadApplication(new App());

            
            

            StartGeofencePlugin();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void StartGeofencePlugin()
        {
            CrossGeofence.Initialize<GeofenceListenerService>();
            CrossGeofence.GeofenceListener.OnAppStarted();

            StartService();
        }

        public void StartService()
        { 
            ApplicationContext.StartService(new Intent(ApplicationContext, typeof(GeofenceService)));

            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {

                PendingIntent pintent = PendingIntent.GetService(ApplicationContext, 0, new Intent(ApplicationContext, typeof(GeofenceService)), 0);
                AlarmManager alarm = (AlarmManager)GetSystemService(Context.AlarmService);
                alarm.Cancel(pintent);
            }
        }

        public void StopService()
        {
            ApplicationContext.StopService(new Intent(ApplicationContext, typeof(GeofenceService)));
            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.Kitkat)
            {
                PendingIntent pintent = PendingIntent.GetService(ApplicationContext, 0, new Intent(ApplicationContext, typeof(GeofenceService)), 0);
                AlarmManager alarm = (AlarmManager)GetSystemService(Context.AlarmService);
                alarm.Cancel(pintent);
            }
        }

    }
}
