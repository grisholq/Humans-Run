using UnityEngine;

public class StickmanDeathEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private Color _particlesColor;

    public void Play()
    {
        ParticleSystem particles = Instantiate(_particles);
        particles.startColor = _particlesColor;
        particles.transform.position = transform.position;
        Destroy(particles.gameObject, 1f);
    }
}