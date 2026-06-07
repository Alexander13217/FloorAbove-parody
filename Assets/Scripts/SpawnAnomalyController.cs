using Anomaly;
using Room;
using System;
using UnityEngine;

public class SpawnAnomalyController : MonoBehaviour
{
    [SerializeField] private EnableAnomaly _anomalies;

    public event Action<BaseAnomaly> AnomalySpawned;

    private AnomalyRoller _roller = new AnomalyRoller();

    public void TrySpawnAnomaly(Vector3 roomPosition)
    {   
        _anomalies.gameObject.transform.position = roomPosition;
        if (_roller.ShouldSpawnAnomaly())
        {
            AnomalySpawned?.Invoke(_anomalies.SwitchOnAnomaly());
            return;
        }
        AnomalySpawned?.Invoke(null);
    }
}
