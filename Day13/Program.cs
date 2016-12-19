using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13
{
    public class Program
    {
        private const int MAXROWS = 10;
        private const int MAXCOLS = 10;

        public static void Main(string[] args)
        {
            var favoriteNumber = 10;
            var targetX = 7;
            var targetY = 4;

            var matrix = new char[MAXROWS, MAXCOLS];

            InitializeCubeMaze(ref matrix, favoriteNumber);

            ProcessInputA(ref matrix, targetX, targetY);

            Console.Read();
        }

        public static void ProcessInputA(ref char[,] matrix, int targetX, int targetY)
        {
            
        }

        private static void InitializeCubeMaze(ref char[,] matrix, int n)
        {
            for (var x = 0; x < MAXROWS; x++)
            {
                for (var y = 0; y < MAXCOLS; y++)
                {
                    var num = (y * y + 3 * y + 2 * y * x + x + x * x) + n;
                    var binary = Convert.ToString(num, 2);  // convert number to binary string
                    var numberOfOnes = binary.Count(b => b == '1');

                    if (numberOfOnes % 2 == 0)
                    {
                        matrix[x, y] = '.';
                    }
                    else
                    {
                        matrix[x, y] = '#';
                    }

                    Console.Write(matrix[x, y] + " ");
                    if (y % MAXCOLS == MAXCOLS - 1)
                        Console.WriteLine("");
                }
            }
        }
    }
}
