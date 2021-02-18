namespace Infrastructure.Logging
{
    public interface ILoggingFactory
    {
        ILogging GetLogger();
    }
}