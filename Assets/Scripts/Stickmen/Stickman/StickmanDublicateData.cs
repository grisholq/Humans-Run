using UnityEngine;

public class StickmanDublicateData : MonoBehaviour, IDublicatable
{
    [SerializeField] private Transform _dublicatableObject;
    public Transform DublicatableObject { get => _dublicatableObject; }
    public DublicatingZone LastDublicateZone { get; set; }

    private void Awake()
    {
        LastDublicateZone = null;
    }

    public void Reset()
    {
        LastDublicateZone = null;
    }
}