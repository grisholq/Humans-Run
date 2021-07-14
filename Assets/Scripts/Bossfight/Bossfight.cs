using UnityEngine;
using UnityEngine.Events;

public class Bossfight : MonoBehaviour
{
    [SerializeField] private UnityEvent PlayerWonBossfight;

    public void PlayerHaveWon()
    {
        if(PlayerWonBossfight != null) PlayerWonBossfight.Invoke();
    }
}