using UnityEngine;

[RequireComponent(typeof(Collider))]
public class RigidbodyStopper : MonoBehaviour
{
    [Header("Ignored")]

    [SerializeField] private bool _plusX;
    [SerializeField] private bool _minusX;

    [SerializeField] private bool _plusY;
    [SerializeField] private bool _minusY;

    [SerializeField] private bool _plusZ;
    [SerializeField] private bool _minusZ;

    private void OnTriggerEnter(Collider other)
    {
        TryStopRigidbody(other.transform);
    }

    private void OnTriggerStay(Collider other)
    {
        TryStopRigidbody(other.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        TryStopRigidbody(collision.transform);
    }

    private void OnCollisionStay(Collision collision)
    {
        TryStopRigidbody(collision.transform);
    }

    private void TryStopRigidbody(Transform transform)
    {
        Rigidbody rigidbody;

        if (!transform.TryGetComponent<Rigidbody>(out rigidbody)) return;

        Vector3 velocity = rigidbody.velocity;

        velocity.x = GetIgnoredAxis(velocity.x, _plusX, _minusX);
        velocity.y = GetIgnoredAxis(velocity.y, _plusY, _minusY);
        velocity.z = GetIgnoredAxis(velocity.z, _plusZ, _minusZ);

        rigidbody.velocity = velocity;
    }

    private float GetIgnoredAxis(float value, bool plusIgnore, bool minusIgnore)
    {
        if(value >= 0)
        {
            return plusIgnore ? value : 0;
        }
        else
        {
            return minusIgnore ? value : 0;
        }
    }
}