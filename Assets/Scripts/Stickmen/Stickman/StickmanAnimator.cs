using UnityEngine;

[RequireComponent(typeof(Stickman))]
public class StickmanAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private string _stoppedParameterName;
    [SerializeField] private string _fightingParameterName;
    [SerializeField] private string _fallingParameterName;
    [SerializeField] private string _hasJumpedParameterName;

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

        if(HasJumped())
        {
            _animator.SetTrigger(_hasJumpedParameterName);
        }
        else
        {
            _animator.ResetTrigger(_hasJumpedParameterName);
        }
    }

    private bool IsStopped()
    {
        IMovable movable = _stickman.Mover;
        return movable.Mover.AtDestination || movable.IsStopped;
    }

    private bool IsFighting()
    {
        return _stickman.IsFighting;
    }

    private bool IsFalling()
    {
        return !_stickman.OnFloor;
    }
    
    private bool HasJumped()
    {
        Vector3 velocity = _stickman.Mover.Rigidbody.velocity;
        return velocity.y > 6f;
    }
}