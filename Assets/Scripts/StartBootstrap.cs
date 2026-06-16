using Player;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartBootstrap : MonoBehaviour
{
    [SerializeField] private ShowGameStory _story;
    [SerializeField] private PlayerLook _player;
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Canvas _textLines;
    [SerializeField] private Canvas _pauseMenu;

    private void OnEnable()
    {
        GlobalEvents.Won += OnWon;
    }

    private void OnDisable()
    {
        GlobalEvents.Won -= OnWon;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        _pauseMenu.gameObject.SetActive(false);
        _player.enabled = false;
        _audio.Pause();
        yield return StartCoroutine(_story.ShowStory());
        _player.enabled = true;
        _audio.Play();
        _textLines.enabled = false;
        _pauseMenu.gameObject.SetActive(true);
    }

    private void OnWon()
    {
        _player.enabled = false;
        _pauseMenu.gameObject.SetActive(false);
        _audio.Pause();
        _textLines.enabled = true;
        StartCoroutine(_story.ShowEndStory());
    }
}
