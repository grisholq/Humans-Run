using UnityEngine;

public class StickmanDeathEffects : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private int _particlesCount;

    public void Play()
    {
        ParticleSystem particles = Instantiate(_particles);
        particles.startColor = _renderer.material.color;
        particles.transform.position = transform.position;
        particles.Emit(_particlesCount);
        Destroy(particles.gameObject, 1f);
    }
}