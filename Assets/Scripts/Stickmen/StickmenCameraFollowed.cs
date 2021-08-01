using UnityEngine;

public class StickmenCameraFollowed : MonoBehaviour, ICameraFollowed
{
    [SerializeField] private Vector3 _offset;

    public Vector3 Position { get; set; }
    public Vector3 Offset { get => _offset; }

    public void SetAsCameraFollowed()
    {
        CameraFollower.Instance.Followed = this;
    }
}