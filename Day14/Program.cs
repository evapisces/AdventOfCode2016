using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day14
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var salt = "zpqevtbw";
            var testSalt = "abc";

            //ProcessInputA(salt);
            ProcessInputB(testSalt);

            Console.Read();
        }

        public static void ProcessInputA(string salt)
        {
            var potentialKeys = new Dictionary<int, string>();
            var keys = new Dictionary<int, string>();
            var i = 0;
            var index = 1;

            while (keys.Count < 64)
            {
                var hash = CalculateMdD5Hash(salt + i);
                var matches = Regex.Matches(hash, @"(\w)\1{2,}");

                if (matches.Count > 0)
                {
                    var match = matches[0].Value;
                    var ch = match[0];
                    for (var j = i+1; j <= 1000 + i; j++)
                    {
                        var newHash = CalculateMdD5Hash(salt + j);

                        var consecutiveMatches = Regex.Matches(newHash, @"(" + ch + @")\1{4,}");

                        if (consecutiveMatches.Count > 0)
                        {
                            Console.WriteLine("(" + index + ")  Key: " + i + ", " + consecutiveMatches[0].Value);
                            Console.WriteLine("Hash = " + hash);
                            Console.WriteLine("NewHash = " + newHash);
                            keys.Add(i, consecutiveMatches[0].Value);
                            index++;
                            break;
                        }
                    }
                }

                i++;
            }

            var allKeys = keys.OrderBy(k => k.Key);
            Console.WriteLine("64th key at index " + allKeys.Last().Key);
        }

        public static void ProcessInputB(string salt)
        {
            var keys = new Dictionary<int, string>();
            var i = 0;
            var index = 1;

            while (keys.Count < 65)
            {
                var hash = StretchHash(salt + i);
                var matches = Regex.Matches(hash, @"(\w)\1{2,}");

                if (matches.Count > 0)
                {
                    var match = matches[0].Value;
                    var ch = match[0];
                    for (var j = i + 1; j <= 1000 + i; j++)
                    {
                        var newHash = CalculateMdD5Hash(salt + j);

                        var consecutiveMatches = Regex.Matches(newHash, @"(" + ch + @")\1{4,}");

                        if (consecutiveMatches.Count > 0)
                        {
                            Console.WriteLine("(" + index + ")  Key: " + i + ", " + consecutiveMatches[0].Value);
                            Console.WriteLine("Hash = " + hash);
                            Console.WriteLine("NewHash = " + newHash);
                            keys.Add(i, consecutiveMatches[0].Value);
                            index++;
                            break;
                        }
                    }
                }

                i++;
            }

            var allKeys = keys.OrderBy(k => k.Key);
            Console.WriteLine("64th key at index " + allKeys.Last().Key);
        }

        private static string CalculateMdD5Hash(string input)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }

        private static string StretchHash(string hash)
        {
            for (var i = 0; i < 2017; i++)
            {
                hash = CalculateMdD5Hash(hash);
            }

            return hash;
        }
    }
}
