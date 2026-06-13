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

    public bool Increase()
    {
        _level += 1;
        if(_level > 13)
        {
            GlobalEvents.Win();
            return true;
        }
        _levelText.text = System.Convert.ToString(_level);
        return false;
    }

    public void Reset()
    {
        _level = 1;
        _levelText.text = System.Convert.ToString(_level);
    }
}
