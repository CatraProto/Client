using Serilog;
using Serilog.Core;
using Serilog.Sinks.SystemConsole.Themes;

namespace CatraProto.Client
{
    public static class Logger
    {
        public static ILogger CreateDefaultLogger(LoggingLevelSwitch? levelSwitch = null)
        {
            levelSwitch ??= new LoggingLevelSwitch();
            return new LoggerConfiguration()
                .WriteTo.Console(
                    outputTemplate:
                    "[{Timestamp:HH:mm:ss} {Level:u3}][{Session}][{SourceContext}] {Message:lj}{NewLine}{Exception}")
                .MinimumLevel.ControlledBy(levelSwitch)
                .CreateLogger();
        }
    }
}