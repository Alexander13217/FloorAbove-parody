using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private bool _isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused == false)
            {
                Pause();
                return;
            }
            Resume();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        GlobalEvents.Pause();
        _isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GlobalEvents.UnPause();
        _isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _pausePanel.SetActive(false);
    }
}
