using System;
using System.Management;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {           
            var configurationManager = new ConfigurationManager();
            var updateManager = new UpdateManager(configurationManager);
            updateManager.LogAction += WriteLog;          
            updateManager.CopyFolderFromServer();
            updateManager.KillCallerProcess();
            updateManager.UpdateFiles();
            updateManager.CopyErrorFiles();
            updateManager.RestartApplication();

            if (args.Length == 0)
            {
                Console.ReadLine();
            }
        }

        static void WriteLog(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
