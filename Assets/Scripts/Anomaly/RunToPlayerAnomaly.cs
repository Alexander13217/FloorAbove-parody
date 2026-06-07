using System.Collections;
using UnityEngine;

namespace Anomaly
{
    public class RunToPlayerAnomaly : BaseAnomaly
    {
        [SerializeField] private float _offset;

        private Coroutine _move = null;

        private void OnDisable()
        {
            _move = null;
        }

        public override void Scare()
        {
            if (_move != null) return;

            Vector3 cameraPosition = Camera.main.transform.position;

            float distanceToCamera = Vector3.Distance
            (   
                transform.position,
                cameraPosition
            );

            float moveSpeed = distanceToCamera / ClipDuration;
            
            Vector3 direction = (cameraPosition - transform.position).normalized;
            _move = StartCoroutine(MoveToCamera(cameraPosition, direction, moveSpeed, distanceToCamera));
        }

        private IEnumerator MoveToCamera
        (Vector3 cameraPosition, Vector3 direction, float speed, float distance)
        {
            Vector3 startPos = transform.localPosition;
            base.Scare();
            while (distance >= _offset)
            {
                Vector3 move = direction * speed * Time.deltaTime;
                transform.position += move;
                distance -= move.magnitude;
                yield return null;
            }
            _move = null;
            transform.localPosition = startPos;
        }
    }
}

