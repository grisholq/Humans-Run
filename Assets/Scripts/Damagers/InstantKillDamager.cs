using UnityEngine;

public class InstantKillDamager : Damager
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
        damagable.Kill();
    }
}