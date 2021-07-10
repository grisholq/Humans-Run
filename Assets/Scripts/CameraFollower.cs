using UnityEngine;

public class CameraFollower : MonoBehaviour
{   
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistance;
   
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _eulers;

    [SerializeField] private Transform _followed;
    [SerializeField] private bool _ignoreX;

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
            if (Vector3.Distance(transform.position, _followed.transform.position + _offset) <= _minDistance) return;
            transform.position = Vector3.MoveTowards(transform.position, GetFollowedPosition() + _offset, _speed);
        }
    }
    public void SetFollowed(Transform followed)
    {
        _followed = followed;
    }

    private Vector3 GetFollowedPosition()
    {
        if(_ignoreX)
        {
            Vector3 position = _followed.position;
            position.x = 0;
            return position;
        }

        return _followed.position;
    }
}