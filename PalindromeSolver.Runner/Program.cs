using System;

namespace PalindromeSolver.Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var result = Solver.RunMethod1(Solver.DefaultInputString);
            var result2 = Solver.RunMethod2(Solver.DefaultInputString);
            var output = Solver.Output(result);

            foreach (var item in output)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}