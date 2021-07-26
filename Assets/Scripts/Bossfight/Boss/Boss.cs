using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    [SerializeField] private UnityEvent Death;

    public int AimsCount { get; set; }

    public void Die()
    {
        if (Death != null) Death.Invoke();
        Destroy(gameObject);
    }
}