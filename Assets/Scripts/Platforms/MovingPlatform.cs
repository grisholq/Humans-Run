using UnityEngine;

public class MovingPlatform : Platform
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;
    [SerializeField] private Transform movingPart;

    public override void SetState(float state, bool hold)
    {
        movingPart.transform.position = Vector3.Lerp(start.position, end.position, state);
    }
}