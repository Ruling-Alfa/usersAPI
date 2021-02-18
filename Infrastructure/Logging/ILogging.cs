namespace Infrastructure.Logging
{
    public interface ILogging
    {
        void LogError(string info);
        void LogInfo(string info);
    }
}