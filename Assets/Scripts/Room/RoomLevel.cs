using TMPro;
using UnityEngine;

public class RoomLevel : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;

    private int _level = 1;

    private void Awake()
    {
        _levelText.text = "1";
    }

    public void Increase()
    {
        _level += 1;
        if(_level > 4)
        {
            GlobalEvents.Win();
        }
        _levelText.text = System.Convert.ToString(_level);
    }

    public void Reset()
    {
        _level = 1;
        _levelText.text = System.Convert.ToString(_level);
    }
}
