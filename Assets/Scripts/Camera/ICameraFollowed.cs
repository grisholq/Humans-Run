using UnityEngine;

public interface ICameraFollowed
{
    Vector3 Position { get; }
    Vector3 Offset { get; }

    void SetAsCameraFollowed();
}