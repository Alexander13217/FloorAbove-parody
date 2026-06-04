using UnityEngine;

namespace Player
{
    public class DetectAnomaly : MonoBehaviour
    {
        [SerializeField] private LayerMask _anomaly;

        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Select();
            }
        }

        private void Select()
        {
            Ray ray = _camera.ViewportPointToRay(new Vector2(0.5f, 0.5f));

            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _anomaly))
            {
                if(hit.collider.TryGetComponent(out Anomaly.BaseAnomaly a))
                {
                    a.Scare();
                }
            }
        }
    }
}


