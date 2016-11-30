// <copyright file="PalindromeResult.cs" company="WN Trading Ltd.">
// Copyright (c) WN Trading Ltd.</copyright>

namespace PalindromeSolver
{
    public struct PalindromeResult
    {
        public PalindromeResult(string palindrome, int index, int length)
        {
            Palindrome = palindrome;
            Index = index;
            Length = length;
        }

        public string Palindrome { get; set; }

        public int Index { get; set; }

        public int Length { get; set; }
    }
}