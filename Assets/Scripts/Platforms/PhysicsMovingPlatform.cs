using UnityEngine;

public class PhysicsMovingPlatform : Platform
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Rigidbody _platformRigidbody;

    public override void SetState(float state, bool hold)
    {
        float currentState = hold ? Mathf.Clamp(state * _speed, 0, 1): state ;
        Vector3 delta = (_end.position - _start.position) * currentState;       
        Vector3 position = _start.position + delta;

        _platformRigidbody.MovePosition(position);
    }
}