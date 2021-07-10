using UnityEngine;

[RequireComponent(typeof(Stickmen))]
public class StickmenMover : MonoBehaviour
{
    [SerializeField] private float _forwardSpeed;

    private Stickmen _stickmen;

    private void Awake()
    {
        _stickmen = GetComponent<Stickmen>();
    }

    private void Start()
    {
        foreach (var stickman in _stickmen.StickmenList)
        {
            stickman.IsMoving = true;
        }
    }

    private void Update()
    {
        foreach (var stickman in _stickmen.StickmenList)
        {
            if (!stickman.IsMoving) continue;

            Vector3 velocity = stickman.Rigidbody.velocity * stickman.Speed;
            velocity.z = _forwardSpeed;
            stickman.Rigidbody.velocity = velocity * stickman.Speed;
        }
    }
}