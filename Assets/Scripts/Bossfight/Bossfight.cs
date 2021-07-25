using UnityEngine;
using UnityEngine.Events;

public class Bossfight : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private int _stickmenToWinAmount;
    [SerializeField] private UnityEvent PlayerWonBossfight;

    private int _enteredStickmenCount;
    private int _killedStickmanCount;

    private void Start()
    {
        _killedStickmanCount = 0;
        _enteredStickmenCount = 0;
    }

    public void StickmenKilledInBossfight(int amount)
    {
        _killedStickmanCount += amount;
        if(BossfightWon())
        {
            WinBossfight();
        }
    } 
    
    public void StickmanEnteredBossfight()
    {
        _enteredStickmenCount++;
    }

    private bool BossfightWon()
    {
        return _killedStickmanCount >= _stickmenToWinAmount && _enteredStickmenCount > _killedStickmanCount;
    }

    private void WinBossfight()
    {
        _boss.Die();
        if (PlayerWonBossfight != null) PlayerWonBossfight.Invoke();    
    }
}