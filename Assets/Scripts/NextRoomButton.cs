using System;
using UnityEngine;

public class NextRoomButton : MonoBehaviour
{
    [SerializeField] private LayerMask _buttonLayer;

    public event Action ButtonPressed;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckButtonPressed();
        }
    }

    private void CheckButtonPressed()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _buttonLayer))
        {
            ButtonPressed?.Invoke();
        }
    }
}
