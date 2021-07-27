using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Levels
{
    [SerializeField] private List<LevelData> _levels;

    public int Amount => _levels.Count;

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

    public bool HasNextLevel(LevelData levelData)
    {
        foreach (var level in _levels)
        {
            if (level.Number == levelData.Number + 1)
            {
                return true;
            }
        }
        return false;
    }

    public LevelData GetNextLevel(LevelData levelData)
    {
        foreach (var level in _levels)
        {
            if (level.Number == levelData.Number + 1)
            {
                return level;
            }
        }
        return null;
    }
}
