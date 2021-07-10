using UnityEngine;

public class MultiplingZone : DublicatingZone
{
    [SerializeField] private int _multiplier;

    protected override void Inizialize()
    {
        _spawnBounds = GetComponent<Collider>().bounds;
        _zoneInfo.text = GetZoneInformation();
    }

    protected override string GetZoneInformation()
    {
        return 'x' + _multiplier.ToString();
    }

    protected override void HandleDublication(Stickman human)
    {
        if (human.LastDublicateZone == this) return;

        for (int i = 0; i < _multiplier; i++)
        {
            Stickman spawnedHuman = _stickmanFactory.Create();
            spawnedHuman.transform.position = GetSpawnPosition();
            spawnedHuman.LastDublicateZone = this;
        }
       
        human.LastDublicateZone = this;
    }
}