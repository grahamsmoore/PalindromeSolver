// <copyright file="PalindromeResult.cs" company="WN Trading Ltd.">
// Copyright (c) WN Trading Ltd.</copyright>

namespace PalindromeSolver
{
    public struct PalindromeResult
    {
        public PalindromeResult(int start, int end, int length)
        {
            Start = start;
            End = end;
            Length = length;
        }

        public int Start { get; set; }

        public int End { get; set; }

        public int Length { get; set; }
    }
}