using UnityEngine;

public class TutorialReleaseZone : TutorialZone
{
    protected override bool IsCorrectInput()
    {
        return HoldReleaseInput.Instance.IsHolding == false;
    }
}
