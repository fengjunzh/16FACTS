using System;
using System.Collections.Generic;
using System.IO;

namespace ResultTransferTool.FolderTranscation
{
    public enum MonitoredFileStatus
    {
        Transferring,
        Writing,
        Sleeping,
        TransferError
    }

    public class MonitoredFileInfo
    {
        public FileInfo FileInfo;
        public MonitoredFileStatus Status;
        public int ErrorRetryCount;

        //12/29/2020 Adam add for network disconnected
        public Dictionary<DateTime, int> DisconnectedLog;

        public MonitoredFileInfo(FileInfo fileInfo)
        {
            FileInfo = fileInfo;
            Status = MonitoredFileStatus.Writing;

            //12/29/2020 Adam add for network disconnected
            DisconnectedLog = new Dictionary<DateTime, int>();
        }
    }
}
