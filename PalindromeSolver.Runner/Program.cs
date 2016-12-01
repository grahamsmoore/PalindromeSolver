using System;

namespace PalindromeSolver.Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var result = Solver.Run(Solver.DefaultInputString);
            var output = Solver.Output(result);

            foreach (var item in output)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}