namespace Infrastructure.Logging
{
    public interface IFactory<T>
    {
        T Create();
    }
}
