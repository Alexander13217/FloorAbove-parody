using Newtonsoft.Json;
using System;

namespace Settings
{
    public class SettingsData
    {
        [JsonProperty("sensitivity")]
        public float Sensitivity
        {
            get => _sensitivity;

            set
            {
                _sensitivity = Math.Clamp(value, 1f, 10f);
            }
        }

        [JsonProperty("volume")]
        public float Volume
        {
            get => _volume;

            set
            {
                _volume = Math.Clamp(value, 0f, 1f);
            }
        }

        private float _sensitivity;
        private float _volume;

        public SettingsData()
        {
            //Default settings
            Sensitivity = 3f;
            Volume = 1f;
        }
    }
}
