using System;
using System.Collections.Generic;
using UnityEngine;

namespace Room
{
    public class RoomSpawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnNextRoom> _rooms;
        [SerializeField] private LiftChairToNextRoom _chair;
        [SerializeField] private GameObject _roomPrefab;

        private void OnEnable()
        {
            _chair.PlayerOnPlace += DeleteFirst;
        }

        private void OnDisable()
        {
            _chair.PlayerOnPlace -= DeleteFirst;
        }

        public Vector3 Spawn()
        {
            if (_rooms.Count <= 0) return Vector3.zero;

            var room = _rooms[_rooms.Count - 1].SpawnRoom(_roomPrefab);
            _rooms.Add(room);
            return room.gameObject.transform.position;
        }

        private void DeleteFirst()
        {
            if (_rooms.Count <= 0) return;
            Destroy(_rooms[0].gameObject);
            _rooms.RemoveAt(0);
        }
    }
}

