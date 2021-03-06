using UnityEngine;

public class BossCameraFollowed : MonoBehaviour, ICameraFollowed
{
    [SerializeField] private Vector3 _offset;

    public Vector3 Position { get => transform.position; }
    public Vector3 Offset { get => _offset; }

    public void SetAsCameraFollowed()
    {
        CameraFollower.Instance.Followed = this;
    }

    public void ResetAsCameraFollower()
    {
        CameraFollower.Instance.Followed = null;
    }
}