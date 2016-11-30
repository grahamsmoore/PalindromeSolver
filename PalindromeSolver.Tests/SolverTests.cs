using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PalindromeSolver.Tests
{
    [TestClass]
    public class SolverTests
    {
        private Solver _solver;

        [TestInitialize]
        public void Setup()
        {
            _solver = new Solver();
        }

        [TestMethod]
        public void VerifyFirstOutputOfDefaultInputString()
        {
            VerifyOutput(Solver.DefaultInputString, 0, "Text: hijkllkjih, Index: 23, Length: 10");
        }

        [TestMethod]
        public void VerifySecondOutputOfDefaultInputString()
        {
            VerifyOutput(Solver.DefaultInputString, 1, "Text: defggfed, Index: 13, Length: 8");
        }

        [TestMethod]
        public void VerifyThirdOutputOfDefaultInputString()
        {
            VerifyOutput(Solver.DefaultInputString, 2, "Text: abccba, Index: 5, Length: 6");
        }

        [TestMethod]
        public void VerifyEmptyListReturnedWhenNoPalindromesFound()
        {
            _solver.Run("qwertyuiop").Should().BeEmpty();
        }

        [TestMethod]
        public void VerifyEmptyListReturnedWhenEmptyInputString()
        {
            _solver.Run(string.Empty).Should().BeEmpty();
        }

        [TestMethod]
        public void VerifyEmptyListReturnedWhenNullInputString()
        {
            _solver.Run(null).Should().BeEmpty();
        }

        [TestMethod]
        public void VerifyPalindromeReturnForOddLengthPalindromes()
        {
            VerifySinglePalindromeResult("qwertybobqwerty", 0, "bob", 6, 3);
        }

        [TestMethod]
        public void VerifyPalindromeReturnForEvenLengthPalindromes()
        {
            VerifySinglePalindromeResult("qwertynoonqwerty", 0, "noon", 6, 4);
        }

        [TestMethod]
        public void VerifyPalindromeReturnAtStartOfInputString()
        {
            VerifySinglePalindromeResult("abacabaqwerty", 1, "abacaba", 0, 7);
        }

        [TestMethod]
        public void VerifyPalindromeReturnAtEndOfInputString()
        {
            VerifySinglePalindromeResult("qwertyabacaba", 1, "abacaba", 6, 7);
        }

        private void VerifyOutput(string input, int resultIndex, string palindrome)
        {
            var result = _solver.Run(input);
            var output = _solver.Output(result).ToList();

            output[resultIndex].Should().Be(palindrome);
        }

        private void VerifySinglePalindromeResult(string input, int resultIndex, string palindrome, int index, int length)
        {
            var result = _solver.Run(input);

            result[resultIndex].Palindrome.Should().Be(palindrome);
            result[resultIndex].Index.Should().Be(index);
            result[resultIndex].Length.Should().Be(length);

        }
    }
}