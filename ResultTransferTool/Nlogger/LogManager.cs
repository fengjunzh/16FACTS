namespace Nlogger
{
    public sealed class LogManager
    {
        private static readonly LogFactory Factory = new LogFactory();

        public static Logger GetLogger(string name)
        {
            return Factory.GetLogger(name);
        }

        public static LogFactory GetFactory()
        {
            return Factory;
        }
    }
}
