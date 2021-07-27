using UnityEngine;
using UnityEngine.Events;

public class TutorialZone : MonoBehaviour
{
    [SerializeField] protected UnityEvent ZonePause;
    [SerializeField] protected UnityEvent ZoneResume;

    private void Awake()
    {
        enabled = false;
    }

    private void Update()
    {
        Process();
    }

    protected void Process()
    {
        if (IsCorrectInput()) Resume();
        else Pause();
    }

    private void Pause()
    {
        if (ZonePause != null) ZonePause.Invoke();
    }

    private void Resume()
    {
        if (ZoneResume != null) ZoneResume.Invoke();
    }

    protected virtual bool IsCorrectInput()
    {
        return false;
    }
}