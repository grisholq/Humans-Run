public interface IDamagable
{
    float DamageId { get; }
    float Health { get; set; }
    void Damage(float value);
    void Die();
}