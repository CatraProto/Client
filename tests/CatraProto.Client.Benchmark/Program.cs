using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using CatraProto.Client.Benchmark.Crypto;

namespace CatraProto.Client.Benchmark
{
	class Program
	{
		static void Main(string[] args)
		{
			BenchmarkRunner.Run<IgeEncryptorTest>();
		}
	}
}