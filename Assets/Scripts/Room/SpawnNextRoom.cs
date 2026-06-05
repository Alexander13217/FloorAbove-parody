using UnityEngine;

namespace Room
{
    public class SpawnNextRoom : MonoBehaviour
    {
        [SerializeField] private GameObject _roomPrefab;
        [SerializeField] private Transform _spawnPoint;

        public SpawnNextRoom SpawnRoom()
        {
            GameObject room = Instantiate(_roomPrefab, _spawnPoint.position, Quaternion.identity);
            if(room.TryGetComponent(out SpawnNextRoom r))
            {
                return r;
            }
            return null;
        }
    }
}

