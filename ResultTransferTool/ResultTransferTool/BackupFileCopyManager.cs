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
    public class BackupFileCopyManager : CopyResultFileToServerController
    {
        public BackupFileCopyManager()
        {
            //01/06/2022 adam comment for 42jx migrate
            //ServerAddress = @"\\asz-42jc23x\CatsResultBackupFiles$";
            ServerAddress = @"\\sdcnas01\sts_cats\APP_Fiber\FACTSResultBackupFiles$";
            MonitorFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsBackUpCache");
            BackupFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ResultsBackUp");
        }

    }
}
