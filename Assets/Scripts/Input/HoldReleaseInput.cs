using UnityEngine;

public class HoldReleaseInput : Singleton<HoldReleaseInput>
{
    public bool IsHolding { get; private set; }

    private void Update()
    {
        IsHolding = Input.GetMouseButton(0) || Input.touchCount != 0;
    }
}