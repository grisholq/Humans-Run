using UnityEngine;

public interface ICameraFollowed
{
    Vector3 Position { get; }
    Vector3 Offset { get; }
    bool IsValid { get; }

    void SetAsCameraFollowed();
}