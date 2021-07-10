using UnityEngine;

public class StickmanDeathHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private Color _particlesColor;

    public void Die()
    {
        Stickman stickman = GetComponent<Stickman>();

        stickman.Factory.Recycle(stickman);

        ParticleSystem particles = Instantiate(_particles);
        particles.startColor = _particlesColor;
        particles.transform.position = transform.position;
        Destroy(particles.gameObject, 1f);
    }
}