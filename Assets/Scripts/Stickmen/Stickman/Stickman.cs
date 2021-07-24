using UnityEngine;

public class Stickman : MonoBehaviour, IDublicatable, IDublicatablePart<Stickman>
{
    public int AimsCount { get; set; }
    public bool OnFloor { get; set; }
    public StickmanDeathEffects DeathEffects { get; set; }
    public StickmanMover Mover { get; set; }
    public Health Health { get; set; }

    public DublicatingZone LastDublicateZone { get; set; }

    public Transform CreateDublicate()
    {
        Stickman stickman = Instantiate(this);
        this.Dublicate(stickman);
        Mover.Dublicate(stickman.Mover);
        Health.Dublicate(stickman.Health);
        return stickman.transform;
    }

    public void Dublicate(Stickman to)
    {
        to.transform.parent = transform.parent;
        to.AimsCount = AimsCount;
        to.OnFloor = OnFloor;
        to.LastDublicateZone = LastDublicateZone;
    }

    private void Awake()
    {
        OnFloor = true;
        DeathEffects = GetComponent<StickmanDeathEffects>();
        Mover = GetComponent<StickmanMover>();
        Health = GetComponent<Health>();
    }

    public void Die()
    {
        DeathEffects.Play();
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        StickmenPool.Instance.Return(this);
    }
}