public interface IMover
{
    bool AtDestination { get; }
    void Move(IMovable movable);
}