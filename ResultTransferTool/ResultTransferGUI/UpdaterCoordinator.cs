using System;
using System.IO;
using Nlogger;

namespace ResultTransferGUI
{
    class UpdaterCoordinator
    {
        private readonly string _updaterPath;

        public UpdaterCoordinator()
        {
            _updaterPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updater", "Updater.exe");
        }

        public void RunUpdater()
        {
            ExecuteCommandSync(_updaterPath + " -close");
        }

        private void ExecuteCommandSync(string command)
        {
            LogManager.GetLogger("GUI").Info($"Run command: {command}.");
            try
            {
                // create the ProcessStartInfo using "cmd" as the program to be run,
                // and "/c " as the parameters.
                // Incidentally, /c tells cmd that we want it to execute the command that follows,
                // and then exit.
                System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo("cmd", "/c " + command);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;
                // Do not create the black window.
                procStartInfo.CreateNoWindow = true;
                
                //01/13/2022 adam add
                procStartInfo.FileName = _updaterPath;

                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;
                proc.Start();
                
                // Get the output into a string
                string result = proc.StandardOutput.ReadToEnd();
                // Display the command output.
                Console.WriteLine(result);
            }
            catch (Exception)
            {
                // Log the exception
            }
        }
    }
}
