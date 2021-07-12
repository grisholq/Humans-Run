using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class TriggerEventsTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent EnteredCollision;
    [SerializeField] private UnityEvent ExitedCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if(EnteredCollision != null) EnteredCollision.Invoke();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (ExitedCollision != null) ExitedCollision.Invoke();
    }
}