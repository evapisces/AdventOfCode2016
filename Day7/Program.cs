using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day7input.txt");
            var testfile = File.ReadAllLines("../../testinput.txt");


            ProcessInputA(file);

            Console.Read();
        }

        public static void ProcessInputA(string[] lines)
        {
            var validIps = 0;
            foreach (var line in lines)
            {
                var wordsPalindrome = false;
                var bracketsPalindrome = false;

                var splits = SplitLine(line);

                foreach (var s in splits.Words)
                {
                    for (var i = 0; i < s.Length; i++)
                    {
                        var result = IsPalindrome(new string(s.Skip(i).ToArray()));

                        if (result)
                        {
                            wordsPalindrome = true;
                            break;
                        }
                    }

                    if (wordsPalindrome)
                        break;
                }

                foreach (var b in splits.BracketWords)
                {
                    for (var i = 0; i < b.Length; i++)
                    {
                        var result = IsPalindrome(new string(b.Skip(i).ToArray()));

                        if (result)
                        {
                            bracketsPalindrome = true;
                            break;
                        }
                    }

                    if (bracketsPalindrome)
                        break;
                }

                if (wordsPalindrome && bracketsPalindrome == false)
                {
                    validIps++;
                }

                /*var splits = line.Split(new string[] {"[", "]"}, StringSplitOptions.None);
                var leftPalindrome = false;
                var middlePalindrome = false;
                var rightPalindrome = false;

                for (var i = 0; i < splits[0].Length; i++) { 
                    var palindromeFound = IsPalindrome(new string(splits[0].Skip(i).ToArray()));

                    if (palindromeFound)
                    {
                        leftPalindrome = true;
                        break;
                    }
                }

                for (var i = 0; i < splits[1].Length; i++)
                {
                    var palindromeFound = IsPalindrome(new string(splits[1].Skip(i).ToArray()));

                    if (palindromeFound)
                    {
                        middlePalindrome = true;
                        break;
                    }
                }

                for (var i = 0; i < splits[2].Length; i++)
                {
                    var palindromeFound = IsPalindrome(new string(splits[2].Skip(i).ToArray()));

                    if (palindromeFound)
                    {
                        rightPalindrome = true;
                        break;
                    }
                }

                if ((leftPalindrome == true || rightPalindrome == true) && middlePalindrome == false)
                    validIps++;*/
            }

            Console.WriteLine("Valid IPs = " + validIps);
        }

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

            Console.WriteLine("==================================================================");

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

            /*while (!string.IsNullOrEmpty(test) || !string.IsNullOrEmpty(test2))
            {
                var t = new string(line.Skip(nextLeftIndex).ToArray());
                var group1 = Regex.Match(t, @"\[([^]]*)\]").Groups[1];
                test = group1.Value; // finds words in [...]

                if (!string.IsNullOrEmpty(test))
                {
                    bracketSplits.Add(test);
                    nextLeftIndex = group1.Index + 1;
                }

                var u = new string(line.Skip(nextRightIndex).ToArray());
                var group2 = Regex.Match(line, @"\]([^[]*)\[").Groups[1];
                test2 = group2.Value; // finds words in ]...[
                if (!string.IsNullOrEmpty(test2))
                {
                    splits.Add(test2);
                    nextRightIndex = group2.Index + 1;
                }
            }
            var beginningString = line.Substring(0, line.IndexOf('['));
            splits.Add(beginningString);
            var endingString = line.Substring(line.LastIndexOf(']') + 1);
            splits.Add(endingString);*/


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
