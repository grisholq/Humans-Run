using UnityEngine;

public class AddingZone : DublicatingZone
{
    [SerializeField] private int _addAmount;

    private bool _zonePassed;

    protected override void Inizialize()
    {
        base.Inizialize();
        _zonePassed = false;
    }

    protected override string GetZoneInformation()
    {
        return '+' + _addAmount.ToString();
    }

    protected override void HandleDublication(IDublicatable dublicatable)
    {
        if (_zonePassed == true) return;

        dublicatable.LastDublicateZone = this;

        for (int i = 0; i < _addAmount; i++)
        {
            CreateDublicate(dublicatable);
        }

        _zonePassed = true;
    }
}