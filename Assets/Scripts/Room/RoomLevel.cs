using UnityEngine;

public class RoomLevel : MonoBehaviour
{
    private int _level = 1;

    public void Increase()
    {
        _level += 1;
        Debug.Log($"Level: {_level}");
    }

    public void Reset()
    {
        _level = 1;
        Debug.Log($"Level: {_level}");
    }
}
