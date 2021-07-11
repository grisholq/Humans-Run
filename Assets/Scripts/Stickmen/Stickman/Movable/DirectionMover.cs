using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionMover : IMover
{
    private Vector3 _direction;

    public DirectionMover(Vector3 direction)
    {
        _direction = direction;
    }

    public void Move(IMovable movable)
    {
        Vector3 velocity = movable.Rigidbody.velocity;
        Vector3 additionalVelocity = _direction * movable.Speed;

        velocity.x = additionalVelocity.x == 0 ? velocity.x : additionalVelocity.x ;
        velocity.y = additionalVelocity.y == 0 ? velocity.y : additionalVelocity.y;
        velocity.z = additionalVelocity.z == 0 ? velocity.z : additionalVelocity.z ;

        movable.Rigidbody.velocity = velocity * movable.Speed;
    }
}