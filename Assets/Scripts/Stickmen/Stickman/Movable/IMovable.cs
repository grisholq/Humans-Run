using UnityEngine;

public interface IMovable
{
    IMover Mover { get; set; }
    Rigidbody Rigidbody { get; set; }
    Transform Transform { get; set; }
    float Speed { get; set; }
    bool IsStopped { get; set; }

    void Move();
}