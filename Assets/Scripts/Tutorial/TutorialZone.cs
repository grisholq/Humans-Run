using UnityEngine;
using UnityEngine.Events;

public abstract class TutorialZone : MonoBehaviour
{
    [SerializeField] protected RectTransform _pauseScreen;

    [SerializeField] protected UnityEvent ZonePause;
    [SerializeField] protected UnityEvent ZoneResume;

    protected void Process()
    {

    }

    private void Pause()
    {
        _pauseScreen.gameObject.SetActive(true);
        if (ZonePause != null) ZonePause.Invoke();
    }

    private void Resume()
    {
        _pauseScreen.gameObject.SetActive(false);
        if (ZoneResume != null) ZoneResume.Invoke();
    }

    protected abstract bool IsCorrectInput();
}