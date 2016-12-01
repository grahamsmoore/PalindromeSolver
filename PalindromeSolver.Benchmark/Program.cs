using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnostics.Windows;
using BenchmarkDotNet.Running;

namespace PalindromeSolver.Benchmark
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmark>(
                ManualConfig.Create(DefaultConfig.Instance)
                    .With(new MemoryDiagnoser()));
        }
    }
}