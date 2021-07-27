using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private UnityEvent LevelWon;
    [SerializeField] private UnityEvent LevelLost;

    private LevelData _levelData;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        _levelData = LevelsLoader.Instance.LoadedLevel;
    }

    public void Restart()
    {
        LevelsLoader.Instance.RestartLevel();
    }

    public void Win()
    {
        if (LevelWon != null) LevelWon.Invoke();
    }

    public void Lose()
    {
        if (LevelLost != null) LevelLost.Invoke();
    }
    
    public void NextLevel()
    {
        LevelsLoader.Instance.LoadNextLevel();
    }
}