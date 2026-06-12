using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class NextRoomButton : MonoBehaviour
{
    [SerializeField] private LayerMask _buttonLayer;
    [SerializeField] private LiftChairToNextRoom _chair;

    public event Action ButtonPressed;

    private Camera _camera;
    private bool _isPressable = true;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _chair.PlayerOnPlace += EnableButton;
        GlobalEvents.Won += OnWin;
    }

    private void OnDisable()
    {
        _chair.PlayerOnPlace -= EnableButton;
        GlobalEvents.Won -= OnWin;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isPressable)
        {
            CheckButtonPressed();
        }
    }

    private void OnWin()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        enabled = false;
    }

    private void CheckButtonPressed()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _buttonLayer))
        {
            ButtonPressed?.Invoke();
            _isPressable = false;
        }
    }

    private void EnableButton()
    {
        _isPressable = true;
    }
}
