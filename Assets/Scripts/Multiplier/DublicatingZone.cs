using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DublicatingZone : MonoBehaviour
{
    [SerializeField] private UnityEvent<DublicatingZone> ZoneEnter;
    [SerializeField] protected TextMeshPro _zoneInfo;
    [SerializeField] protected float _spawnRandomness;

    private void Start()
    {
        Inizialize();
    }

    private void OnTriggerEnter(Collider other)
    {
        IDublicatable dublicatable;
        if (other.gameObject.TryGetComponent(out dublicatable))
        {
            if (ZoneEnter != null) ZoneEnter.Invoke(this);
            HandleDublication(dublicatable);
        }
    }

    public void Disable()
    {
        GetComponent<DublicatingZoneDisabler>().Disable();
    }

    protected virtual void Inizialize()
    {
        _zoneInfo.text = GetZoneInformation();
    }
    
    protected virtual string GetZoneInformation()
    {
        return "+1";
    }

    protected virtual void HandleDublication(IDublicatable dublicatable)
    {
        if (dublicatable.LastDublicateZone == this) return;

        dublicatable.LastDublicateZone = this;
        CreateDublicate(dublicatable);
    }

    protected void CreateDublicate(IDublicatable dublicatable)
    {
        Transform dublicate = dublicatable.CreateDublicate();
        dublicate.position = GetSpawnPosition(dublicate.transform);
    }

    protected Vector3 GetSpawnPosition(Transform origin)
    {
        Vector3 position = origin.position;

        position.x += Random.Range(-_spawnRandomness, _spawnRandomness);
        position.z += Random.Range(-_spawnRandomness, _spawnRandomness);

        return position;
    }
}