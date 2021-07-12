using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Stickmen : MonoBehaviour
{
    [SerializeField] private UnityEvent<Stickman> _stickmanAdded;

    [SerializeField] private List<Stickman> _startStickmen;

    private List<Stickman> _list;

    public List<Stickman> List { get => _list; }
    public Stickman First { get; set; }

    private void Awake()
    {
        _list = new List<Stickman>();

        foreach (var stickman in _startStickmen)
        {
            AddStickman(stickman);
        }     
    }

    public void AddStickman(Stickman stickman)
    {
        if(!_list.Contains(stickman))
        {
            _list.Add(stickman);
            if (_stickmanAdded != null) _stickmanAdded.Invoke(stickman);
        }
    }

    public void RemoveStickman(Stickman stickman)
    {
        _list.Remove(stickman);
    }
}