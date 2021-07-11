using UnityEngine;
using UnityEngine.Events;

public class DamageReciever : MonoBehaviour, IDamagable
{
    [SerializeField] private float _damageId;
    [SerializeField] private UnityEvent<float> DamageRecieved;

    public float DamageId { get => _damageId; }
 
    public void Damage(float damage)
    {
        if (DamageRecieved != null) DamageRecieved.Invoke(damage);
    }
}