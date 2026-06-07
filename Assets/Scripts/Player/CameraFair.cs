using Player;
using System;
using System.Collections;
using UnityEngine;

public class CameraFair : MonoBehaviour
{
    [SerializeField] private PlayerLook _playerLook;

    private readonly float _defaultFOV = 60f;
    private readonly float _screamerDurationFOV = 40f;

    private Camera _camera;
    private Coroutine _focus;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void StartFocusing(float duration)
    {
        if (_focus != null)
        {
            StopCoroutine(_focus);
        }
        _focus = StartCoroutine(Focus(duration));
    }

    private IEnumerator Focus(float duration)
    {
        _playerLook.enabled = false;
        float t = 0f;
        _camera.fieldOfView = _screamerDurationFOV;
        while (t <= duration)
        {
            t += Time.deltaTime;
            yield return null;
        }   
        _camera.fieldOfView = _defaultFOV;
        _playerLook.enabled = true;
        _focus = null;
    }
}
