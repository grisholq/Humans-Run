using UnityEngine;

public class Stickman : MonoBehaviour, IDublicatable, IRecyclable<Stickman>, IMovable
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isStopped;
    [SerializeField] private StickmenFactory _factory;

    public int AimsCount { get; set; }
    public Health Health { get; set; }
    
    public DublicatingZone LastDublicateZone { get; set; }   
    public IFactory<Stickman> Factory { get; set; }

    public IMover Mover { get; set; }
    public Rigidbody Rigidbody { get; set; }
    public Transform Transform { get; set; } 
    public float Speed { get => _speed; set => _speed = value; }
    public bool IsStopped { get => _isStopped; set => _isStopped = value; }

    private void Awake()
    {
        Factory = _factory;
       
        Health = GetComponent<Health>();

        Transform = transform;
        Rigidbody = GetComponent<Rigidbody>();
    }

    public void Move()
    {
        Mover.Move(this);
    }

    public void Reset()
    {
        Health.HealToMax();
        LastDublicateZone = null;
    }
}