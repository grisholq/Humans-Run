using UnityEngine;
using System.Collections.Generic;

public class DamagerAimsFinder : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private int _aimsLayer;

    public List<IDamagable> FindAims()
    {
        List<Collider> colliders = GetAimsColliders();
        List<IDamagable> damagables = new List<IDamagable>(colliders.Count);

        for (int i = 0; i < colliders.Count; i++)
        {
            if(colliders[i].TryGetComponent(out IDamagable damagable))
            {
                damagables.Add(damagable);
            }
        }

        return damagables;
    }

    private List<Collider> GetAimsColliders()
    {
        Collider[] colliders =  Physics.OverlapBox(transform.position, GetRange(), Quaternion.identity, _aimsLayer);
        return new List<Collider>(colliders);
    }

    private Vector3 GetRange()
    {
        return Vector3.one * _range;
    }
}