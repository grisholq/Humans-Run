using UnityEngine;

public class ThrowingPlatform : Platform
{
    [SerializeField] private HingeJoint thrower;

    [SerializeField] private float holdSpring;
    [SerializeField] private float releaseForce;

    [SerializeField] private float holdPosition;
    [SerializeField] private float releasePosition;

    [SerializeField] private float damper;

    public override void SetState(float state, bool hold)
    {
        JointSpring spring = thrower.spring;

        if(hold)
        {
            spring.spring = holdSpring;
            spring.targetPosition = holdPosition;
        }
        else
        {
            spring.spring = releaseForce;
            spring.targetPosition = releasePosition;
        }

        spring.damper = damper;

        thrower.spring = spring;
    }
}