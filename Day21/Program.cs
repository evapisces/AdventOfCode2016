using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var startingString = "abcdefgh";
            var file = File.ReadAllLines("../../day21input.txt");
            var testStartingString = "abcde";
            var testFile = File.ReadAllLines("../../testinput.txt");

            ProcessInputA(testFile, testStartingString.ToCharArray());
        }

        public static void ProcessInputA(string[] lines, char[] str)
        {
            foreach (var line in lines)
            {
                var split = line.Replace(".", "").Split(' ');
                // SWAP
                if (line.ToLower().StartsWith("swap"))
                {
                    if (split[1].ToLower() == "letter")
                    {
                        for (var i = 0; i < str.Length; i++)
                        {
                            if (str[i] == char.Parse(split[2]))
                                str[i] = char.Parse(split[5]);
                            else if (str[i] == char.Parse(split[5]))
                                str[i] = char.Parse(split[2]);
                        }
                    }
                    else if (split[1].ToLower() == "position")
                    {
                        var p1 = int.Parse(split[2]);
                        var p2 = int.Parse(split[5]);
                        var temp1 = str[p1];
                        var temp2 = str[p2];
                        str[p1] = temp2;
                        str[p2] = temp1;
                    }
                }

                // ROTATE
                else if (line.ToLower().StartsWith("rotate"))
                {
                    
                }

                // MOVE
                else if (line.ToLower().StartsWith("move"))
                {
                    
                }

                // REVERSE
                else if (line.ToLower().StartsWith("reverse"))
                {
                    var start = int.Parse(split[2]);
                    var len = int.Parse(split[4]) - start;
                    var strToReverse = new string(str).Substring(start, len).Reverse();
                }
            }
        }
    }
}
