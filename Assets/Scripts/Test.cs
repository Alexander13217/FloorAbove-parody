using System;
using UnityEngine;

public class Test : MonoBehaviour
{
    public event Action Pressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pressed?.Invoke();
        }
    }
}
