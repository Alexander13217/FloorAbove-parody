using System;
using System.Collections.Generic;
using UnityEngine;

namespace Room
{
    public class RoomController : MonoBehaviour
    {
        [SerializeField] private List<SpawnNextRoom> _rooms;
        [SerializeField] private Test _t;
        [SerializeField] private LiftChairToNextRoom _p;

        public event Action<Vector3> RoomSpawned;

        private void OnEnable()
        {
            _t.Pressed += Spawn;
            _p.PlayerOnPlace += DeleteFirst;
        }

        private void OnDisable()
        {
            _t.Pressed -= Spawn;
            _p.PlayerOnPlace -= DeleteFirst;
        }

        private void Spawn()
        {
            if (_rooms.Count <= 0) return;

            var room = _rooms[_rooms.Count - 1].SpawnRoom();
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

