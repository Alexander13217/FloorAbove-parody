using Newtonsoft.Json;
using System.IO;

namespace Settings
{
    public class DataProvider
    {
        private readonly string _fileName = "Data.json";
        private readonly string _filePath;

        public DataProvider(string persistentPath)
        {
            _filePath = Path.Combine(persistentPath, _fileName);
        }

        public void SaveData(SettingsData data)
        {
            string dataToJson = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(_filePath, dataToJson);     
        }

        public SettingsData LoadData()
        {
            SettingsData data;

            if (File.Exists(_filePath) == false)
            {
                return new SettingsData();
            }

            string dataFromJson = File.ReadAllText(_filePath);

            data = JsonConvert.DeserializeObject<SettingsData>(dataFromJson);
            return data != null ? data : new SettingsData();
        }
    }
}
