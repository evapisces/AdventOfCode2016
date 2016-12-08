using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    /// <summary>
    /// Day 5: How About a Nice Game of Chess?
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var testinput = "abc";
            var input = "cxdnnyjw";
            
            ProcessInputA(testinput);
            ProcessInputB(input);

            Console.Read();
        }

        public static void ProcessInputA(string input)
        {
            var index = 0;
            string hash;
            var password = "";

            var proceed = true;

            while (proceed)
            {
                index++;
                hash = CalculateMdD5Hash(input + index);

                if (hash.StartsWith("00000"))
                {
                    Console.WriteLine("Index of first 00000- hash = " + index);
                    password += hash[5];
                    if (password.Length == 8)
                        proceed = false;
                }
            }

            Console.WriteLine("Password = " + password);
        }

        public static void ProcessInputB(string input)
        {
            var index = 0;
            string hash;
            char[] password = new char[8];

            for (var i = 0; i < 8; i++)
            {
                password[i] = '_';
            }

            var proceed = true;

            while (password.Contains('_'))
            {
                hash = CalculateMdD5Hash(input + index);

                if (hash.StartsWith("00000"))
                {
                    if (char.IsDigit(hash[5]))
                    {
                        if (int.Parse(hash[5].ToString()) >= 0 && int.Parse(hash[5].ToString()) <= 7)
                        {
                            Console.WriteLine("Index = " + index + ",  Hash = " + hash);
                            Console.WriteLine("");
                            var i = int.Parse(hash[5].ToString());

                            if (password[i] == '_')
                                password[i] = hash[6];
                        }
                    }
                }

                index++;
            }

            Console.Write("Password = ");
            for (var i = 0; i < password.Length; i++)
            {
                Console.Write(password[i]);
            }
            Console.WriteLine("");
        }

        /// <summary>
        /// Calculates the MD5 hash for a given string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CalculateMdD5Hash(string input)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
