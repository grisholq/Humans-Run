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
        foreach (var stickman in _stickmen.StickmenList)
        {
            stickman.Mover = _defaultMover;
        }
    }

    private void Update()
    {
        foreach (var stickman in _stickmen.StickmenList)
        {
            stickman.Move();       
        }
    }

    public void SetStickmanMover()
    {

    }

    private void Move(IMovable movable)
    {
        Vector3 velocity = movable.Rigidbody.velocity * movable.Speed;
        velocity.z = _forwardSpeed;
        movable.Rigidbody.velocity = velocity * movable.Speed;
    }
}