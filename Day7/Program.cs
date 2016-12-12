using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Day7
{
    /// <summary>
    /// Day 7: Internet Protocol Version 7
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day7input.txt");
            var testfile = File.ReadAllLines("../../testinput.txt");

            ProcessInputA(file);

            ProcessInputB(file);

            Console.Read();
        }

        public static void ProcessInputA(string[] lines)
        {
            var len = 4;
            var validIps = 0;
            foreach (var line in lines)
            {
                var wordsPalindrome = false;
                var bracketsPalindrome = false;

                var splits = SplitLine(line);

                // check for palindromes in the words not in brackets
                foreach (var s in splits.Words)
                {
                    for (var i = 0; i < s.Length; i++)
                    {
                        var start = i;
                        var end = (i + len) - 1;

                        if (end < s.Length-1)
                        {
                            var newWord = s.Substring(start, len);

                            var result = IsPalindrome(newWord);

                            if (result)
                            {
                                wordsPalindrome = true;
                                break;
                            }
                        }
                    }

                    if (wordsPalindrome)
                        break;
                }

                // check for any palindromes in the words between brackets
                foreach (var b in splits.BracketWords)
                {
                    for (var i = 0; i < b.Length; i++)
                    {
                        var start = i;
                        var end = (i + len) - 1;

                        if (end < b.Length - 1)
                        {
                            var newWord = b.Substring(i, len);

                            var result = IsPalindrome(newWord);

                            if (result)
                            {
                                bracketsPalindrome = true;
                                break;
                            }
                        }
                    }

                    if (bracketsPalindrome)
                        break;
                }

                // if there is at least one palindrome in a word outside of brackets,
                // and no palindromes in words within brackets, then the IP is valid
                if (wordsPalindrome && bracketsPalindrome == false)
                {
                    validIps++;
                }
            }

            Console.WriteLine("Valid ABBA IPs = " + validIps);
        }

        public static void ProcessInputB(string[] lines)
        {
            var len = 3;
            var validIps = 0;
            
            foreach (var line in lines)
            {
                var ipFound = false;
                var wordsPalindrome = false;
                var bracketsPalindrome = false;
                
                var splits = SplitLine(line);
                var palindromeWords = new List<string>();
                // check for palindromes in the words not in brackets
                foreach (var s in splits.Words)
                {
                    if (s.Length > len)
                    {
                        for (var i = 0; i < s.Length; i++)
                        {

                            var start = i;
                            var end = (i + len) - 1;

                            if (end < s.Length)
                            {
                                var newWord = s.Substring(start, len);

                                var result = IsPalindrome(newWord);

                                if (result && newWord.Distinct().Count() > 1)
                                {
                                    
                                    var l1 = newWord[0];
                                    var l2 = newWord[1];
                                    var sb = new StringBuilder();
                                    sb.Append(l2).Append(l1).Append(l2);
                                    var searchWord = sb.ToString();
                                    
                                    foreach (var bWord in splits.BracketWords)
                                    {
                                        if (bWord.Contains(searchWord))
                                        {
                                            Console.WriteLine("Word = " + s + ",    " + newWord);
                                            Console.WriteLine("Search word = " + searchWord);
                                            Console.WriteLine("Bracketed word = " + bWord);
                                            validIps++;
                                            ipFound = true;
                                            break;
                                        }
                                    }
                                }
                            }
                            if (ipFound)
                                break;
                        }
                    }
                    else
                     {
                        var result = IsPalindrome(s);

                        if (result && s.Distinct().Count() > 1)
                        {
                            Console.WriteLine("Word = " + s + ",    " + s);
                            var l1 = s[0];
                            var l2 = s[1];
                            var sb = new StringBuilder();
                            sb.Append(l2).Append(l1).Append(l2);
                            var searchWord = sb.ToString();
                            Console.WriteLine("Search word = " + searchWord);
                            foreach (var bWord in splits.BracketWords)
                            {
                                if (bWord.Contains(searchWord))
                                {
                                    Console.WriteLine("Bracketed word = " + bWord);
                                    validIps++;
                                    break;
                                }
                            }
                        }
                    }

                    if (ipFound)
                        break;
                }
            }

            Console.WriteLine("Valid ABBA IPs = " + validIps);
        }

        /// <summary>
        /// Checks to see if a word is a palindrome
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static bool IsPalindrome(string word)
        {
            var min = 0;
            var max = word.Length - 1;

            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                var a = word[min];
                var b = word[max];
                if (char.ToLower(a) != char.ToLower(b) || word.Length == 1)
                {
                    return false;
                }
                min++;
                max--;
            }
        }

        /// <summary>
        /// Splits a string into words within brackets and words not within brackets
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static Splits SplitLine(string line)
        {
            var splits = new List<string>();
            var bracketSplits = new List<string>();

            var patternInBrackets = @"\[(.*?)\]";

            var bracketMatches = Regex.Matches(line, patternInBrackets);

            foreach (Match m in bracketMatches)
            {
                bracketSplits.Add(m.Groups[1].Value);
            }

            var patternOutsideBrackets = @"\](.*?)\[";

            var nonbracketMatches = Regex.Matches(line, patternOutsideBrackets);

            foreach (Match m in nonbracketMatches)
            {
                splits.Add(m.Groups[1].Value);
            }

            var beginningString = line.Substring(0, line.IndexOf('['));
            splits.Add(beginningString);
            var endingString = line.Substring(line.LastIndexOf(']') + 1);
            splits.Add(endingString);

            return new Splits
            {
                Words = splits,
                BracketWords = bracketSplits
            };
        }

        public class Splits
        {
            public List<string> Words { get; set; }
            public List<string> BracketWords { get; set; }
        }
    }

}
