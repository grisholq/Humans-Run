using UnityEngine;

public class CameraFollower : MonoBehaviour
{   
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistance; 
    [SerializeField] private Vector3 _offset;

    public Vector3 Target { get; set; }

    private void Start()
    {
        Target = transform.position;
    }

    private void LateUpdate()
    {
        if (!ReachedTarget())
        {
            MoveToTarget();
        }       
    }

    private void MoveToTarget()
    {
        float speed = _speed * Time.deltaTime;
        Vector3 position = Target + _offset;
        position.x = _offset.x;
        transform.position = Vector3.MoveTowards(transform.position, position, speed);
    }

    private bool ReachedTarget()
    {
        return GetDistanceToTarget() <= _minDistance;
    }

    private float GetDistanceToTarget()
    {
        return Vector3.Distance(transform.position, Target + _offset);
    }
}