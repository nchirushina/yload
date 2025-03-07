namespace MyYTLoader.Domain
{
    public class LogsProvider : ILogsProvider
    {
        private List<string> _logs = new();

        public void AddLog(string log)
        {
            if (_logs.Count > 500)
            {
                _logs = _logs.Skip(450).ToList();
            }

            _logs.Add(log);
        }

        public IReadOnlyList<string> GetLogs() => _logs;
    }
}
