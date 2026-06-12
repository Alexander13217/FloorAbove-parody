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
        StartCoroutine(StartGame());
    }

    private IEnumerator StartGame()
    {
        _player.enabled = false;
        _audio.Pause();
        yield return StartCoroutine(_story.ShowStory());
        _player.enabled = true;
        _audio.Play();
        _textLines.enabled = false;
    }

    private void OnWon()
    {
        _player.enabled = false;
        _audio.Pause();
        _textLines.enabled = true;
        StartCoroutine(_story.ShowEndStory());
    }
}
