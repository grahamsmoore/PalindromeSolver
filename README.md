I recently took part in a coding challenge to write code to solve a palindrome problem.  This blog post details the challenge, and my solution.

#####Challenge
*Write an application that finds the 3 longest unique palindromes in a supplied string. For the 3 longest
palindromes, report the palindrome, start index and length, in descending order of length.*

Given the input string: `sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop` , the output should be:
```
Text: hijkllkjih, Index: 23, Length: 10
Text: defggfed, Index: 13, Length: 8
Text: abccba, Index: 5 Length: 6
```
###Solution
So initially the problem doesn't look like that much of an issue, so I thought I'd challenge my self to write the highest performance solution possible.
There are plenty of naive solutions floating around the internet which solve the problem with \(O(n^3)\) or \(O(n^2)\) complexity, examining all substrings, testing each one to see it it's a palindrome; I was sure it could be done more efficiently so set about finding a better solution.

Here is the code I came up with:
<script src="https://gist.github.com/grahamsmoore/79fa0f7fe09729ea979f31d44bfa1ee5.js"></script>

This code is based on the fact that a palindrome can be centred on either a letter or a space between a letter (for even length palindromes).  For each possible palindrome centre, I expand left and right to see if we have a valid palindrome.  The method above returns all unique palindromes in source string.

The Visual Studio project for this solution can be found in my [GitHub](https://github.com/grahamsmoore/PalindromeSolver) repository.

###Performance
To test the performance of my solution I used the excellent [BenchmarkDotNet](https://github.com/PerfDotNet/BenchmarkDotNet).  The results are as follows:
```ini
Host Process Environment Information:
BenchmarkDotNet=v0.10.0
OS=Microsoft Windows NT 6.2.9200.0
Processor=Intel(R) Core(TM) i7-6700K CPU 4.00GHz, ProcessorCount=8
Frequency=3914061 Hz, Resolution=255.4891 ns, Timer=TSC
Host Runtime=Clr 4.0.30319.42000, Arch=32-bit RELEASE
GC=Concurrent Workstation
JitModules=clrjit-v4.6.1586.0
Job Runtime(s):
  Clr 4.0.30319.42000, Arch=32-bit RELEASE

Type=Benchmark  Mode=Throughput
```
<table border="1" style="width:auto">
  <tr>
    <th>Method</th>
    <th>Mean</th>
    <th>StdDev</th>
    <th>Median</th> 
    <th>Gen 0</th>
    <th>Bytes Allocated/Op</th>
  </tr>
  <tr>
    <td>Run</td>
    <td>297.3192 ns</td> 
    <td>1.1824 ns</td>
    <td>297.4385 ns</td>
    <td>1,216.00</td>
    <td>334.02</td>
  </tr>  
</table>

###Conclusion
The above result can as quite a surprise to, even I was not expecting to to be this fast, I mean 0.000297 milliseconds is impressive.  Coding challenge complete!