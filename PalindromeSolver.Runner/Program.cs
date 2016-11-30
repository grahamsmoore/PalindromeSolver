using System;

namespace PalindromeSolver.Runner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var solver = new Solver();
            var result = solver.Run(Solver.DefaultInputString);
            var output = solver.Output(result);

            foreach (var item in output)
                Console.WriteLine(item);

            Console.ReadLine();
        }
    }
}