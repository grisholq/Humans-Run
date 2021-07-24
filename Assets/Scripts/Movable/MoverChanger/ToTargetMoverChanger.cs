using UnityEngine;

public class ToTargetMoverChanger : MoverChanger
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _stopDistance;

    public override void ChangeMover(IMovable movable)
    {
        base.ChangeMover(movable);
        movable.Mover = new ToTargetMover(_target, _stopDistance);
    }
}