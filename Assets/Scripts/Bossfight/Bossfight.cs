using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Bossfight : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private int _stickmenToWinAmount;
    [SerializeField] private TextMeshPro _stickmenToWinText;

    [SerializeField] private UnityEvent BossfightWon;
    [SerializeField] private UnityEvent BossfightStarted;

    private int _stickmenEntered;
    private int _stickmenKilled;

    private void Start()
    {
        _stickmenKilled = 0;
        _stickmenEntered = 0;
        ShowStickmenToWinAmount();
    }

    private void ShowStickmenToWinAmount()
    {
        _stickmenToWinText.text = _stickmenToWinAmount.ToString();
    }

    public void StickmenKilledInBossfight(int amount)
    {
        _stickmenKilled += amount;
        if(IsBossfightWon())
        {
            WinBossfight();
        }
    } 
    
    public void StickmanEnteredBossfight(Stickman stickman)
    {
        if(_stickmenEntered == 0)
        {
            StartBossfight();
        }

        stickman.IsFighting = true;
        _stickmenEntered++;
    }

    private bool IsBossfightWon()
    {
        return _stickmenKilled >= _stickmenToWinAmount && _stickmenEntered > _stickmenKilled;
    }

    private void WinBossfight()
    {
        _boss.Die();
        if (BossfightWon != null) BossfightWon.Invoke();    
    }

    private void StartBossfight()
    {
        if (BossfightStarted != null) BossfightStarted.Invoke();
    }
}