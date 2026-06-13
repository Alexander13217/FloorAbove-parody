using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowGameStory : MonoBehaviour
{
    [SerializeField] private TMP_Text _textLine;
    [SerializeField] private TMP_Text _textToContinue;
    [SerializeField] private float _delayToShowSymbol;
    [SerializeField] private Button _btn;
    [SerializeField] private AudioSource _typingSource;

    private string[] _storyParts =
    {
        "Вы были молодым отцом. У вас была любящая дочь.",
        "Но однажды вы попали в аварию.",
        "Вы остались инвалидом-колясочником",
        "Ваша дочь не выжила...",
        "После этого вам сняться сны с вашей покойной дочерью которую вы сильно любили.",
        "Сейчас вы старик который досих пор не смерился с этим.",
        "Вы решили потратить последние деньги перед смертью на номер в отеле.",
        "После дороги в отель вы сильно устали, и уснули прямо в инвалидном кресле посреди комнаты"
    };

    private string[] _endStoryParts =
    {
        "После этой ночи у вас остановилось сердце..."
    };

    private IEnumerator ShowTextLine(string text)
    {
        _textLine.text = "";
        _textToContinue.enabled = false;
        _typingSource.Play();
        foreach (char symbol in text)
        {
            _textLine.text += symbol;
            yield return new WaitForSeconds(_delayToShowSymbol);
        }
        _typingSource.Stop();
        _textToContinue.enabled = true;
    }

    public IEnumerator ShowStory()
    {
        foreach (string part in _storyParts)
        {
            yield return StartCoroutine(ShowTextLine(part));
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
    }

    public IEnumerator ShowEndStory()
    {
        foreach (string part in _endStoryParts)
        {
            yield return StartCoroutine(ShowTextLine(part));
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }

        _btn.gameObject.SetActive(true);
    }
}
