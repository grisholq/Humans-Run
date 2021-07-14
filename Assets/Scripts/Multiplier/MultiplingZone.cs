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

    protected override void HandleDublication(Stickman stickman)
    {
        if (stickman.LastDublicateZone == this) return;

        for (int i = 0; i < _multiplier - 1; i++)
        {
            Stickman spawnedHuman = _stickmanFactory.Create();
            spawnedHuman.transform.position = GetSpawnPosition(stickman.transform);
            spawnedHuman.LastDublicateZone = this;
        }
       
        stickman.LastDublicateZone = this;
    }
}