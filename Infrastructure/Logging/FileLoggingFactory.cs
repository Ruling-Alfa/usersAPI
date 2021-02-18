namespace Infrastructure.Logging
{
    public class FileLoggingFactory : IFileLoggingFactory
    {
        public ILogging GetLogger()
        {
            return new FileLogging();
        }
    }
}
