using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform _movingPlatform;

    public override void SetState(float state, bool hold)
    {
        _movingPlatform.transform.position = Vector3.Lerp(_start.position, _end.position, state);
    }
}