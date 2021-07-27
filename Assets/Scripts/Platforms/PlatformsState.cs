using UnityEngine;
using System.Collections.Generic;

public class PlatformsState : MonoBehaviour
{
    [SerializeField] private float _changeSpeed;

    private float _state;

    private List<Platform> _platforms;

    public float State
    {
        get => _state;
        set
        {
            _state = value;
            _state = Mathf.Clamp(_state, 0, 1);
        }
    }

    private float _lastState;

    public bool Hold { get; set; }

    private void Awake()
    {
        _lastState = 0;
        State = 0;
        _platforms = new List<Platform>(GetComponentsInChildren<Platform>());
    }

    void FixedUpdate()
    {
        UpdateState();
        UpdatePlatforms();
    }

    private void UpdateState()
    {
        Hold = HoldReleaseInput.Instance.IsHolding;
        _lastState = State;
        State += Time.deltaTime * (Hold ? 1 : -1) * _changeSpeed;
    }

    private void UpdatePlatforms()
    {
        foreach (var platform in _platforms)
        {
            platform.SetState(State, Hold);
        }
    }

    private bool IsHolding()
    {
        return Input.touchCount > 0 || Input.GetMouseButton(0);
    }
}