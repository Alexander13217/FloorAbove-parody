using System.Collections.Generic;
using UnityEngine;

public class EnableAnomaly : MonoBehaviour
{
    [SerializeField] private GameObject[] _anomalies;

    private List<GameObject> _currentAnomalies = new List<GameObject>();
    private System.Random _random = new System.Random();

    private void Awake()
    {
        ResetAnomalyList();
    }

    public void SwitchOnAnomaly()
    {
        int anomalyIndex = _random.Next(0, _currentAnomalies.Count);
        _currentAnomalies[anomalyIndex].SetActive(true);
        _currentAnomalies.RemoveAt(anomalyIndex);

        if(_currentAnomalies.Count <= 0)
        {
            ResetAnomalyList();
        }
    }

    private void ResetAnomalyList()
    {
        _currentAnomalies.Clear();

        foreach (GameObject anomaly in _anomalies)
        {
            _currentAnomalies.Add(anomaly);
        }
    }
}
