using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Nlogger;

namespace ResultTransferGUI.UserControl
{
    /// <summary>
    /// Interaction logic for LogViewer.xaml
    /// </summary>
    public partial class LogViewer : System.Windows.Controls.UserControl
    {
        public ObservableCollection<LogEventViewModel> LogEntries { get; private set; }

        public LogViewer()
        {
            LogEntries = new ObservableCollection<LogEventViewModel>();
            InitializeComponent();
            LogManager.GetFactory().ReceivedLog += LogReceived;
        }

        private void LogReceived(LogEventInfo log)
        {
            var logEventViewModel = new LogEventViewModel(log);
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (LogEntries.Count >= 200)
                {
                    LogEntries.RemoveAt(0);
                }
                LogEntries.Add(logEventViewModel);
                LogView.Items.MoveCurrentToLast();
                LogView.ScrollIntoView(LogView.Items.CurrentItem);
            }));
        }

    }
}
