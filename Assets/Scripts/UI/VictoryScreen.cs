using TMPro;
using UnityEngine;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _passedLevelInfo;

    private void OnEnable()
    {
        ShowPassedLevelInfo();   
    }

    private void ShowPassedLevelInfo()
    {
        LevelData levelData = LevelsLoader.Instance.LoadedLevel;
        _passedLevelInfo.text = "Level " + levelData.Number.ToString() + " complete";
    }
}
