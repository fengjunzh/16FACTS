using System.Globalization;
using System.Windows.Media;
using Nlogger;

namespace ResultTransferGUI.UserControl
{
    public class LogEventViewModel
    {
        public LogEventViewModel(LogEventInfo logEventInfo)
        {
            Time = logEventInfo.TimeStamp.ToString(CultureInfo.InvariantCulture);
            ToolTip = logEventInfo.Message;
            Message = logEventInfo.Message;
            Level = logEventInfo.Level.ToString();
            Category = logEventInfo.LoggerName;
            UpdateColors(logEventInfo);
        }

        private void UpdateColors(LogEventInfo logEventInfo)
        {
            if (logEventInfo.Level == LogLevel.Warn)
            {
                Background = Brushes.Yellow;
                BackgroundMouseOver = Brushes.GreenYellow;
            }
            else if (logEventInfo.Level == LogLevel.Error)
            {
                Background = Brushes.Tomato;
                BackgroundMouseOver = Brushes.IndianRed;
            }
            else
            {
                Background = Brushes.White;
                BackgroundMouseOver = Brushes.LightGray;
            }
            Foreground = Brushes.Black;
            ForegroundMouseOver = Brushes.Black;
        }

        public string Category { get; private set; }
        public string Time { get; private set; }
        public string Level { get; private set; }
        public string Message { get; private set; }
        public string ToolTip { get; private set; }
        public SolidColorBrush Background { get; private set; }
        public SolidColorBrush Foreground { get; private set; }
        public SolidColorBrush BackgroundMouseOver { get; private set; }
        public SolidColorBrush ForegroundMouseOver { get; private set; }

    }
}
