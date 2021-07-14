using UnityEngine;

public class CameraFollower : MonoBehaviour
{   
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistance;
   
    [SerializeField] private Vector3 _offset;
    public Vector3 Position { get; set; }

    private void Start()
    {
        Position = transform.position;
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(transform.position, Position + _offset) <= _minDistance) return;
        transform.position = Vector3.MoveTowards(transform.position, Position + _offset, _speed * Time.deltaTime);
    }
}