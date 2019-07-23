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

        public static Shift currentShift
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
    }
}
