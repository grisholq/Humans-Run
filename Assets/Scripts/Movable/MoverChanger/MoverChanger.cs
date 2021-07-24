using UnityEngine;

public class MoverChanger : MonoBehaviour
{
    [SerializeField] protected float _speedMultiplier;
    
    private void OnTriggerEnter(Collider other)
    {
        IMovable movable;

        if (other.TryGetComponent<IMovable>(out movable))
        {
            ChangeMover(movable);
        }
    }

    public virtual void ChangeMover(IMovable movable)
    {
        movable.SpeedMultiplier = _speedMultiplier;
    }
}