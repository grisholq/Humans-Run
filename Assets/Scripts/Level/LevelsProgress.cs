using UnityEngine;

public static class LevelsProgress
{
    private const string _levelKey = "Level";

    public static bool Empty => PlayerPrefs.HasKey(_levelKey) == false;

    public static void SetCurrentLevelNumber(int number)
    {
        PlayerPrefs.SetInt(_levelKey, number);
        PlayerPrefs.Save();
    }

    public static int GetCurrentLevelNumber()
    {
        return PlayerPrefs.GetInt(_levelKey);
    }
}