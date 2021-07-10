using UnityEngine;

public class StickmanMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 velocity = _rigidbody.velocity;
        velocity.z = _speed;
        _rigidbody.velocity = velocity;
    }
}