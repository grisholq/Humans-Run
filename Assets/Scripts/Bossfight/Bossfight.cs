using UnityEngine;

public class Bossfight : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private float _speed;

    [SerializeField] private IMover _toBossMover;

    private void Awake()
    {
        _toBossMover = new ToTargetMover(_boss.transform);
    }

    public void MoveStickmanToBoss(Stickman stickman)
    {
        stickman.Speed = _speed;
        stickman.Mover = _toBossMover;
    }
}