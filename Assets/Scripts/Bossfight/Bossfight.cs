using UnityEngine;

public class Bossfight : MonoBehaviour
{
    [SerializeField] private Boss _boss;

    [SerializeField] private IMover _toBossMover;

    private void Awake()
    {
        _toBossMover = new ToTargetMover(_boss.transform);
    }

    public void MoveStickmanToBoss(Stickman stickman)
    {
        stickman.Mover = _toBossMover;
    }
}