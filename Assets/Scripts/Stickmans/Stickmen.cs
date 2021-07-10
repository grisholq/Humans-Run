using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Stickmen : MonoBehaviour
{
    public List<Stickman> StickmenList { get => GetComponentsInChildren<Stickman>().ToList(); }
    public Stickman First { get; set; }
}