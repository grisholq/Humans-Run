using UnityEngine;

public class CameraFollower : MonoBehaviour
{   
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _eulers;

    [SerializeField] private Transform _followed;

    private void Start()
    {
        transform.eulerAngles = _eulers;

        if(_followed != null)
        {
            transform.position = _followed.transform.position + _offset;
        }   
    }

    private void LateUpdate()
    {
        if(_followed != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _followed.transform.position + _offset, _speed);
        }
    }

    public void SetFollowed(Transform followed)
    {
        _followed = followed;
    }
}