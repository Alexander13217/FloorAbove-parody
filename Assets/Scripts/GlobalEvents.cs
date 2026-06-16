using Settings;
using System;

public class GlobalEvents
{
    static public event Action Won;
    static public event Action Paused;
    static public event Action UnPaused;
    static public event Action<SettingsData> SettingsChanged;

    static public void Win()
    {
        Won?.Invoke();
    }

    static public void Pause()
    {
        Paused?.Invoke();
    }

    static public void UnPause()
    {
        UnPaused?.Invoke();
    }

    static public void SettingsChange(SettingsData data)
    {
        SettingsChanged?.Invoke(data);
    }
}

