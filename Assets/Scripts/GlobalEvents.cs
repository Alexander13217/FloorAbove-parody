using System;

public class GlobalEvents
{
    static public event Action Won;
    static public event Action Paused;
    static public event Action UnPaused;

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
}

