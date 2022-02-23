using System;
using BenchmarkDotNet.Attributes;
using CatraProto.Client.Crypto.Aes;

namespace CatraProto.Client.Benchmark.Crypto
{
	//Not really a test, it's just to have an idea
	[MemoryDiagnoser]
	public class IgeEncryptorTest
	{
		private IgeEncryptor _encryptor;
		private byte[] _payload;

		[GlobalSetup]
		public void Setup()
		{
			var iv = new byte[32];
			var key = new byte[16];
			_payload = new byte[640];
			//_payload = new byte[1932240];
			
			var random = new Random();
			random.NextBytes(iv);
			random.NextBytes(key);
			random.NextBytes(_payload);
			_encryptor = new IgeEncryptor(key, iv);
		}

		[Benchmark]
		public void Encrypt()
		{
			_encryptor.Encrypt(_payload);
		}
		
		[Benchmark]
		public void Decrypt()
		{
			_encryptor.Decrypt(_payload);
		}

		[GlobalCleanup]
		public void CleanUp()
		{
			_encryptor.Dispose();
		}
	}
}