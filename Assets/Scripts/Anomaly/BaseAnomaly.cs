using UnityEngine;

namespace Anomaly
{
    public class BaseAnomaly : MonoBehaviour
    {
        public virtual void Scare()
        {
            //Make scary sound
            Destroy(gameObject);
        }
    }
}

