using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private UnityEvent Death;

    public bool IsFighting { get; set; }

    private void Start()
    {
        IsFighting = false;
    }

    public void Die()
    {
        if (Death != null) Death.Invoke();
        Destroy(gameObject);
    }
}