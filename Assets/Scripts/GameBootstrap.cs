using Room;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private NextRoomButton _btn;
    [SerializeField] private RoomSpawner _room;
    [SerializeField] private LiftChairToNextRoom _chair;
    [SerializeField] private SpawnAnomalyController _spawner;

    private void OnEnable()
    {
        _btn.ButtonPressed += NextFloorSpawn;
    }

    private void OnDisable()
    {
        _btn.ButtonPressed -= NextFloorSpawn;
    }

    private void NextFloorSpawn()
    {
        var place = _room.Spawn();
        _chair.StartMove(place);
        _spawner.TrySpawnAnomaly(place);
    }
}
