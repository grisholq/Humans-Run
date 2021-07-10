using System.Collections.Generic;
using UnityEngine;

public class StickmenFactory : MonoBehaviour, IFactory<Stickman>
{
    [SerializeField] private Stickman _stickman;

    private List<Stickman> _stickmen;

    private void Awake()
    {
        _stickmen = new List<Stickman>();
    }

    public Stickman Create()
    {
        Stickman stickman;

        if (_stickmen.Count != 0)
        {
            stickman = _stickmen[_stickmen.Count - 1];
            _stickmen.RemoveAt(_stickmen.Count - 1);
            stickman.gameObject.SetActive(true);
            return stickman;
        }

        stickman = Instantiate(_stickman);
        stickman.transform.SetParent(transform);
        stickman.Factory = this;

        return stickman;
    }

    public void Recycle(Stickman stickman)
    {
        _stickmen.Add(stickman);
        stickman.gameObject.SetActive(false);
        stickman.transform.SetParent(this.transform);
    }
}