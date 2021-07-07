using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ConstantVelocity : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 velocity = _rigidbody.velocity;
        velocity.z = _speed;        
        _rigidbody.velocity = velocity;  
    }
}