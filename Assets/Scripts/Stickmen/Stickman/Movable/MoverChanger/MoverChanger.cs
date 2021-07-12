using UnityEngine;

public class MoverChanger : MonoBehaviour
{
    [SerializeField] protected float _speedMultiplier;

    public virtual void ChangeMover(IMovable movable)
    {
        movable.Speed *= _speedMultiplier;
    }
}