using UnityEngine;
using UnityEngine.Events;

public class TutorialZoneExit : MonoBehaviour
{
    [SerializeField] private UnityEvent ZoneExited;

    private void OnTriggerEnter(Collider other)
    {
        if (ZoneExited != null) ZoneExited.Invoke();   
    }
}