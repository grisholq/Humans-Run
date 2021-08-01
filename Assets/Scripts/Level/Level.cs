using UnityEngine;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] private UnityEvent LevelWon;
    [SerializeField] private UnityEvent LevelLost;

    private LevelPalleteInizializer _palleteInizializer;

    private LevelData _levelData;

    private void Awake()
    {     
        InizializeLevel();
    }

    private void InizializeLevel()
    {
        Application.targetFrameRate = 60;
        _levelData = LevelsLoader.Instance.LoadedLevel;

        _palleteInizializer = GetComponent<LevelPalleteInizializer>();
        _palleteInizializer.InizializeLevelPallete(_levelData.Pallete);
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