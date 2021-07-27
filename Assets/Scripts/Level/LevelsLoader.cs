using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsLoader : Singleton<LevelsLoader>
{
    [SerializeField] private Levels _levels; 

    public LevelData Current { get; set; }

    private const string _levelKey = "Level";

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (PlayerPrefs.HasKey(_levelKey))
        {
            int level = PlayerPrefs.GetInt(_levelKey);
            LevelData current = _levels.GetLevel(level);
            LoadLevel(current);
        }
        else
        {         
            LevelData first = _levels.GetFirstLevel(); 
            PlayerPrefs.SetInt(_levelKey, first.Number);
            PlayerPrefs.Save();
            LoadLevel(first);
        }
    }
    
    public void RestartLevel()
    {
        LoadLevel(Current);
    }

    public void LoadNextLevel()
    {
        LevelData nextLevel = GetNextLevel();
        PlayerPrefs.SetInt(_levelKey, nextLevel.Number);
        PlayerPrefs.Save();
        LoadLevel(nextLevel);
    }

    private LevelData GetNextLevel()
    {
        if (_levels.HasNextLevel(Current))
        {
            return _levels.GetNextLevel(Current);
        }

        return _levels.GetFirstLevel();
    }

    private void LoadLevel(LevelData level)
    {
        Current = level;
        SceneManager.LoadSceneAsync(level.BuildIndex);        
    }
}