using UnityEngine;
using UnityEngine.Events;

public class BossfightEnter : MonoBehaviour
{
    [SerializeField] private UnityEvent<Stickman> StickmanEnteredArena;

    private void OnTriggerExit(Collider other)
    {
        Stickman stickman;

        if(other.TryGetComponent<Stickman>(out stickman))
        {
            if (StickmanEnteredArena != null) StickmanEnteredArena.Invoke(stickman);
        }
    }
}