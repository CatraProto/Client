using System;
using System.Threading.Tasks;
using CatraProto.Client.Crypto.Aes;
using CatraProto.Client.MTProto;
using Serilog.Core;
using Serilog.Events;

namespace CatraProto.Client
{
	public static class Start
	{
		public static async Task Main(string[] args)
		{
			var settings = new Settings("CutePony");
			var session = new Session(settings, Logger.CreateDefaultLogger(new LoggingLevelSwitch(LogEventLevel.Debug)));
			var client = new Client(session);
			var iv = new byte[32];
			var key = new byte[16];
			var payload = new byte[2047];

			var random = new Random();
			random.NextBytes(iv);
			random.NextBytes(key);
			random.NextBytes(payload);
			var encryptor = new IgeEncryptor(key, iv);
			encryptor.Encrypt(payload);
			Console.ReadLine();
		}
	}
}