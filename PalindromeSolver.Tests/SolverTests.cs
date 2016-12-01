using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace PalindromeSolver.Tests
{
    [TestFixture]
    public class SolverTests
    {
        private void VerifyOutput(string input, int resultIndex, string palindrome)
        {
            var result = Solver.Run(input);
            var output = Solver.Output(result).ToList();

            output[resultIndex].Should().Be(palindrome);
        }

        private void VerifySinglePalindromeResult(string input, int resultIndex, int start, int end, int length)
        {
            var result = Solver.Run(input);

            result[resultIndex].Start.Should().Be(start);
            result[resultIndex].End.Should().Be(end);
            result[resultIndex].Length.Should().Be(length);
        }

        [Test]
        public void VerifyEmptyListReturnedWhenEmptyInputString()
        {
            Solver.Run(string.Empty).Should().BeEmpty();
        }

        [Test]
        public void VerifyEmptyListReturnedWhenNoPalindromesFound()
        {
            Solver.Run("qwertyuiop").Should().BeEmpty();
        }

        [Test]
        public void VerifyEmptyListReturnedWhenNullInputString()
        {
            Solver.Run(null).Should().BeEmpty();
        }

        [Test]
        public void VerifyFirstOutputOfDefaultInputString()
        {
            VerifyOutput(Solver.DefaultInputString, 0, "Text: hijkllkjih, Index: 23, Length: 10");
        }

        [Test]
        public void VerifyPalindromeReturnAtEndOfInputString()
        {
            VerifySinglePalindromeResult("qwertyabacaba", 1, 6, 13, 7);
        }

        [Test]
        public void VerifyPalindromeReturnAtStartOfInputString()
        {
            VerifySinglePalindromeResult("abacabaqwerty", 1, 0, 7, 7);
        }

        [Test]
        public void VerifyPalindromeReturnForEvenLengthPalindromes()
        {
            VerifySinglePalindromeResult("qwertynoonqwerty", 0, 6, 10, 4);
        }

        [Test]
        public void VerifyPalindromeReturnForOddLengthPalindromes()
        {
            VerifySinglePalindromeResult("qwertybobqwerty", 0, 6, 9, 3);
        }

        [Test]
        public void VerifySecondOutputOfDefaultInputString()
        {
            VerifyOutput(Solver.DefaultInputString, 1, "Text: defggfed, Index: 13, Length: 8");
        }

        [Test]
        public void VerifyThirdOutputOfDefaultInputString()
        {
            VerifyOutput(Solver.DefaultInputString, 2, "Text: abccba, Index: 5, Length: 6");
        }
    }
}