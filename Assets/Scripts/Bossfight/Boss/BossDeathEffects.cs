using UnityEngine;

public class BossDeathEffects : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private ParticleSystem _deathParticles;
    [SerializeField] private int _particlesCount;

    public void Play()
    {
        ParticleSystem particles = Instantiate(_deathParticles);
        particles.startColor = _renderer.material.color;
        particles.transform.position = transform.position + new Vector3(0, 1, 1);
        particles.Emit(_particlesCount);
        Destroy(particles.gameObject, 1f);
    }
}