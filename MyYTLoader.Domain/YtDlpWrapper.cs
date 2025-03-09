using System.Diagnostics;

namespace MyYTLoader.Domain
{
    public class YtDlpWrapper : IYtDlpWrapper
    {
        public ILogsProvider _logsProvider;

        public YtDlpWrapper(ILogsProvider logsProvider)
        {
            _logsProvider = logsProvider;
        }

        public void Run(string fileName, string arguments)
        {
            //* Create your Process
            Process process = new Process();
            process.StartInfo.FileName = fileName;// "cmd.exe";
            process.StartInfo.Arguments = arguments; // "/c DIR";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            //* Set your output and error (asynchronous) handlers
            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
            //* Start process and handlers
            //process.Start();
            //process.BeginOutputReadLine();
            //process.BeginErrorReadLine();
            //process.WaitForExit();
        }

        public void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            //* Do your stuff with the output (write to console/log/StringBuilder)
            //Console.WriteLine(outLine.Data);
            _logsProvider.AddLog(outLine.Data ?? string.Empty);
        }
    }
}
