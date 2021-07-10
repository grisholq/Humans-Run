using UnityEngine;

public class BossfightFightingZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Stickman stickman;

        if (TryGetComponent(out stickman))
        {
            stickman.IsFighting = true;
            stickman.IsMoving = false;
        }
    }
}