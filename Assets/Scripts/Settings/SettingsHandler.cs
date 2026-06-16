using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace Settings
{
    public class SettingsHandler : MonoBehaviour
    {
        [SerializeField] private Slider _volume;
        [SerializeField] private TMP_Text _volumeText;
        [SerializeField] private Slider _sensitivity;
        [SerializeField] private TMP_Text _sensText;

        private DataProvider _data;
        private SettingsData _settingsData;

        private void Awake()
        {
            _data = new DataProvider(Application.persistentDataPath);
            _settingsData = _data.LoadData();

            AudioListener.volume = _settingsData.Volume;
            UpdateVolumeText(_settingsData.Volume);
            UpdateSensitivityText(_settingsData.Sensitivity);
        }

        private void Start() => GlobalEvents.SettingsChange(_settingsData);

        private void OnEnable()
        {
            _volume.onValueChanged.AddListener(UpdateVolumeText);
            _sensitivity.onValueChanged.AddListener(UpdateSensitivityText);

            _volume.value = _settingsData.Volume;
            _volumeText.text = $"{_volume.value}";
            _sensitivity.value = _settingsData.Sensitivity;
            _sensText.text = $"{_sensitivity.value}";
        }

        private void OnDisable()
        {
            _volume.onValueChanged.RemoveListener(UpdateVolumeText);
            _sensitivity.onValueChanged.RemoveListener(UpdateSensitivityText);
        }

        public void Save()
        {
            _settingsData.Volume = _volume.value;
            _settingsData.Sensitivity = _sensitivity.value;

            _data.SaveData(_settingsData);

            AudioListener.volume = _settingsData.Volume;

            GlobalEvents.SettingsChange(_settingsData);
        }

        private void UpdateVolumeText(float value)
        {
            _volumeText.text = value.ToString("0.##");
        }

        private void UpdateSensitivityText(float value)
        {
            _sensText.text = value.ToString("0.##");
        }
    }
}
