using System;
using System.Collections.Generic;
using UnityEngine;

namespace Room
{
    public class RoomSpawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnNextRoom> _rooms;
        [SerializeField] private NextRoomButton _nextRoomButton;
        [SerializeField] private LiftChairToNextRoom _chair;
        [SerializeField] private GameObject _roomPrefab;

        public event Action<Vector3> RoomSpawned;

        private void OnEnable()
        {
            _nextRoomButton.ButtonPressed += Spawn;
            _chair.PlayerOnPlace += DeleteFirst;
        }

        private void OnDisable()
        {
            _nextRoomButton.ButtonPressed -= Spawn;
            _chair.PlayerOnPlace -= DeleteFirst;
        }

        private void Spawn()
        {
            if (_rooms.Count <= 0) return;

            var room = _rooms[_rooms.Count - 1].SpawnRoom(_roomPrefab);
            _rooms.Add(room);
            RoomSpawned?.Invoke(room.gameObject.transform.position);
        }

        private void DeleteFirst()
        {
            if (_rooms.Count <= 0) return;
            Destroy(_rooms[0].gameObject);
            _rooms.RemoveAt(0);
        }
    }
}

