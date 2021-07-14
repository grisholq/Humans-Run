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

    public bool Hold { get; set; }

    private void Awake()
    {
        _platforms = new List<Platform>(GetComponentsInChildren<Platform>());
    }

    void Update()
    {
        Hold = IsHolding();
        State += Time.deltaTime * (Hold ? 1 : -1) * _changeSpeed;

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