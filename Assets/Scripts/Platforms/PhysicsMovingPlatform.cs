using UnityEngine;

public class PhysicsMovingPlatform : Platform
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Rigidbody _platformRigidbody;

    public override void SetState(float state, bool hold)
    {
        Vector3 delta = (_end.position - _start.position) * state;
        Vector3 position = _start.position + delta;

        _platformRigidbody.MovePosition(position);
    }
}