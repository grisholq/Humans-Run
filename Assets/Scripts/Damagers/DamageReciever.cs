using UnityEngine;
using UnityEngine.Events;

public class DamageReciever : MonoBehaviour, IDamagable
{
    [SerializeField] private float _health;
    [SerializeField] private float _damageId;
    [SerializeField] private UnityEvent Died;

    public float DamageId { get => _damageId; }

    public float Health 
    { 
        get => _health;
        
        set
        {
            _health = value;
            _health = Mathf.Max(0, _health);
        }
    }
 
    public void Damage(float damage)
    {
        Health -= damage;
        if (Health <= 0) Die();
    }

    public void Die()
    {
        if (Died != null) Died.Invoke();
    }
}