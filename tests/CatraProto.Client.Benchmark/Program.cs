using System;
using BenchmarkDotNet.Running;
using CatraProto.Client.Benchmark.Crypto;
using CatraProto.Client.Crypto.Aes;
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