using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;

    [SerializeField] private UnityEvent LevelWon;
    [SerializeField] private UnityEvent LevelLost;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        LevelsLoader.Instance.Current = _levelData;
    }

    public void Restart()
    {
        LevelsLoader.Instance.ReloadCurrentLevel();
    }

    public void Win()
    {
        if (LevelWon != null) LevelWon.Invoke();
        Debug.Log("Victory");
    }

    public void Lose()
    {
        if (LevelLost != null) LevelLost.Invoke();
        Debug.Log("Loose");
    }
}