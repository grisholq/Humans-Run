public class NoMover : IMover
{
    public bool AtDestination => false;

    public void Move(IMovable movable)
    {

    }
}