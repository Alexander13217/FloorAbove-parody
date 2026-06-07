using Room;
using UnityEngine;

public class SpawnAnomalyController : MonoBehaviour
{
    [SerializeField] private EnableAnomaly _anomalies;

    private AnomalyRoller _roller = new AnomalyRoller();

    public void TrySpawnAnomaly(Vector3 roomPosition)
    {   
        _anomalies.gameObject.transform.position = roomPosition;
        if (_roller.ShouldSpawnAnomaly())
        {
            _anomalies.SwitchOnAnomaly();
        }
    }
}
