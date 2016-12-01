using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace PalindromeSolver.Benchmark
{
    public class Benchmark
    {
        [Benchmark]
        public List<PalindromeResult> Run()
        {
            return Solver.Run(Solver.DefaultInputString);
        }
    }
}