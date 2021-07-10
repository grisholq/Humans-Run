public interface IFactory<T>
{
    T Create();
    void Recycle(T t);
}