using UnityEngine;
using UnityEngine.Events;

public class DamageReciever : MonoBehaviour, IDamagable
{
    [SerializeField] private float _damageId;
    [SerializeField] private UnityEvent Death;

    public float DamageId { get => _damageId; }
    
    public void Kill()
    {
        if (Death != null) Death.Invoke();
    }
}