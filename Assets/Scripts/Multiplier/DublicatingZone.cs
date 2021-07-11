using TMPro;
using UnityEngine;

public class DublicatingZone : MonoBehaviour
{
    [SerializeField] protected TextMeshPro _zoneInfo;
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

    protected virtual void HandleDublication(Stickman stickman)
    {
        if (stickman.LastDublicateZone == this) return;

        stickman.LastDublicateZone = this;

        Stickman spawnedHuman = _stickmanFactory.Create();
        spawnedHuman.transform.position = GetSpawnPosition(stickman.transform);
        spawnedHuman.LastDublicateZone = this;
    }

    protected Vector3 GetSpawnPosition(Transform origin)
    {
        Vector3 position;

        position.x = _spawnBounds.center.x + Random.Range(-_spawnBounds.size.x / 2, _spawnBounds.size.x / 2);
        position.y = origin.position.y;
        position.z = _spawnBounds.center.z + Random.Range(-_spawnBounds.size.z / 2, _spawnBounds.size.z / 2);

        return position;
    }
}