using Room;
using UnityEngine;

public class SpawnAnomalyController : MonoBehaviour
{
    [SerializeField] private EnableAnomaly _anomalies;
    [SerializeField] private RoomSpawner _room;

    private AnomalyRoller _roller = new AnomalyRoller();

    private void OnEnable()
    {
        _room.RoomSpawned += TrySpawnAnomaly;
    }

    private void OnDisable()
    {
        _room.RoomSpawned -= TrySpawnAnomaly;
    }

    private void TrySpawnAnomaly(Vector3 roomPosition)
    {   
        _anomalies.gameObject.transform.position = roomPosition;
        if (_roller.ShouldSpawnAnomaly())
        {
            _anomalies.SwitchOnAnomaly();
        }
    }
}
