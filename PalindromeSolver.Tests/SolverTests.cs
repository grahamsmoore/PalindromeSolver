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
            var result = Solver.RunMethod1(input);
            var output = Solver.Output(result).ToList();

            output[resultIndex].Should().Be(palindrome);
        }

        private void VerifySinglePalindromeResult(string input, int resultIndex, string palindrome, int index,
            int length)
        {
            var result = Solver.RunMethod1(input);

            result[resultIndex].Palindrome.Should().Be(palindrome);
            result[resultIndex].Index.Should().Be(index);
            result[resultIndex].Length.Should().Be(length);
        }

        [Test]
        public void VerifyEmptyListReturnedWhenEmptyInputString()
        {
            Solver.RunMethod1(string.Empty).Should().BeEmpty();
        }

        [Test]
        public void VerifyEmptyListReturnedWhenNoPalindromesFound()
        {
            Solver.RunMethod1("qwertyuiop").Should().BeEmpty();
        }

        [Test]
        public void VerifyEmptyListReturnedWhenNullInputString()
        {
            Solver.RunMethod1(null).Should().BeEmpty();
        }

        [Test]
        public void VerifyFirstOutputOfDefaultInputString()
        {
            VerifyOutput(Solver.DefaultInputString, 0, "Text: hijkllkjih, Index: 23, Length: 10");
        }

        [Test]
        public void VerifyPalindromeReturnAtEndOfInputString()
        {
            VerifySinglePalindromeResult("qwertyabacaba", 1, "abacaba", 6, 7);
        }

        [Test]
        public void VerifyPalindromeReturnAtStartOfInputString()
        {
            VerifySinglePalindromeResult("abacabaqwerty", 1, "abacaba", 0, 7);
        }

        [Test]
        public void VerifyPalindromeReturnForEvenLengthPalindromes()
        {
            VerifySinglePalindromeResult("qwertynoonqwerty", 0, "noon", 6, 4);
        }

        [Test]
        public void VerifyPalindromeReturnForOddLengthPalindromes()
        {
            VerifySinglePalindromeResult("qwertybobqwerty", 0, "bob", 6, 3);
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