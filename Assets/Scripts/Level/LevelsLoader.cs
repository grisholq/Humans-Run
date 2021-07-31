using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsLoader : Singleton<LevelsLoader>
{
    [SerializeField] private Levels _levels; 

    public LevelData LoadedLevel { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
        LoadProgressLevel();           
    }

    private void LoadProgressLevel()
    {
        if (LevelsProgress.Empty)
        {
            LoadFirstLevel();
        }
        else
        {
            LoadCurrentLevel();
        }
    }

    private void LoadFirstLevel()
    {
        LoadLevel(_levels.GetFirstLevel());
    }

    private void LoadCurrentLevel()
    {
        int level = LevelsProgress.GetCurrentLevelNumber();
        LoadLevel(_levels.GetLevel(level));
    }
    
    public void RestartLevel()
    {
        LoadLevel(LoadedLevel);
    }

    public void LoadNextLevel()
    {
        LoadLevel(_levels.GetNextLevel(LoadedLevel));
    }

    private void LoadLevel(LevelData level)
    {
        LoadedLevel = level;
        LevelsProgress.SetCurrentLevelNumber(level.Number);
        SceneManager.LoadSceneAsync(level.BuildIndex);        
    }
}