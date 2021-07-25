using UnityEngine;

public class ToTargetMover : IMover
{
    private Transform _target;
    private float _stopDistance;

    private bool _atDestination;

    public bool AtDestination { get => _atDestination; }

    public ToTargetMover(Transform target, float stopDistance)
    {
        _target = target;
        _stopDistance = stopDistance;
    }

    public void Move(IMovable movable)
    {
        if (_target == null) return;

        if (movable.IsStopped) return;

        movable.Transform.LookAt(_target);


        if (GetDistanceToTarget(movable) <= _stopDistance)
        {
            _atDestination = true;
            return;
        }
        else
        {
            _atDestination = false; 
            
            Vector3 direction = GetTargetDirection(movable);
            movable.Transform.position += direction * movable.Speed * movable.SpeedMultiplier * Time.deltaTime;
        } 
    }

    private Vector3 GetTargetDirection(IMovable movable)
    {
        return (_target.position - movable.Transform.position).normalized;
    }
    private float GetDistanceToTarget(IMovable movable)
    {
        return Vector3.Distance(movable.Transform.position, _target.transform.position);
    }
}