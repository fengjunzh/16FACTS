using System;
using System.Windows.Media;
using ResultTransferTool.FolderTranscation;

namespace ResultTransferGUI
{
    public class FileViewModel
    {
        public string FileName { get; private set; }
        public string ToolTip { get; private set; }
        public SolidColorBrush Background { get; private set; }
        public SolidColorBrush Foreground { get; private set; }

        public void UpdateFileViewFormat(MonitoredFileStatus status)
        {
            switch (status)
            {
                case MonitoredFileStatus.Transferring:
                    Foreground = Brushes.White;
                    Background = Brushes.Green;
                    break;
                case MonitoredFileStatus.TransferError:
                    Foreground = Brushes.White;
                    Background = Brushes.Red;
                    break;
                case MonitoredFileStatus.Sleeping:
                    Foreground = Brushes.Black;
                    Background = Brushes.Transparent;
                    break;
                case MonitoredFileStatus.Writing:
                    Foreground = Brushes.White;
                    Background = Brushes.Yellow;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        public FileViewModel(string fileName)
        {
            FileName = fileName;
            ToolTip = fileName;
            Background = Brushes.Transparent;
            Foreground = Brushes.Black;
        }
    }
}
