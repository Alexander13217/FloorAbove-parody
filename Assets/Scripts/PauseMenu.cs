using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _settingsPanel;

    private bool _isPaused = false;
    private bool _isSettingsOpened = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(_isPaused == false)
            {
                Pause();
                return;
            }
            if(_isSettingsOpened == false)
            {
                Resume();
            }
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

    public void ShowSettings()
    {
        _isSettingsOpened = true;
        _settingsPanel.SetActive(true);
        _pausePanel.SetActive(false);
    }

    public void HideSettings()
    {
        _isSettingsOpened = false;
        _settingsPanel.SetActive(false);
        _pausePanel.SetActive(true);
    }
}
