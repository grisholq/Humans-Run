using UnityEngine;
using UnityEngine.Events;

public class Bossfight : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private int _stickmenToWinAmount;

    [SerializeField] private UnityEvent PlayerWonBossfight;

    private int _stickmenEntered;
    private int _stickmenKilled;

    private void Start()
    {
        _stickmenKilled = 0;
        _stickmenEntered = 0;
    }

    public void StickmenKilledInBossfight(int amount)
    {
        _stickmenKilled += amount;
        if(BossfightWon())
        {
            WinBossfight();
        }
    } 
    
    public void StickmanEnteredBossfight()
    {
        _stickmenEntered++;
    }

    private bool BossfightWon()
    {
        return _stickmenKilled >= _stickmenToWinAmount && _stickmenEntered > _stickmenKilled;
    }

    private void WinBossfight()
    {
        _boss.Die();
        if (PlayerWonBossfight != null) PlayerWonBossfight.Invoke();    
    }
}