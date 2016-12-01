using System;
using System.Collections.Generic;
using System.Linq;

namespace PalindromeSolver
{
    public static class Solver
    {
        public const string DefaultInputString = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
        private const int MinimumPalindromeLength = 3;

        public static List<PalindromeResult> Run(string input)
        {
            if (input == null) return new List<PalindromeResult>();

            var length = input.Length;

            var centersLength = 2 * length + 1;

            var palindromes = new List<PalindromeResult>();

            for (var i = 0; i < centersLength; i++)
            {
                var s = i / 2;
                var e = s + i % 2;

                while (s > 0 && e < length && input[s - 1] == input[e])
                {
                    s--;
                    e++;
                }

                var palindromeLength = e - s;
                if (palindromeLength >= MinimumPalindromeLength)
                    palindromes.Add(new PalindromeResult(s, e, palindromeLength));
            }

            return palindromes;
        }

        public static IEnumerable<string> Output(List<PalindromeResult> palindromes)
        {
            var orderedPalindromes = palindromes.OrderByDescending(x => x.Length);

            foreach (var palindromeResult in orderedPalindromes.Take(3))
                yield return
                    $"Text: {DefaultInputString.Substring(palindromeResult.Start, palindromeResult.Length)}, Index: {palindromeResult.Start}, Length: {palindromeResult.Length}";
        }
    }
}