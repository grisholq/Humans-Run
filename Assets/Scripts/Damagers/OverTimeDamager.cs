using UnityEngine;

public class OverTimeDamager : Damager
{
    private void OnTriggerStay(Collider other)
    {
        IDamagable damagable;

        if (other.TryGetComponent<IDamagable>(out damagable))
        {
            ApplyDamage(damagable);
        }
    }

    protected override void ApplyDamage(IDamagable damagable)
    {
        if (damagable.DamageId == _damageId) return;

        damagable.Damage(_damage * Time.deltaTime);
    }
}