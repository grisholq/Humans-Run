using UnityEngine;

[RequireComponent(typeof(Boss))]
public class BossAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _fightParameterName;

    private Boss _boss;

    private void Awake()
    {
        _boss = GetComponent<Boss>();
    }

    private void Update()
    {
        _animator.SetBool(_fightParameterName, _boss.IsFighting);
    }
}