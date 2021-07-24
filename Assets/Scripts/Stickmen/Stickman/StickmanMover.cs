using UnityEngine;

public class StickmanMover : MonoBehaviour, IMovable, IDublicatablePart<StickmanMover>
{
    public Rigidbody Rigidbody { get; set; }
    public Transform Transform { get; set; }
    [field: SerializeField] public float Speed { get; set; }
    [field: SerializeField] public float SpeedMultiplier { get; set; }
    [field: SerializeField] public bool IsStopped { get; set; }
    
    public IMover Mover { get; set; }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Transform = transform;
        Mover = new NoMover();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Mover.Move(this);
    }

    public void Stop()
    {
        Rigidbody.velocity = Vector3.zero;
    }

    public void Dublicate(StickmanMover to)
    {
        to.Speed = Speed;
        to.SpeedMultiplier = SpeedMultiplier;
        to.IsStopped = IsStopped;
        to.Mover = Mover;
    }
}