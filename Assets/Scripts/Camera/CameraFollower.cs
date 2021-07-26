using UnityEngine;

public class CameraFollower : Singleton<CameraFollower>, ICameraFollower
{
    [SerializeField] private GameObject _defaultFollowed;
    [SerializeField] private float _speed;
    [SerializeField] private float _minDistance; 

    public ICameraFollowed Followed { get; set; }

    private void Start()
    {
        ICameraFollowed followed;
        if(_defaultFollowed.TryGetComponent<ICameraFollowed>(out followed))
        {
            Followed = followed;
        }
    }

    private void LateUpdate()
    {
        if (Followed == null) return;

        if (!ReachedTarget())
        {
            MoveToTarget();
        }       
    }

    public void MoveToTarget()
    {
        float speed = _speed * Time.deltaTime;
        Vector3 position = Followed.Position + Followed.Offset;
        position.x = Followed.Offset.x;
        transform.position = Vector3.MoveTowards(transform.position, position, speed);
    }

    private bool ReachedTarget()
    {
        return GetDistanceToTarget() <= _minDistance;
    }

    private float GetDistanceToTarget()
    {
        return Vector3.Distance(transform.position, Followed.Position + Followed.Offset);
    }
}