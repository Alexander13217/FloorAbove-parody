using Anomaly;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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

    public BaseAnomaly SwitchOnAnomaly()
    {
        int anomalyIndex = _random.Next(0, _currentAnomalies.Count);
        var anomaly = _currentAnomalies[anomalyIndex].GetComponent<BaseAnomaly>();
        _currentAnomalies[anomalyIndex].SetActive(true);
        _currentAnomalies.RemoveAt(anomalyIndex);

        if(_currentAnomalies.Count <= 0)
        {
            ResetAnomalyList();
        }

        return anomaly;
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
