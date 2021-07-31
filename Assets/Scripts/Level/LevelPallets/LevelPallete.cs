using UnityEngine;

[CreateAssetMenu(fileName = "LevelPallete", menuName = "MyAssets/LevelPallete")]
public class LevelPallete : ScriptableObject
{
    [field: SerializeField] public Color Enemy { get; set; }
    [field: SerializeField] public Color Player { get; set; }
    [field: SerializeField] public Color Platform { get; set; }
    [field: SerializeField] public Color Trap { get; set; }
    [field: SerializeField] public Color Multiplier { get; set; }
    [field: SerializeField] public Color Road { get; set; }
    [field: SerializeField] public Texture Background { get; set; }
}