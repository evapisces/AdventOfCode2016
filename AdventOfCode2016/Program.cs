using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day1
{
    public class Program
    {
        private const int ORIGX = 0;
        private const int ORIGY = 0;

        public static void Main(string[] args)
        {
            // Part A

            var inputA =
                "R4, R5, L5, L5, L3, R2, R1, R1, L5, R5, R2, L1, L3, L4, R3, L1, L1, R2, R3, R3, R1, L3, L5, R3, R1, L1, R1, R2, L1, L4, L5, R4, R2, L192, R5, L2, R53, R1, L5, R73, R5, L5, R186, L3, L2, R1, R3, L3, L3, R1, L4, L2, R3, L5, R4, R3, R1, L1, R5, R2, R1, R1, R1, R3, R2, L1, R5, R1, L5, R2, L2, L4, R3, L1, R4, L5, R4, R3, L5, L3, R4, R2, L5, L5, R2, R3, R5, R4, R2, R1, L1, L5, L2, L3, L4, L5, L4, L5, L1, R3, R4, R5, R3, L5, L4, L3, L1, L4, R2, R5, R5, R4, L2, L4, R3, R1, L2, R5, L5, R1, R1, L1, L5, L5, L2, L1, R5, R2, L4, L1, R4, R3, L3, R1, R5, L1, L4, R2, L3, R5, R3, R1, L3";

            var totalMoves = 0;
            var input = Regex.Replace(inputA, @"\s+", "");
            var inputList = input.Split(',');

            foreach (var i in inputList)
            {
                var num = Convert.ToInt32(i.Substring(1, i.Length - 1));
                totalMoves += num;
            }


            var currX = ORIGX;
            var currY = ORIGY;

            var testInput = "R2, L3";
            ProcessInputA(ref currX, ref currY, testInput);
            Console.WriteLine("CurrX = " + currX + ", CurrY = " + currY);
            Console.WriteLine("Total Blocks = " + (Math.Abs(currX) + Math.Abs(currY)));
            currX = 0;
            currY = 0;

            testInput = "R2, R2, R2";
            ProcessInputA(ref currX, ref currY, testInput);
            Console.WriteLine("CurrX = " + currX + ", CurrY = " + currY);
            Console.WriteLine("Total Blocks = " + (Math.Abs(currX) + Math.Abs(currY)));
            currX = 0;
            currY = 0;

            testInput = "R5, L5, R5, R3";
            ProcessInputA(ref currX, ref currY, testInput);
            Console.WriteLine("CurrX = " + currX + ", CurrY = " + currY);
            Console.WriteLine("Total Blocks = " + (Math.Abs(currX) + Math.Abs(currY)));
            currX = 0;
            currY = 0;

            ProcessInputA(ref currX, ref currY, inputA);
            Console.WriteLine("CurrX = " + currX + ", CurrY = " + currY);
            Console.WriteLine("Total Blocks = " + (Math.Abs(currX) + Math.Abs(currY)));

            

            // Part B
            var inputB =
                "R4, R5, L5, L5, L3, R2, R1, R1, L5, R5, R2, L1, L3, L4, R3, L1, L1, R2, R3, R3, R1, L3, L5, R3, R1, L1, R1, R2, L1, L4, L5, R4, R2, L192, R5, L2, R53, R1, L5, R73, R5, L5, R186, L3, L2, R1, R3, L3, L3, R1, L4, L2, R3, L5, R4, R3, R1, L1, R5, R2, R1, R1, R1, R3, R2, L1, R5, R1, L5, R2, L2, L4, R3, L1, R4, L5, R4, R3, L5, L3, R4, R2, L5, L5, R2, R3, R5, R4, R2, R1, L1, L5, L2, L3, L4, L5, L4, L5, L1, R3, R4, R5, R3, L5, L4, L3, L1, L4, R2, R5, R5, R4, L2, L4, R3, R1, L2, R5, L5, R1, R1, L1, L5, L5, L2, L1, R5, R2, L4, L1, R4, R3, L3, R1, R5, L1, L4, R2, L3, R5, R3, R1, L3";
            var visited = new List<Coordinates>();

            //Array.Clear(visited, 0, visited.Length);

            currX = 0;
            currY = 0;

            //testInput = "R8, R4, R4, R8";
            //ProcessInputB(ref currX, ref currY, testInput, ref visited);

            ProcessInputB(ref currX, ref currY, inputA, ref visited);

            Console.Read();
        }

        public static void ProcessInputA(ref int currX, ref int currY, string input)
        {
            input = Regex.Replace(input, @"\s+", "");
            var inputList = input.Split(',');
            var dirFacing = 'U';
            foreach (var t in inputList)
            {
                var amtToMove = Convert.ToInt32(t.Substring(1));
                if (t.StartsWith("R"))
                {
                    switch (dirFacing)
                    {
                        case 'R':
                            currY -= amtToMove;
                            dirFacing = 'D';
                            break;
                        case 'L':
                            currY += amtToMove;
                            dirFacing = 'U';
                            break;
                        case 'U':
                            currX += amtToMove;
                            dirFacing = 'R';
                            break;
                        case 'D':
                            currX -= amtToMove;
                            dirFacing = 'L';
                            break;

                    }
                }
                else if (t.StartsWith("L"))
                {
                    switch (dirFacing)
                    {
                        case 'R':
                            currY += amtToMove;
                            dirFacing = 'U';
                            break;
                        case 'L':
                            currY -= amtToMove;
                            dirFacing = 'D';
                            break;
                        case 'U':
                            currX -= amtToMove;
                            dirFacing = 'L';
                            break;
                        case 'D':
                            currX += amtToMove;
                            dirFacing = 'R';
                            break;

                    }
                }
            }
        }

        public static void ProcessInputB(ref int currX, ref int currY, string input, ref List<Coordinates> visited)
        {
            //var matchFound = false;
            input = Regex.Replace(input, @"\s+", "");
            var inputList = input.Split(',');

            var dirFacing = 'U';
            visited.Add(new Coordinates
            {
                XCoord = currX,
                YCoord = currY
            });


            foreach (var t in inputList.Select((value, index) => new { index, value}))
            {
                Console.WriteLine("Index = " + t.index);
                var amtToMove = Convert.ToInt32(t.value.Substring(1));
                if (t.value.StartsWith("R"))
                {
                    switch (dirFacing)
                    {
                        case 'R':
                            for (var i = 1; i <= amtToMove; i++)
                            {
                                var node = new Coordinates
                                {
                                    XCoord = currX,
                                    YCoord = currY - i
                                };
                                visited.Add(node);
                            }
                            currY -= amtToMove;
                            dirFacing = 'D';
                            break;
                        case 'L':
                            for (var i = 1; i <= amtToMove; i++)
                            {
                                var node = new Coordinates
                                {
                                    XCoord = currX,
                                    YCoord = currY + i
                                };
                                visited.Add(node);
                            }
                            currY += amtToMove;
                            dirFacing = 'U';
                            break;
                        case 'U':
                            for (var i = 1; i <= amtToMove; i++)
                            {
                                var node = new Coordinates
                                {
                                    XCoord = currX + i,
                                    YCoord = currY
                                };
                                visited.Add(node);

                            }
                            currX += amtToMove;
                            dirFacing = 'R';
                            break;
                        case 'D':
                            for (var i = 1; i <= amtToMove; i++)
                            {
                                var node = new Coordinates
                                {
                                    XCoord = currX - i,
                                    YCoord = currY
                                };
                                visited.Add(node);
                            }
                            currX -= amtToMove;
                            dirFacing = 'L';
                            break;

                    }
                }
                else if (t.value.StartsWith("L"))
                {
                    switch (dirFacing)
                    {
                        case 'R':
                            for (var i = 1; i <= amtToMove; i++)
                            {
                                var node = new Coordinates
                                {
                                    XCoord = currX,
                                    YCoord = currY + i
                                };
                                visited.Add(node);
                            }
                            currY += amtToMove;
                            dirFacing = 'U';
                            break;
                        case 'L':
                            for (var i = 1; i <= amtToMove; i++)
                            {
                                var node = new Coordinates
                                {
                                    XCoord = currX,
                                    YCoord = currY - i
                                };
                                visited.Add(node);
                            }
                            currY -= amtToMove;
                            dirFacing = 'D';
                            break;
                        case 'U':
                            for (var i = 1; i <= amtToMove; i++)
                            {
                                var node = new Coordinates
                                {
                                    XCoord = currX - i,
                                    YCoord = currY
                                };
                                visited.Add(node);
                            }
                            currX -= amtToMove;
                            dirFacing = 'L';
                            break;
                        case 'D':
                            for (var i = 1; i <= amtToMove; i++)
                            {
                                var node = new Coordinates
                                {
                                    XCoord = currX + i,
                                    YCoord = currY
                                };
                                visited.Add(node);
                            }
                            currX += amtToMove;
                            dirFacing = 'R';
                            break;
                    }
                }
            }

            foreach (var node in visited)
            {
                var duplicatePoints = visited.Where(v => v.XCoord == node.XCoord && v.YCoord == node.YCoord).ToList();
                if (duplicatePoints.Count > 1)
                {
                    var xDist = node.XCoord;
                    var yDist = node.YCoord;
                    var totalDist = Math.Abs(xDist) + Math.Abs(yDist);
                    Console.WriteLine("Total Distance = " + totalDist);
                    break;
                }

            }
            
        }



        public class Coordinates
        {
            public int XCoord { get; set; }
            public int YCoord { get; set; }

            public bool Equals(Coordinates coord)
            {
                return XCoord == coord.XCoord && 
                    YCoord == coord.YCoord;
            }
        }
    }
}
