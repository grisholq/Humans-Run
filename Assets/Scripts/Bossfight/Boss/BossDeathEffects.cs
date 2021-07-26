using UnityEngine;

public class BossDeathEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathParticles;
    [SerializeField] private Color _deathParticlesColor;

    public void Play()
    {
        ParticleSystem particles = Instantiate(_deathParticles);
        particles.startColor = _deathParticlesColor;
        particles.transform.position = transform.position + new Vector3(0, 1, 1);
        Destroy(particles.gameObject, 1f);
    }
}