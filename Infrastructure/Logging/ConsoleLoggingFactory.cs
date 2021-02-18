namespace Infrastructure.Logging
{
    public class ConsoleLoggingFactory : IConsoleLoggingFactory
    {
        public ILogging GetLogger()
        {
            return new ConsoleLogging();
        }
    }
}
