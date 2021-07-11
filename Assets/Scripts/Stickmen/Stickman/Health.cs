using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent Died;
    [SerializeField] private float _value;
    [SerializeField] private float _max;
    public float Value 
    {
        get => _value;
        set
        {
            _value = value;
            _value = Mathf.Clamp(_value, 0, _max);
        }
    }

    public void Heal(float heal)
    {
        Value += heal;
    }
    
    public void HealToMax()
    {
        Value = _max;
    }

    public void Damage(float damage)
    {
        Value -= damage;

        if (Value <= 0) Die();
    }

    public void Die()
    {
        if (Died != null) Died.Invoke();
    }
}