using System.Diagnostics;

namespace MyYTLoader.Domain
{
    public interface IYtDlpWrapper
    {
        void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine);
        void Run(string fileName, string arguments);
    }
}