using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Stickmen : MonoBehaviour
{
    [SerializeField] private List<Stickman> _startStickmen;

    public List<Stickman> StickmenList { get; set; }
    public Stickman First { get; set; }

    private void Awake()
    {
        StickmenList = new List<Stickman>();

        foreach (var stickman in _startStickmen)
        {
            StickmenList.Add(stickman);
        }     
    }
}