using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    /// <summary>
    /// Day 6: Signals and Noise
    /// </summary>
    public class Program
    {
        static Dictionary<char, int> letterOccurrences = new Dictionary<char, int>();

        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../../day6input.txt").ToList();

            ProcessInputA(lines);
            ProcessInputB(lines);

            Console.Read();
        }

        public static void ProcessInputA(List<string> lines)
        {
            var lineLength = lines.First().Length;

            Console.Write("Part A Correct String = ");

            ResetDictionary(letterOccurrences);

            var j = 0;
            for (var i = 0; i < lineLength; i++)
            {
                foreach (var line in lines)
                {
                    letterOccurrences[line[j]]++;
                }

                var sortedOccurrences = letterOccurrences.OrderByDescending(l => l.Value);
                var mostUsedLetter = sortedOccurrences.First().Key;
                Console.Write(mostUsedLetter);
                ResetDictionary(letterOccurrences);
                j++;
            }
        }

        public static void ProcessInputB(List<string> lines)
        {
            var lineLength = lines.First().Length;

            Console.Write("PartB Correct String = ");

            ResetDictionary(letterOccurrences);

            var j = 0;
            for (var i = 0; i < lineLength; i++)
            {
                foreach (var line in lines)
                {
                    letterOccurrences[line[j]]++;
                }

                var sortedOccurrences = letterOccurrences.OrderBy(l => l.Value);
                var mostUsedLetter = sortedOccurrences.Where(s => s.Value > 0).First().Key;
                Console.Write(mostUsedLetter);
                ResetDictionary(letterOccurrences);
                j++;
            }
        }

        private static Dictionary<char, int> ResetDictionary(Dictionary<char, int> dict)
        {
            dict.Clear();

            foreach (var ch in "abcdefghijklmnopqrstuvwxyz")
            {
                letterOccurrences.Add(ch, 0);
            }

            return dict;
        }
    }
}
