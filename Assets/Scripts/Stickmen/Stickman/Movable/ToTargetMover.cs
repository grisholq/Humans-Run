using UnityEngine;

public class ToTargetMover : IMover
{
    private Transform _target;

    private const float _stopDistance = 1f;

    public ToTargetMover(Transform target)
    {
        _target = target;
    }

    public void Move(IMovable movable)
    {
        Vector3 direction = GetTargetDirection(movable);

        movable.Transform.position = Vector3.MoveTowards(movable.Transform.position, direction, movable.Speed);
    }

    private Vector3 GetTargetDirection(IMovable movable)
    {
        return (_target.position - movable.Transform.position).normalized;
    }
}