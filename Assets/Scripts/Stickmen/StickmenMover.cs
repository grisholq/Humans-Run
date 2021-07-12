using UnityEngine;

[RequireComponent(typeof(Stickmen))]
public class StickmenMover : MonoBehaviour
{
    private Stickmen _stickmen;
    private IMover _defaultMover;

    private void Awake()
    {
        _stickmen = GetComponent<Stickmen>();
        _defaultMover = new DirectionMover(Vector3.forward);
    }

    private void Start()
    {
        foreach (var stickman in _stickmen.List)
        {
            stickman.Mover = _defaultMover;
        }
    }

    private void Update()
    {
        foreach (var stickman in _stickmen.List)
        {
            stickman.Move();       
        }
    }

    public void SetStickmanMover(Stickman stickman)
    {
        stickman.Mover = _defaultMover;
    }
}