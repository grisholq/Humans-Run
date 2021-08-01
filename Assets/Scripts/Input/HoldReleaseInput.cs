using UnityEngine;

public class HoldReleaseInput : Singleton<HoldReleaseInput>
{
    public bool IsHolding { get; private set; }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        IsHolding = Input.GetMouseButton(0) || Input.touchCount != 0;
    }
}