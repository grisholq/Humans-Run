public interface IRecyclable<T>
{
    IFactory<T> Factory { get; set; }
}