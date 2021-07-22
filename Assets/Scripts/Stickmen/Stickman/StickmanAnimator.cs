using UnityEngine;

[RequireComponent(typeof(Stickman))]
public class StickmanAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _stoppedParameterName;
    [SerializeField] private string _fightingParameterName;
    [SerializeField] private string _fallingParameterName;

    private Stickman _stickman;

    private void Awake()
    {
        _stickman = GetComponent<Stickman>();
    }

    private void Update()
    {
        _animator.SetBool(_stoppedParameterName, IsStopped());
        _animator.SetBool(_fightingParameterName, IsFighting());
        _animator.SetBool(_fallingParameterName, IsFalling());
    }

    private bool IsStopped()
    {
        return _stickman.Mover.AtDestination || _stickman.IsStopped;
    }

    private bool IsFighting()
    {
        return _stickman.AimsCount > 0;
    }

    private bool IsFalling()
    {
        Vector3 velocity = _stickman.Rigidbody.velocity;
        return velocity.y >= 1 || velocity.y <= -1;
    }
}