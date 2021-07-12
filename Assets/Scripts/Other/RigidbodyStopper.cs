using UnityEngine;

[RequireComponent(typeof(Collider))]
public class RigidbodyStopper : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rigidbody;
        
        if(other.TryGetComponent<Rigidbody>(out rigidbody))
        {
            rigidbody.velocity = Vector3.zero;
        }
    }
}