using UnityEngine;

public class Boss : MonoBehaviour
{
    [field: SerializeField] public bool IsFighting { get; set; }

    [SerializeField] private ParticleSystem _deathParticles;
    [SerializeField] private Color _deathParticlesColor;
    
    public void Die()
    {
        ParticleSystem particles = Instantiate(_deathParticles);
        particles.startColor = _deathParticlesColor;
        particles.transform.position = transform.position + new Vector3(0, 1, 1);
        Destroy(particles.gameObject, 1f);
        Destroy(gameObject);
    }
}