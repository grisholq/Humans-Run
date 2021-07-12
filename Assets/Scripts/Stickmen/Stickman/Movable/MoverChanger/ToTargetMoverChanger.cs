using UnityEngine;

public class ToTargetMoverChanger : MoverChanger
{
    [SerializeField] private Transform _target;

    private void OnTriggerEnter(Collider other)
    {
        IMovable movable;

        if(other.TryGetComponent<IMovable>(out movable))
        {
            ChangeMover(movable);
        }
    }

    public override void ChangeMover(IMovable movable)
    {
        base.ChangeMover(movable);
        movable.Mover = new ToTargetMover(_target);
    }
}