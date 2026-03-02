using System;
using System.IO;
using System.Xml.Linq;
using Nlogger;
using ResultTransferTool;

namespace ResultTransferGUI
{
    class VersionChecker
    {
        private readonly double _version = VersionConstant.BinaryVersion;

        private string Server { get { return GetServerAddress(); } }

        private const string ForceServerAddress = null;

        private const string VersionFileName = "ServerVersion.xml";

        public double Version => _version;

        private string GetServerAddress()
        {
            try
            {
                var xDoc = XDocument.Load(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cfg", "Server.xml"));
                return xDoc.Root.Element("Address").Value;
            }
            catch
            {
                //01/06/2022 adam comment for 42jx migrate
                //return @"\\asz-42jc23x\CatsResultTransferTool";
                return @"\\sdcnas01\sts_cats\APP_Fiber\FACTSResultTransferTool";
            }
        }

        public double CheckVersionFromServer()
        {
            var sourceFilePath = Server + "\\" + VersionFileName;
            if (!File.Exists(sourceFilePath))
            {
                LogManager.GetLogger("GUI").Warn($"Can't find version info from server ({Server})!");
                return 0;
            }
            var targetFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, VersionFileName);
            File.Copy(sourceFilePath, targetFilePath, true);

            var xDoc = XDocument.Load(targetFilePath);
            try
            {
                var serverVersion = double.Parse(xDoc.Root.Element("ServerVersion").Value);
                LogManager.GetLogger("GUI").Info($"Server version is {serverVersion}.");
                return serverVersion;
            }
            catch (Exception)
            {
                LogManager.GetLogger("GUI").Warn($"Server version format is not valid.");
                return 0;
            }
        }

        public bool CheckIfNeedToUpdate()
        {
            LogManager.GetLogger("GUI").Info($"Local version is {_version}.");
            var serverVersion = CheckVersionFromServer();
            if (_version < serverVersion)
            {
                LogManager.GetLogger("GUI").Info($"Start updating to version {serverVersion}.");
                var coordinator = new UpdaterCoordinator();
                CopyUpdaterConfigurationFile();
                CopyUpdater();
                WriteArgs();
                coordinator.RunUpdater();
                return true;
            }
            return false;
        }

        private void WriteArgs()
        {
            var args = Environment.GetCommandLineArgs();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater", "Configuration", "args.txt");
            File.WriteAllText(path, string.Join(" ", args));
        }

        private void CopyUpdaterConfigurationFile()
        {
            var configurationFileName = "Components.xml";
            var source = Server + "\\" + configurationFileName;
            var target = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater", "Configuration",
                configurationFileName);
            if (!File.Exists(source))
            {
                LogManager.GetLogger("GUI").Warn($"Can't find configuration file from server ({source})!");
                return;
            }
            File.Copy(source, target, true);
        }

        private void CopyUpdater()
        {
            try
            {
                var updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater", "Updater.exe");
                var src = Server + "\\" + "Updater.exe";
                File.Copy(src, updaterPath, true);
            }
            catch
            {
                //ignore   
            }
        }
    }
}
