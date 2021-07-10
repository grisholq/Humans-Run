using TMPro;
using UnityEngine;

public class DublicatingZone : MonoBehaviour
{
    [SerializeField] protected TextMeshPro _zoneInfo;
    [SerializeField, Range(0, 2)] protected float _positionRandomization;
    [SerializeField] protected StickmenFactory _stickmanFactory;
    
    protected Bounds _spawnBounds;

    private void Start()
    {
        _spawnBounds = GetComponent<Collider>().bounds;
        Inizialize();
    }

    private void OnTriggerEnter(Collider other)
    {
        Stickman human;
        if (other.gameObject.TryGetComponent(out human))
        {           
            HandleDublication(human);
        }
    }

    protected virtual void Inizialize()
    {
        _zoneInfo.text = GetZoneInformation();
    }
    
    protected virtual string GetZoneInformation()
    {
        return "+1";
    }

    protected virtual void HandleDublication(Stickman human)
    {
        if (human.LastDublicateZone == this) return;

        human.LastDublicateZone = this;

        Stickman spawnedHuman = _stickmanFactory.Create();
        spawnedHuman.transform.position = GetSpawnPosition();
        spawnedHuman.LastDublicateZone = this;
    }

    protected Vector3 GetSpawnPosition()
    {
        Vector3 position;

        position.x = _spawnBounds.center.x + Random.Range(-_spawnBounds.size.x / 2, _spawnBounds.size.x / 2);
        position.y = 0;
        position.z = _spawnBounds.center.z + Random.Range(-_spawnBounds.size.z / 2, _spawnBounds.size.z / 2);

        return position;
    }
}