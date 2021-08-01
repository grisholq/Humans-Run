using UnityEngine;

public class DirectionMover : IMover
{
    private Vector3 _direction;

    public bool AtDestination { get => false; }

    public DirectionMover(Vector3 direction)
    {
        _direction = direction;
    }

    public void Move(IMovable movable)
    {
        if (movable.IsStopped) return;

        Vector3 velocity = movable.Rigidbody.velocity;
        Vector3 movement = _direction * movable.Speed * movable.SpeedMultiplier;

        velocity = ApplyMovementVelocity(velocity, movement);
        
        movable.Rigidbody.velocity = velocity;
    }

    private Vector3 GetMovementVelocity(IMovable movable)
    {
        return _direction * movable.Speed * movable.SpeedMultiplier;
    }

    private Vector3 ApplyMovementVelocity(Vector3 velocity, Vector3 movement)
    {
        velocity.x = movement.x == 0 ? velocity.x : movement.x;
        velocity.y = movement.y == 0 ? velocity.y : movement.y;
        velocity.z = movement.z == 0 ? velocity.z : movement.z;

        return velocity;
    }
}