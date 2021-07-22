using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Transform _weaponParent;
    [SerializeField] private ParticleSystem _deathParticles;
    [SerializeField] private Color _deathParticlesColor;

    public int AimsCount { get; set; }

    public void Die()
    {
        ParticleSystem particles = Instantiate(_deathParticles);
        particles.startColor = _deathParticlesColor;
        particles.transform.position = transform.position + new Vector3(0, 1, 1);
        Destroy(particles.gameObject, 1f);
        Destroy(gameObject);
    }
}