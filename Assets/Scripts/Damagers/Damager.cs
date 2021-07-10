using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _damageId;

    protected virtual void ApplyDamage(IDamagable damagable)
    {
        
    }
}