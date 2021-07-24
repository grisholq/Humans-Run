using UnityEngine;

public class MultiplingZone : DublicatingZone
{
    [SerializeField] private int _multiplier;

    protected override string GetZoneInformation()
    {
        return 'x' + _multiplier.ToString();
    }

    protected override void HandleDublication(IDublicatable dublicatable)
    {
        if (dublicatable.LastDublicateZone == this) return;

        dublicatable.LastDublicateZone = this;

        for (int i = 0; i < _multiplier - 1; i++)
        {
            CreateDublicate(dublicatable);
        }            
    }
}