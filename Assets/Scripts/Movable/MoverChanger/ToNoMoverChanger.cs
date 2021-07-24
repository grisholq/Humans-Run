public class ToNoMoverChanger : MoverChanger
{
    public override void ChangeMover(IMovable movable)
    {
        base.ChangeMover(movable);
        movable.Mover = new NoMover();
    }
}