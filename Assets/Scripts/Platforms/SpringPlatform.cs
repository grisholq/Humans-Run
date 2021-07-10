using UnityEngine;

public class SpringPlatform : Platform
{
    [SerializeField] private Transform _platform;
    [SerializeField] private Rigidbody _platformRigidbody;

    [SerializeField] private Vector3 _holdVelocity;
    [SerializeField] private Vector3 _releaseVelocity;

    [SerializeField] private float _stopDistance;

    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;

    private void Start()
    {
        transform.position = _start.position;
    }

    public override void SetState(float state, bool hold)
    {            
        if (hold)
        {
            _platformRigidbody.velocity = _holdVelocity;

            if(_platform.position.y > _end.position.y)
            {
                _platform.position = new Vector3(_platform.position.x, _end.position.y, _platform.position.z);
               
            }

            if(Mathf.Abs(_platform.position.y - _end.position.y) <= _stopDistance)
            {
                _platformRigidbody.velocity = Vector3.zero;
            }
        }
        else
        {
            _platformRigidbody.velocity = _releaseVelocity;

            if (_platform.position.y <= _start.position.y)
            {
                _platform.position = new Vector3(_platform.position.x, _start.position.y, _platform.position.z);
            }

            if (Mathf.Abs(_platform.position.y - _start.position.y) <= _stopDistance)
            {
                _platformRigidbody.velocity = Vector3.zero;
            }
        }
    }
}