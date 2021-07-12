using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stickmen))]
public class StickmenFactory : MonoBehaviour, IFactory<Stickman>
{
    [SerializeField] private Stickman _prefab;

    private List<Stickman> _unactiveStickmen;

    private Stickmen _stickmen;

    private void Awake()
    {
        _stickmen = GetComponent<Stickmen>();
        _unactiveStickmen = new List<Stickman>();
    }

    public Stickman Create()
    {
        Stickman stickman = GetStickman();

        stickman.gameObject.SetActive(true);
        stickman.Factory = this;
        _stickmen.AddStickman(stickman);

        return stickman;
    }

    public void Recycle(Stickman stickman)
    {
        _unactiveStickmen.Add(stickman);
        _stickmen.RemoveStickman(stickman);
        stickman.gameObject.SetActive(false);
        stickman.Reset();
    }

    private Stickman GetStickman()
    {
        Stickman stickman;

        if (_unactiveStickmen.Count != 0)
        {
            stickman = _unactiveStickmen[_unactiveStickmen.Count - 1];
            _unactiveStickmen.RemoveAt(_unactiveStickmen.Count - 1);            
        }
        else
        {
            stickman = Instantiate(_prefab);
        }

        return stickman;
    }
}