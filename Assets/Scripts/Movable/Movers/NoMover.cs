using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMover : IMover
{
    public bool AtDestination => false;

    public NoMover()
    {

    }

    public void Move(IMovable movable)
    {

    }
}