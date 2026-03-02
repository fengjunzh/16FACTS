using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResultTransferGUI
{
    class EntryPoint
    {
        private static App _app = new App();

        [STAThread]
        public static void Main()
        {
            Exception ex = null;
            for (int i = 0; i < 1; i++)
            {
                try
                {
                    ex = null;
                    StartProcess();
                    break;
                }
                catch (Exception e)
                {
                    Thread.Sleep(1000);
                    ex = e;
                }
            }
            if (ex != null)
            {
                var errorWindow = new ErrorMessageBox(ex.Message);
                _app.Run(errorWindow);
            }
        }

        private static void StartProcess()
        {
            var currentProcess = Process.GetCurrentProcess();
            var processes = Process.GetProcessesByName(currentProcess.ProcessName).Where(x => x.Id != currentProcess.Id).ToList();
            //var processes = Process.GetProcessesByName("ResultTransferGUI").Where(x => x.Id != currentProcess.Id).ToList();
            if (processes.Count == 0)
            {
                StartCurrentGui(_app);
            }
            else if (processes.Count == 1)
            {
                var args = GetCommandLineArgs(processes.First());
                var currentArgs = GetCurrentAppArgs();
                if (!IsArgsMatch(currentArgs, args))
                {
                    try
                    {
                        processes.First().Kill();
                        StartCurrentGui(_app);
                    }
                    catch
                    {
                        //more than one normal user login condition.
                        //ignore
                    }
                }
            }
            else if (processes.Count > 1)
            {
                foreach (var process in processes)
                {
                    process.Kill();
                }
                StartCurrentGui(_app);
            }
        }

        private static string[] GetCurrentAppArgs()
        {
            var result = new List<string>();
            var currentArgs = Environment.GetCommandLineArgs();
            foreach (var currentArg in currentArgs)
            {
                if (currentArg.Contains(".exe"))
                {
                    continue;
                }
                if (currentArg == string.Empty)
                {
                    continue;
                }
                //if (currentArg.Contains("-p:"))
                //{
                //    continue;
                //}
                result.Add(currentArg.Replace('"'.ToString(), ""));
            }
            return result.ToArray();
        }

        private static bool IsArgsMatch(string[] currentArgs, string[] args)
        {
            if (currentArgs.Length != args.Length)
            {
                return false;
            }
            foreach (var currentArg in currentArgs)
            {
                if (!args.Contains(currentArg))
                {
                    return false;
                }
            }
            return true;
        }

        private static void StartCurrentGui(App app)
        {
            var mainWindow = new MainWindow();
            app.Run(mainWindow);
        }

        private static string[] GetCommandLineArgs(Process process)
        {
            var result = new List<string>();
            try
            {
                var line = GetCommandLine(process);
                var rawArgs = line.Split(" ".ToCharArray());
                foreach (var rawArg in rawArgs)
                {
                    if (rawArg.Contains("-h") || rawArg.Contains("-sn") || rawArg.Contains("-mts") || rawArg.Contains("-p:"))
                    {
                        result.Add(rawArg.Replace('"'.ToString(), ""));
                    }
                }
            }
            catch (Win32Exception ex) when ((uint)ex.ErrorCode == 0x80004005)
            {
                // Intentionally empty.
            }
            return result.ToArray();
        }

        private static string GetCommandLine(Process process)
        {
            var commandLine = new StringBuilder();

            commandLine.Append(" ");
            using (var searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
            {
                foreach (var @object in searcher.Get())
                {
                    commandLine.Append(@object["CommandLine"]);
                    commandLine.Append(" ");
                }
            }

            return commandLine.ToString();
        }
    }
}
