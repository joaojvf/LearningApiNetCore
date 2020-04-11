using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EntityFramework.Infra.CrossCutting.Logging
{
    public class Logger : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new InternalLogger();
        }

        public void Dispose()
        {
        }

        private class InternalLogger : ILogger
        {
            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
            {
                string path = "C:\\Temp\\logEntity.txt";

                if (!File.Exists(path))
                {
                    string createLog = "Criando Arquivo de Log..." + Environment.NewLine;
                    File.WriteAllText(path, createLog);
                }

                System.IO.File.AppendAllText(path, formatter(state, exception));
                Console.WriteLine(formatter(state, exception));
            }
        }
    }
}
