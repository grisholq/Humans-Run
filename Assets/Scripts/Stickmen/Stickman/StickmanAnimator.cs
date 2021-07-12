using UnityEngine;

[RequireComponent(typeof(Stickman))]
public class StickmanAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _stoppedParameterName;
    [SerializeField] private string _fightingParameterName;

    private Stickman _stickman;

    private void Awake()
    {
        _stickman = GetComponent<Stickman>();
    }

    private void Update()
    {
        _animator.SetBool(_stoppedParameterName, _stickman.Mover.AtDestination);
        _animator.SetBool(_fightingParameterName, _stickman.AimsCount > 0);
    }
}