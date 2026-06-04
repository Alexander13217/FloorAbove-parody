using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _sensitivity;

    private readonly float _maxVerticalRotation = 70f;

    private float _xRotation = 0f;
    private float _yRotation = 0f;
    private Camera _camera;

    private void Awake()
    {
        transform.rotation = Quaternion.identity;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _camera = Camera.main;
    }

    private void Update()
    {
        _xRotation += Input.GetAxis("Mouse X") * _sensitivity;
        _yRotation += Input.GetAxis("Mouse Y") * _sensitivity;

        transform.rotation = Quaternion.Euler(0f, _xRotation, 0f);
        _yRotation = Mathf.Clamp(_yRotation, -_maxVerticalRotation, _maxVerticalRotation);
        _camera.transform.rotation = Quaternion.Euler(-_yRotation, _xRotation, 0f);
    }
}
