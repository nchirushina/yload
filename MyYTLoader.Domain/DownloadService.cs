using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyYTLoader.Domain.Configs;

namespace MyYTLoader.Domain
{
    public class DownloadService : IDownloadService
    {
        private readonly IYtDlpWrapper _ytDlpWrapper;
        private readonly YtDlpWrapperConfig _config;

        public DownloadService(IYtDlpWrapper ytDlpWrapper,
            IOptions<YtDlpWrapperConfig> YtDlpWrapperConfigOptions)
        {
            _ytDlpWrapper = ytDlpWrapper;
            _config = YtDlpWrapperConfigOptions.Value;
        }

        public void Download(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new UriFormatException();
            }

            _ytDlpWrapper.Run(_config.YtdlpBinaryPath, url);
        }
    }
}
