using UnityEngine;

public class Stickman : MonoBehaviour, IDublicatable, IRecyclable<Stickman>, IMovable
{
    [SerializeField] private float _speed;
    [SerializeField] private StickmenFactory _factory;

    [field: SerializeField] public bool IsMoving { get; set; }  
    [field: SerializeField] public bool IsFighting { get; set; }
    public Rigidbody Rigidbody { get; set; }
    public DublicatingZone LastDublicateZone { get; set; }   
    public StickmanMover Mover { get => GetComponent<StickmanMover>(); }
    public IFactory<Stickman> Factory { get; set; }
    public float Speed { get => _speed; set => _speed = value; }

    private void Awake()
    {
        Factory = _factory;
        Rigidbody = GetComponent<Rigidbody>();
    }

}