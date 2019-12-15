using ClassLibrary;
using NLog;
using System;

namespace ConsoleApp
{
    internal class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private static void ConfigureNLog()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "log.txt" };

            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
            LogManager.Configuration = config;
        }

        static void Main(string[] args)
        {
            ConfigureNLog();

            var converter = new StringConverter(logger);
            string number = "-123456789";
            var result = converter.ToInt32(number);

            Console.WriteLine(result);
        }
    }
}
