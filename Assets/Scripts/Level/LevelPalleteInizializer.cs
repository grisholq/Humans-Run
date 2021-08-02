using UnityEngine;

public class LevelPalleteInizializer : MonoBehaviour
{
    [SerializeField] private Material _enemy;
    [SerializeField] private Material _player;
    [SerializeField] private Material _platform;
    [SerializeField] private Material _trap;
    [SerializeField] private Material _multiplier;
    [SerializeField] private Material _multiplierParticles;
    [SerializeField] private Material _road;
    [SerializeField] private Material _background;

    public void InizializeLevelPallete(LevelPallete pallete)
    {
        SetColor(_enemy, pallete.Enemy);
        SetColor(_player, pallete.Player);
        SetColor(_platform, pallete.Platform);
        SetColor(_trap, pallete.Trap);
        SetColorWithAlphaSaved(_multiplier, pallete.Multiplier);
        SetColorWithAlphaSaved(_multiplierParticles, pallete.Multiplier);
        SetColor(_road, pallete.Road);
        SetTexture(_background, pallete.Background);
    }

    private void SetColor(Material material, Color color)
    {
        material.color = color;
    }

    private void SetColorWithAlphaSaved(Material material, Color color)
    {
        color.a = material.color.a;
        material.color = color;
    }

    private void SetTexture(Material material, Texture texture)
    {
        material.mainTexture = texture;
    }
}