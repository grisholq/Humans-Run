using UnityEngine;

public class ToTargetMover : IMover
{
    private Transform _target;
    private float _stopDistance;

    public bool AtDestination { get; private set; }

    public ToTargetMover(Transform target, float stopDistance)
    {
        _target = target;
        _stopDistance = stopDistance;
    }

    public void Move(IMovable movable)
    {
        if (CannotMove(movable)) return;

        movable.Transform.LookAt(_target);

        if (ReachedDestination(movable))
        {
            AtDestination = true;
            return;
        }

        AtDestination = false;
        movable.Transform.position += GetMoveDelta(movable);
    }

    private bool CannotMove(IMovable movable)
    {
        return _target == null && movable.IsStopped;
    }

    private bool ReachedDestination(IMovable movable)
    {
        return GetDistanceToTarget(movable) <= _stopDistance;
    }

    private float GetDistanceToTarget(IMovable movable)
    {
        return Vector3.Distance(movable.Transform.position, _target.transform.position);
    }

    private Vector3 GetMoveDelta(IMovable movable)
    {
        return GetTargetDirection(movable) * GetSpeed(movable);
    }

    private Vector3 GetTargetDirection(IMovable movable)
    {
        return (_target.position - movable.Transform.position).normalized;
    }

    private float GetSpeed(IMovable movable)
    {
        return movable.Speed * movable.SpeedMultiplier * Time.deltaTime;
    }
}