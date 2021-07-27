using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Levels
{
    [SerializeField] private List<LevelData> _levels;

    public LevelData GetFirstLevel()
    {
        return GetLevel(1);
    }

    public LevelData GetLevel(int number)
    {
        foreach (var level in _levels)
        {
            if (level.Number == number)
            {
                return level;
            }
        }
        return null;
    }

    public LevelData GetNextLevel(LevelData levelData)
    {
        LevelData level = GetLevel(levelData.Number + 1);
        return level == null ? GetFirstLevel() : level;
    }
}
