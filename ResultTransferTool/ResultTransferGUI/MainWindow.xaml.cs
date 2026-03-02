using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Nlogger;
using ResultTransferTool;
using Path = System.IO.Path;
using ResultTransferTool.FolderTranscation;
using System.Xml.Linq;
using ResultTransferTool.MTS;
using ResultTransferTool.Addon;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace ResultTransferGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _monitorFolderPath;
        private ResultTransferController _sqlTransferController;
        private CopyFileToServerController _fileCopyController;
        private BackupFileCopyManager _backupFileCopyManager;
        private ErrorFileCopyManager _errorFileCopyManager;
        public ObservableCollection<FileViewModel> FileViewModels { get; private set; }
        private System.Windows.Forms.NotifyIcon _notifyIcon;
        private bool _isWindowClosed;
        private Task _loopingTask;
        private readonly VersionChecker _versionChecker = new VersionChecker();

        private ErrorMessageBox ErrorPopupWindow;//12/29/2020 Adam add for check the local network
        public MainWindow()
        {

            //12/29/2020 Adam add for check the local network
            ErrorPopupWindow = new ErrorMessageBox(string.Empty);
#if DEBUG
            ErrorPopupWindow.Topmost = false;
            ErrorPopupWindow.WindowState = WindowState.Normal;
#else
	 ErrorPopupWindow.Topmost = true;
            ErrorPopupWindow.WindowState = WindowState.Maximized;
#endif

            ErrorPopupWindow.WindowStyle = WindowStyle.None;

            FileViewModels = new ObservableCollection<FileViewModel>();
            InitializeComponent();
            Title = $"Result Transfer Tool V{_versionChecker.Version}";
            LogManager.GetLogger("GUI").Info("Welcome!");
            RegisterLogToFileFeature();
            GetUserConfiguredResultFolder();
            InitializeWorkstationFile();

            LogArgs();
            IconStartUp();
            _versionChecker.CheckIfNeedToUpdate();
            CheckIfGotoHideMode();
            StartTransferTask();
            StartVersionUpdaterTask();
        }

        private void LogArgs()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Contains("-h"))
            {
                LogManager.GetLogger("GUI").Info("Hidden mode");
            }
            if (args.Contains("-sn"))
            {
                LogManager.GetLogger("GUI").Info("Enable Insert SN");
            }
            if (args.Contains("-mts"))
            {
                LogManager.GetLogger("GUI").Info("Enable update MTS");
            }
        }

        private void InitializeWorkstationFile()
        {
            var reader = new WorkStationDefinationManager();
            reader.InitializeXmlFile();
        }

        private void StartVersionUpdaterTask()
        {
            var timeFlag = DateTime.Now;
            Task.Run(() =>
            {
                while (!_isWindowClosed)
                {
                    if ((DateTime.Now - timeFlag).Hours > 1)
                    {
                        if (!_versionChecker.CheckIfNeedToUpdate())
                        {
                            timeFlag = DateTime.Now;
                        }
                    }
                    Thread.Sleep(2000);
                }
            });
        }

        private void RegisterLogToFileFeature()
        {
            var folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TraceLog");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var trace = new LogToFile(folder);
            LogManager.GetFactory().ReceivedLog += trace.LogReceived;
        }

        private void GetUserConfiguredResultFolder()
        {
            var args = Environment.GetCommandLineArgs();
            try
            {
                var subArgs = args.First(x => x.StartsWith("-p:"));
                _monitorFolderPath = subArgs.Substring(3);
                updateUserSettingFile(_monitorFolderPath);
                LogManager.GetLogger("GUI").Info($"Result folder from command line: {_monitorFolderPath}.");
                return;
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                var xDoc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cfg", "UserSetting.xml"));
                _monitorFolderPath = xDoc.Root.Element("ResultFolder").Value;
                LogManager.GetLogger("GUI").Info($"Result folder is {_monitorFolderPath}.");
                if (!Directory.Exists(_monitorFolderPath))
                {
                    LogManager.GetLogger("GUI").Warn($"Result folder not found: {_monitorFolderPath}.");
                    LogManager.GetLogger("GUI").Warn($"Default Result folder is used: {_monitorFolderPath}.");
                    CreateDefaultResultFolder();
                }
            }
            catch (Exception)
            {
                LogManager.GetLogger("GUI").Error("Handle Cfg\\UserSetting.xml fail.");
                CreateDefaultResultFolder();
                LogManager.GetLogger("GUI").Warn($"Default Result folder is used: {_monitorFolderPath}.");
            }
        }

        private void CreateDefaultResultFolder()
        {
            _monitorFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Results");
            if (!Directory.Exists(_monitorFolderPath))
            {
                Directory.CreateDirectory(_monitorFolderPath);
            }
            updateUserSettingFile(_monitorFolderPath);
        }

        private void updateUserSettingFile(string newFolderPath)
        {
            try
            {
                var cfgFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cfg", "UserSetting.xml");
                var xDoc = XDocument.Load(cfgFilePath);
                var previousFolderPath = xDoc.Root.Element("ResultFolder").Value;
                if (previousFolderPath == newFolderPath)
                {
                    return;
                }
                xDoc.Root.Element("ResultFolder").Value = newFolderPath;
                xDoc.Save(cfgFilePath);
                LogManager.GetLogger("GUI").Info("UserSetting.xml file is updated.");
            }
            catch (Exception)
            {
                LogManager.GetLogger("GUI").Error("Update Cfg\\UserSetting.xml fail.");
            }
        }

        private void IconStartUp()
        {
            _notifyIcon = new System.Windows.Forms.NotifyIcon
            {
                BalloonTipText = $@"Result transfer tool V{_versionChecker.Version} starts.",
                Text = @"Result transfer tool",
                Visible = true,
            };
            _notifyIcon.Icon = new System.Drawing.Icon(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logo", "Windows_Easy_Transfer.ico"));
            _notifyIcon.MouseDoubleClick += _notifyIcon_MouseDoubleClick;
            _notifyIcon.ShowBalloonTip(1000);
        }

        protected override void OnClosed(EventArgs e)
        {
            _isWindowClosed = true;
            LogManager.GetLogger("GUI").Warn("Closing in progress......");
            try
            {
                _loopingTask.Wait();
            }
            catch (Exception)
            {
                //ignore
            }
            try
            {
                _notifyIcon.Dispose();
            }
            catch (Exception)
            {
            }
            base.OnClosed(e);
           
        }

        private void _notifyIcon_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (IsVisible)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        private void StartTransferTask()
        {
            _sqlTransferController = new ResultTransferController(_monitorFolderPath)
            {
               // OnPopupMessage = OpenErrorMessage,//12/29/2020 Adam add for check the local network
                OnFolderChecked = UpdateFileViewModels,
                IsCallerClosedDelegate = IsWindowClosed,
                NeedToInsertSN = Environment.GetCommandLineArgs().Contains("-sn"),
                NeedToTransferToMTS = Environment.GetCommandLineArgs().Contains("-mts"),
                IgnoreMTS = Environment.GetCommandLineArgs().Contains("-ignoreMts")
            };
            _sqlTransferController.Run();

            _fileCopyController = new CopyFileToServerController(_monitorFolderPath)
            {
                // OnPopupMessage = OpenErrorMessage,//12/29/2020 Adam add for check the local network
                IsCallerClosedDelegate = IsWindowClosed
            };
            _fileCopyController.Run();

            _backupFileCopyManager = new BackupFileCopyManager
            {
                // OnPopupMessage = OpenErrorMessage,//12/29/2020 Adam add for check the local network
                IsCallerClosedDelegate = IsWindowClosed
            };
            _backupFileCopyManager.Run();

            _errorFileCopyManager = new ErrorFileCopyManager
            {
                //  OnPopupMessage = OpenErrorMessage,//12/29/2020 Adam add for check the local network
                IsCallerClosedDelegate = IsWindowClosed
            };
            _errorFileCopyManager.Run();

            //12/24/2020 Adam removed for rss32 json compressed files
            //var folderCopyController = new CopyFolderToServer(_monitorFolderPath);
            //folderCopyController.Execute();

            WaitTransferTask();
        }

        private bool IsWindowClosed()
        {
            return _isWindowClosed;
        }

        private void CheckIfGotoHideMode()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Contains("-h"))
            {
                Hide();
            }
        }

        private void UpdateFileViewModels(List<MonitoredFileInfo> sFileInfos)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                FileViewModels.Clear();
                foreach (var sFileInfo in sFileInfos)
                {
                    var newViewModel = new FileViewModel(sFileInfo.FileInfo.Name);
                    newViewModel.UpdateFileViewFormat(sFileInfo.Status);
                    FileViewModels.Add(newViewModel);
                }
            }));
        }

        private void WaitTransferTask()
        {
            _loopingTask = Task.Run(() =>
             {
                 while (true)
                 {
                     try
                     {
                         _sqlTransferController.RunningTransferTask.Wait(2000);
                         _fileCopyController.RunningTransferTask.Wait(2000);
                     }
                     catch (AggregateException ae)
                     {
                         if (ae.InnerExceptions.Any(x => x.GetType().Name == "CallerClosedException"))
                         {
                             break;
                         }
                         if (ae.InnerExceptions.Any(x => x.GetType().Name == "ResultFormatVersionNotSupportedException"))
                         {
                             _versionChecker.CheckIfNeedToUpdate();
                         }
                         foreach (var innerException in ae.InnerExceptions)
                         {
                             LogManager.GetLogger("GUI").Error("Catch error -> " + innerException.Message);
                             if (innerException is DirectoryNotFoundException)
                             {
                                 MessageBox.Show("Check Result folder. " + innerException.Message, "Stop Error", MessageBoxButton.OK, MessageBoxImage.Error);
                             }
                         }
                         Thread.Sleep(2000);
                         if (ae.InnerExceptions.Any(x => x.StackTrace.Contains("CopyFileToServerController")))
                         {
                             LogManager.GetLogger("GUI").Warn("File Copy Task Restart");
                             _fileCopyController.Run();
                         }
                         if (ae.InnerExceptions.Any(x => x.StackTrace.Contains("ResultTransferController")))
                         {
                             LogManager.GetLogger("GUI").Warn("SQL Transfer Task Restart");
                             _sqlTransferController.Run();
                         }
                     }
                 }
             });
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            CheckIfGotoHideMode();
        }


        //12/29/2020 Adam add for check the local network
        //private void OpenErrorMessage(string message)
        //{
        //    Dispatcher.BeginInvoke(new Action(() =>
        //    {
        //        if (_sqlTransferController != null)
        //        {
        //            _sqlTransferController.StopTask();
        //        }

        //        if (_fileCopyController != null)
        //        {
        //            _fileCopyController.StopTask();
        //        }

        //        if (_backupFileCopyManager != null)
        //        {
        //            _backupFileCopyManager.StopTask();
        //        }

        //        if (_errorFileCopyManager != null)
        //        {
        //            _errorFileCopyManager.StopTask();
        //        }
        //        if (ErrorPopupWindow.IsActive != true)
        //        {
        //            ErrorPopupWindow.SetMessage(message);
        //            ErrorPopupWindow.Show();
        //        }

        //    }));

        //}
    }
}