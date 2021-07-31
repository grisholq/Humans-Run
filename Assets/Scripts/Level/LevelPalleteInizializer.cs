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
        _enemy.color = pallete.Enemy;

        _player.color = pallete.Player;

        _platform.color = pallete.Platform;
        _trap.color = pallete.Trap;

        SetColorWithAlphaSaved(_multiplier, pallete.Multiplier);
        SetColorWithAlphaSaved(_multiplierParticles, pallete.Multiplier);

        _road.color = pallete.Road;
        _background.mainTexture = pallete.Background;
    }

    private void SetColorWithAlphaSaved(Material material, Color color)
    {
        color.a = material.color.a;
        material.color = color;
    }
}