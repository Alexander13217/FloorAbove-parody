using Unity.VisualScripting;
using UnityEngine;

public class SpawnAnomalyController : MonoBehaviour
{
    [SerializeField] private EnableAnomaly _anomalies;
    private AnomalyRoller _roller = new AnomalyRoller();

    private void TrySpawnAnomaly()
    {
        bool need = _roller.ShouldSpawnAnomaly();
        if (need)
        {
            _anomalies.SwitchOnAnomaly();
        }
    }
}
