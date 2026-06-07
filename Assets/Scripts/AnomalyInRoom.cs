using Anomaly;
using UnityEngine;

public class AnomalyInRoom : MonoBehaviour
{
    [SerializeField] private SpawnAnomalyController _spawner;

    public bool HasAnomaly => _anomaly != null;

    private BaseAnomaly _anomaly = null;

    private void OnEnable()
    {
        _spawner.AnomalySpawned += OnAnomalySpawned;
    }

    private void OnDisable()
    {
        _spawner.AnomalySpawned -= OnAnomalySpawned;

        if (_anomaly != null)
        {
            _anomaly.Detected -= OnAnomalyDetected;
        }
    }

    public bool CheckLose()
    {
        if(HasAnomaly == true)
        {
            _anomaly.Detected -= OnAnomalyDetected;
            _anomaly.gameObject.SetActive(false);
            _anomaly = null;
            return true;
        }

        return false;
    }

    private void OnAnomalySpawned(BaseAnomaly anomaly)
    {
        _anomaly = anomaly;

        if (_anomaly != null)
        {
            _anomaly.Detected += OnAnomalyDetected;
        }
    }

    private void OnAnomalyDetected()
    {
        if (_anomaly == null) return;

        _anomaly.Detected -= OnAnomalyDetected;
        _anomaly = null;
    }
}
