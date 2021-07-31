using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "MyAssets/LevelData")]
public class LevelData : ScriptableObject
{
    [field: SerializeField] public int BuildIndex { get; set; }
    [field: SerializeField] public int Number { get; set; }
    [field: SerializeField] public LevelPallete Pallete { get; set; }
}