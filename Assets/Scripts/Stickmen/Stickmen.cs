using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Stickmen : MonoBehaviour
{
    [SerializeField] private UnityEvent<Stickman> StickmanAdded;
    [SerializeField] private UnityEvent NoStickmenLeft;

    private List<Stickman> _list;

    public List<Stickman> List { get => _list; }
    public Stickman First { get; set; }

    private void Awake()
    {
        _list = new List<Stickman>();
        Stickman[] startingStickmen = GetComponentsInChildren<Stickman>();

        foreach (var stickman in startingStickmen)
        {
            AddStickman(stickman);
        }     
    }

    public void AddStickman(Stickman stickman)
    {
        if(!_list.Contains(stickman))
        {
            _list.Add(stickman);
            if (StickmanAdded != null) StickmanAdded.Invoke(stickman);
        }
    }

    public void RemoveStickman(Stickman stickman)
    {
        _list.Remove(stickman);
        if(_list.Count == 0)
        {
            if(NoStickmenLeft != null)NoStickmenLeft.Invoke();
        }
    }
}