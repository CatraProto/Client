using System;
using System.Buffers;
using BenchmarkDotNet.Attributes;
using CatraProto.Client.Crypto.AAA;
using CatraProto.Client.Crypto.AesEncryption;
using Microsoft.Diagnostics.Tracing.Parsers;

namespace CatraProto.Client.Benchmark.Crypto
{
	//Not really a test, it's just to have an idea
	[MemoryDiagnoser]
	public class IgeEncryptorTest
	{
        private const int MAX_ITER = 1;
		private OldCryptoFuckery _encryptorOld;
        private IgeEncryptor _encryptorPool;
        private IgeEncryptorOneShot _encryptorOneShot;

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
			_encryptorOld = new OldCryptoFuckery(key, iv);
            _encryptorOneShot = new IgeEncryptorOneShot(key, iv);
            _encryptorPool = new IgeEncryptor(key, iv);
        }

        [Benchmark]
		public void EncryptOld()
		{
            for (int i = 0; i < MAX_ITER; i++)
            {
                _encryptorOld.Encrypt(_payload);
            }
        }
		
		[Benchmark]
		public void DecryptOld()
		{
            for(int i = 0; i < MAX_ITER; i++)
            {
                _encryptorOld.Decrypt(_payload);
            }
        }

        /*
        [Benchmark]
        public void EncryptOneShot()
        {
            for (int i = 0; i < MAX_ITER; i++)
            {
                using (var memory = MemoryPool<byte>.Shared.Rent(_payload.Length))
                {
                    _encryptorOneShot.Transform(_payload, memory.Memory.Span, true);
                }
            }
        }

        [Benchmark]
        public void DecryptOneShot()
        {
            for (int i = 0; i < MAX_ITER; i++)
            {       
                using (var memory = MemoryPool<byte>.Shared.Rent(_payload.Length))
                {
                    _encryptorOneShot.Transform(_payload, memory.Memory.Span, false);
                }
            }
        }*/

        [Benchmark]
        public void EncryptPool()
        {
            for (int i = 0; i < MAX_ITER; i++)
            {
                _encryptorPool.Encrypt(_payload);
            }
        }

        [Benchmark]
        public void DecryptPool()
        {
            for (int i = 0; i < MAX_ITER; i++)
            {
                _encryptorPool.Decrypt(_payload);
            }
        }

        [Benchmark]
        public void EncryptPool_PoolResult()
        {
            for (int i = 0; i < MAX_ITER; i++)
            {
                var destination = ArrayPool<byte>.Shared.Rent(_payload.Length);
                _encryptorPool.Encrypt(_payload, destination);
                ArrayPool<byte>.Shared.Return(destination, true);
            }
        }

        [Benchmark]
        public void DecryptPool_PoolResult()
        {
            for (int i = 0; i < MAX_ITER; i++)
            {
                var destination = ArrayPool<byte>.Shared.Rent(_payload.Length);
                _encryptorPool.Decrypt(_payload, destination);
                ArrayPool<byte>.Shared.Return(destination, true);
            }
        }


        [GlobalCleanup]
		public void CleanUp()
		{
			_encryptorOld.Dispose();
            _encryptorOneShot.Dispose();
            _encryptorPool.Dispose();
		}
	}
}