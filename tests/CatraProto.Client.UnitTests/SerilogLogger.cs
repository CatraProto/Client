using Serilog;
using Serilog.Events;
using Xunit.Abstractions;

namespace CatraProto.Client.UnitTests
{
	public class SerilogLogger
	{
		public static ILogger CreateLogger<T>(ITestOutputHelper helper)
		{
			return new LoggerConfiguration()
				.WriteTo.TestOutput(helper, LogEventLevel.Debug,
					"[{Timestamp:HH:mm:ss} {Level:u3}][{SourceContext}] {Message:lj}{NewLine}{Exception}")
				.MinimumLevel.Debug()
				.CreateLogger().ForContext<T>();
		}
	}
}