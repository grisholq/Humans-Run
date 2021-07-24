using UnityEngine;

public class ToDirectoinMoverChanger : MoverChanger
{
    [SerializeField] private Vector3 _direction;

    public override void ChangeMover(IMovable movable)
    {
        base.ChangeMover(movable);
        movable.Mover = new DirectionMover(_direction);
    }
}