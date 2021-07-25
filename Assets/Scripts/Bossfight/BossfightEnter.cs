using UnityEngine;
using UnityEngine.Events;

public class BossfightEnter : MonoBehaviour
{
    [SerializeField] private UnityEvent StickmanEntered;

    private void OnTriggerEnter(Collider other)
    {
        Stickman stickman;
        if(other.TryGetComponent(out stickman))
        {
            Enter(stickman);
        }
    }

    private void Enter(Stickman stickman)
    {
        if (StickmanEntered != null) StickmanEntered.Invoke();
    }
}