using UnityEngine;

public class AddingZone : DublicatingZone
{
    [SerializeField] private int _addAmount;

    private bool _zonePassed;

    protected override void Inizialize()
    {
        _spawnBounds = GetComponent<Collider>().bounds;
        _zonePassed = false;
        _zoneInfo.text = GetZoneInformation();
    }

    protected override string GetZoneInformation()
    {
        return '+' + _addAmount.ToString();
    }

    protected override void HandleDublication(Stickman stickman)
    {
        if (_zonePassed == true) return;
      
        for (int i = 0; i < _addAmount; i++)
        {
            Stickman spawnedHuman = _stickmanFactory.Create();
            spawnedHuman.transform.position = GetSpawnPosition(stickman.transform);
            spawnedHuman.LastDublicateZone = this;
        }

        stickman.LastDublicateZone = this;
        _zonePassed = true;
    }
}