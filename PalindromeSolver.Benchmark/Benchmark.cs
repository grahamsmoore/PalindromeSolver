using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace PalindromeSolver.Benchmark
{
    public class Benchmark
    {
        [Benchmark]
        public List<PalindromeResult> Method1()
        {
            return Solver.RunMethod1(Solver.DefaultInputString);
        }

        [Benchmark]
        public List<PalindromeResult> Method2()
        {
            return Solver.RunMethod2(Solver.DefaultInputString);
        }
    }
}