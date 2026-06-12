using System;

public class GlobalEvents
{
    static public event Action Won;

    static public void Win()
    {
        Won?.Invoke();
    }
}

