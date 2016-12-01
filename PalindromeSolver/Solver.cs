﻿using System.Collections.Generic;
using System.Linq;

namespace PalindromeSolver
{
    public static class Solver
    {
        public const string DefaultInputString = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
        public const int MinimumPalindromeLength = 3;

        public static List<PalindromeResult> RunMethod2(string input)
        {
            if (string.IsNullOrEmpty(input)) return new List<PalindromeResult>();

            var length = input.Length;

            var centersLength = (2 * length) + 1;
        
            var palindromes = new List<PalindromeResult>();

            for (var i = 0; i < centersLength; i++)
            {
                var s = i / 2;
                var e = s + i % 2;

                while (s > 0 && e < length && input[s - 1] == input[e])
                {
                    s -= 1;
                    e += 1;
                }

                var palindromeLength = e - s;
                if (palindromeLength >= MinimumPalindromeLength)
                {
                    palindromes.Add(new PalindromeResult(input.Substring(s, palindromeLength), i, palindromeLength));
                }
            }

            return palindromes;
        }

        public static List<PalindromeResult> RunMethod1(string input)
        {
            if (string.IsNullOrEmpty(input)) return new List<PalindromeResult>();

            var length = input.Length;
            var listOfPalindromes = new List<PalindromeResult>();

            for (var i = 0; i < length; i++)
            {
                for (var j = i + 1; j < length; j++)
                {
                    if (IsPalindrome(input, i, j))
                    {
                        listOfPalindromes.Add(new PalindromeResult(input.Substring(i, j - i + 1), i, j - i + 1));
                    }
                }
            }

            return listOfPalindromes;
        }

        public static IEnumerable<string> Output(List<PalindromeResult> palindromes)
        {
            var orderedPalindromes = palindromes.OrderByDescending(x => x.Length);
            var uniquePalindromes = GetUniquePalindroms(orderedPalindromes);

            foreach (var palindromeResult in uniquePalindromes.Take(3))
            {
                yield return $"Text: {palindromeResult.Palindrome}, Index: {palindromeResult.Index}, Length: {palindromeResult.Length}";
            }
        }

        private static bool IsPalindrome(string value, int start, int end)
        {
            var min = start;
            var max = end;
            while (true)
            {
                if (min > max)
                    return true;

                var a = value[min];
                var b = value[max];

                // There was no mention if case sensitivity in the requirements, 
                // but if this is important, then the values should be converted
                // to lower case using char.ToLower()
                if (a != b)
                    return false;

                min++;
                max--;
            }
        }

        private static IEnumerable<PalindromeResult> GetUniquePalindroms(IEnumerable<PalindromeResult> palindromeResults)
        {
            var results = new List<PalindromeResult>();
            foreach (var palindromeResult in palindromeResults)
            {
                if (!results.Any(result => result.Palindrome.Contains(palindromeResult.Palindrome)))
                    results.Add(palindromeResult);
            }

            return results;
        }
    }
}