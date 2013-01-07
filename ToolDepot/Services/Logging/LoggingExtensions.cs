using System;
using ToolDepot.Core.Domain.Logging;

namespace ToolDepot.Services.Logging
{
    public static class LoggingExtensions
    {
        public static void Debug(this ILogger logger, string message, Exception exception = null, int userId=0)
        {
            FilteredLog(logger, LogLevel.Debug, message, exception, userId);
        }
        public static void Information(this ILogger logger, string message, Exception exception = null, int userId=0)
        {
            FilteredLog(logger, LogLevel.Information, message, exception, userId);
        }
        public static void Warning(this ILogger logger, string message, Exception exception = null, int userId=0)
        {
            FilteredLog(logger, LogLevel.Warning, message, exception, userId);
        }
        public static void Error(this ILogger logger, string message, Exception exception = null, int userId=0)
        {
            FilteredLog(logger, LogLevel.Error, message, exception, userId);
        }
        public static void Fatal(this ILogger logger, string message, Exception exception = null, int userId=0)
        {
            FilteredLog(logger, LogLevel.Fatal, message, exception, userId);
        }

        private static void FilteredLog(ILogger logger, LogLevel level, string message, Exception exception = null, int userId=0)
        {
            //don't log thread abort exception
            if ((exception != null) && (exception is System.Threading.ThreadAbortException))
                return;

            if (logger.IsEnabled(level))
            {
                string fullMessage = exception == null ? string.Empty : exception.ToString();
                logger.InsertLog(level, message, fullMessage, userId);
            }
        }
    }
}
