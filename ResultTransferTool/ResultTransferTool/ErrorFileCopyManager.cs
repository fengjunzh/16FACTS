using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nlogger;

namespace ResultTransferTool
{
    public class ErrorFileCopyManager : CopyResultFileToServerController
    {
        public ErrorFileCopyManager()
        {
            //ServerAddress = @"\\asz-42jc23x\CatsResultErrorFiles$";
            ServerAddress = @"\\ASZPWBCATSS02\CatsResultErrorFiles$";
            MonitorFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsErrorCache");
            BackupFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsError");
        }

        public ErrorFileCopyManager(string monitorFolderPath)
        {
            //ServerAddress = @"\\asz-42jc23x\CatsResultErrorFileCopy";
            ServerAddress = @"\\ASZPWBCATSS02\CatsResultErrorFileCopy";
            MonitorFolderPath = monitorFolderPath;
            BackupFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsError");
        }
    }
}
