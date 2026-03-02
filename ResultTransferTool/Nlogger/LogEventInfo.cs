using System;

namespace Nlogger
{
    public class LogEventInfo
    {
        public DateTime TimeStamp { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }

        public string LoggerName { get; set; }

        public LogEventInfo(LogLevel level, string message)
        {
            TimeStamp = DateTime.Now;
            Level = level;
            Message = message;
        }

    }
}
