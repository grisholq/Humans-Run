using UnityEngine;

public class DublicatingZoneDisabler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _enter;
    [SerializeField] private Collider _clamper;

    public void Disable()
    {
        _animator.SetBool("IsDisabled", true);
        _enter.enabled = false;
        _clamper.enabled = false;
    }
}