using System;

namespace Nlogger
{
    public class Logger
    {
        public string Name = "Default";

        public event Action<LogEventInfo> LogReceived;

        public void Debug(string msg)
        {
            WriteToTarget(LogLevel.Debug, msg);
        }

        public void Info(string msg)
        {
            WriteToTarget(LogLevel.Info, msg);
        }

        public void Error(string msg)
        {
            WriteToTarget(LogLevel.Error, msg);
        }

        public void Warn(string msg)
        {
            WriteToTarget(LogLevel.Warn, msg);
        }

        private void WriteToTarget(LogLevel level, string msg)
        {
            var info = new LogEventInfo(level, msg);
            OnLogReceived(info);
        }

        protected virtual void OnLogReceived(LogEventInfo obj)
        {
            obj.LoggerName = Name;
            LogReceived?.Invoke(obj);
        }
    }
}
