using BenchmarkDotNet.Running;

namespace CatraProto.Client.Benchmark
{
    public class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }
    }
}