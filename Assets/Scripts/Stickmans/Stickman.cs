using UnityEngine;

public class Stickman : MonoBehaviour, IDublicatable, IRecyclable<Stickman>
{
    public DublicatingZone LastDublicateZone { get; set; }   
    public StickmanMover Mover { get => GetComponent<StickmanMover>(); }
    [field: SerializeField] public IFactory<Stickman> Factory { get; set; }
}