using TMPro;
using UnityEngine;

public class DublicatingZone : MonoBehaviour
{
    [SerializeField] protected TextMeshPro _zoneInfo;
    [SerializeField] protected StickmenFactory _stickmanFactory;
    [SerializeField] protected float _spawnRandomness;
    
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
        Vector3 position = origin.position;

        position.x += Random.Range(-_spawnRandomness, _spawnRandomness);
        position.z += Random.Range(-_spawnRandomness, _spawnRandomness);

        return position;
    }
}