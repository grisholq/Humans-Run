using UnityEngine;

[RequireComponent(typeof(Stickman))]
public class StickmanAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _speedParameterName;
    [SerializeField] private string _stoppedParameterName;

    private Stickman _stickman;

    private void Awake()
    {
        _stickman = GetComponent<Stickman>();
    }

    private void Update()
    {
        _animator.SetFloat(_speedParameterName, _stickman.IsStopped);
        _animator.SetBool(_stoppedParameterName, _stickman.IsFighting);
    }
}