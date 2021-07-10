using UnityEngine;

public class InstantDamager : Damager
{
    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagable;

        if(other.TryGetComponent<IDamagable>(out damagable))
        {
            ApplyDamage(damagable);
        }
    }

    protected override void ApplyDamage(IDamagable damagable)
    {
        if (damagable.DamageId == _damageId) return;

        damagable.Damage(_damage);
    }
}