using UnityEngine;

public class TutorialHoldZone : TutorialZone
{
    protected override bool IsCorrectInput()
    {
        return HoldReleaseInput.Instance.IsHolding;
    }
}