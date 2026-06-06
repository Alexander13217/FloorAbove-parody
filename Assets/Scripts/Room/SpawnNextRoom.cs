using UnityEngine;

namespace Room
{
    public class SpawnNextRoom : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPoint;

        public SpawnNextRoom SpawnRoom(GameObject roomPrefab)
        {
            GameObject room = Instantiate(roomPrefab, _spawnPoint.position, Quaternion.identity);
            if(room.TryGetComponent(out SpawnNextRoom r))
            {
                return r;
            }
            return null;
        }
    }
}

