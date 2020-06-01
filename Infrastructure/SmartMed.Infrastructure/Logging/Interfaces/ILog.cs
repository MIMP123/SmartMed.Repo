using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMed.Infrastructure.Logging
{
    public interface ILog
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
