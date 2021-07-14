using UnityEngine.SceneManagement;

public class LevelsLoader : Singleton<LevelsLoader>
{
    public LevelData Current { get; set; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    
    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(Current.BuildIndex);
    }

    public void LoadLevel(LevelData level)
    {
        SceneManager.LoadSceneAsync(level.BuildIndex);
    }
}