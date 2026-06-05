using System;
using System.Collections;
using UnityEngine;

public class LiftChairToNextRoom : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Room.RoomController _r;

    public event Action PlayerOnPlace;

    private Coroutine _move = null;

    private void OnEnable()
    {
        _r.RoomSpawned += StartMove;
    }

    private void OnDisable()
    {
        _r.RoomSpawned -= StartMove;
    }

    public void StartMove(Vector3 target)
    {
        if (_move != null) return;
        _move = StartCoroutine(Lift(target));
    }

    private IEnumerator Lift(Vector3 target)
    {
        while(Vector3.Distance(transform.position, target) >= 0.1f)
        {
            Vector3 direction = (target - transform.position);
            Vector3 move = direction * _speed * Time.deltaTime;
            transform.position += move;
            yield return null;
        }
        _move = null;
        PlayerOnPlace?.Invoke();
    }
}
