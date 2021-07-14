using UnityEngine;

public class LevelTimeManager : MonoBehaviour
{
    [SerializeField] private float _defaultTimeScale;
    [SerializeField] private float _defaultFixedDeltaTime;

    private void Awake()
    {
        Time.timeScale = _defaultTimeScale;
        Time.fixedDeltaTime = _defaultFixedDeltaTime;
    }

    public void StopTime()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = _defaultTimeScale;
        Time.fixedDeltaTime = _defaultFixedDeltaTime;
    }
}