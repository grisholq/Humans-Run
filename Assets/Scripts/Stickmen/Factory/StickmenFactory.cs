using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stickmen))]
public class StickmenFactory : MonoBehaviour, IFactory<Stickman>
{
    [SerializeField] private Stickman _stickman;

    private List<Stickman> _stickmenStorage;

    private Stickmen _stickmen;

    private void Awake()
    {
        _stickmen = GetComponent<Stickmen>();
        _stickmenStorage = new List<Stickman>();
    }

    public Stickman Create()
    {
        Stickman stickman;

        if (_stickmenStorage.Count != 0)
        {
            stickman = _stickmenStorage[_stickmenStorage.Count - 1];
            _stickmenStorage.RemoveAt(_stickmenStorage.Count - 1);
            stickman.gameObject.SetActive(true);
            stickman.Factory = this;
            _stickmen.StickmenList.Add(stickman);
            return stickman;
        }

        stickman = Instantiate(_stickman);
        stickman.transform.SetParent(transform);
        stickman.Factory = this;

        _stickmen.StickmenList.Add(stickman);

        return stickman;
    }

    public void Recycle(Stickman stickman)
    {
        _stickmenStorage.Add(stickman);
        _stickmen.StickmenList.Remove(stickman);
        stickman.gameObject.SetActive(false);
        stickman.Reset();
    }
}