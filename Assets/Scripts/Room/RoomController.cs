using Room;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] private List<SpawnNextRoom> _rooms;

    private void Spawn()
    {
        if (_rooms.Count <= 0) return;

        if (_rooms[_rooms.Count - 1] != null)
        {
            var room = _rooms[_rooms.Count - 1].SpawnRoom();
            _rooms.Add(room);
        }
    }

    private void DeleteFirst()
    {
        if (_rooms.Count <= 0) return;
        Destroy(_rooms[0].gameObject);
        _rooms.RemoveAt(0);
    }
}
