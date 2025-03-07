
namespace MyYTLoader.Domain
{
    public interface ILogsProvider
    {
        void AddLog(string log);
        IReadOnlyList<string> GetLogs();
    }
}