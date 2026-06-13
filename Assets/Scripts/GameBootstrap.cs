using Room;
using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private NextRoomButton _btn;
    [SerializeField] private RoomSpawner _room;
    [SerializeField] private LiftChairToNextRoom _chair;
    [SerializeField] private SpawnAnomalyController _spawner;
    [SerializeField] private AnomalyInRoom _anomaly;
    [SerializeField] private RoomLevel _roomLvl;
    [SerializeField] private GameObject _levelCanvas;

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
        _levelCanvas.transform.position = place;
        _chair.StartMove(place);
        bool isLose = _anomaly.CheckLose();

        if (isLose == true)
        {
            _roomLvl.Reset();
            return;
        }

        bool isWin = _roomLvl.Increase();
        if (isWin == true) return;

        _spawner.TrySpawnAnomaly(place);
    }
}
