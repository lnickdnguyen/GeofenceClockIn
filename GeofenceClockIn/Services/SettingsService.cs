using System;
using GeofenceClockIn.Models;
using Newtonsoft.Json;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace GeofenceClockIn.Services
{
    public static class SettingsService
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        public static Shift CurrentShift
        {
            get
            {
                return JsonConvert.DeserializeObject<Shift>(AppSettings.GetValueOrDefault("currentshift", null));
            }
            set
            {
                AppSettings.AddOrUpdateValue("currentshift", JsonConvert.SerializeObject(value));
            }
        }

        public static bool MonitoringLocation
        {
            get
            {
                return AppSettings.GetValueOrDefault("monitoringlocation", false);
            }
            set
            {
                AppSettings.AddOrUpdateValue("monitoringlocation", value);
            }
        }

        public static bool FirstOpen
        {
            get
            {
                return AppSettings.GetValueOrDefault("firstopen", true);
            }
            set
            {
                AppSettings.AddOrUpdateValue("firstopen", value);
            }
        }
    }
}
