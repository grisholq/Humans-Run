using UnityEngine;
using UnityEngine.Events;

public class TutorialZoneEnter : MonoBehaviour
{
    [SerializeField] private UnityEvent ZoneEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (ZoneEntered != null) ZoneEntered.Invoke();
    }
}