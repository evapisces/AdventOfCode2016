using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    public class Program
    {
        public static readonly int MAXROWS = int.Parse(ConfigurationManager.AppSettings["MaxRows"]);
        public static readonly int MAXCOLS = int.Parse(ConfigurationManager.AppSettings["MaxCols"]);

        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day8input.txt");
            var grid = new char[MAXROWS, MAXCOLS];


            InitializeGrid(ref grid);


            ProcessInputA(file, ref grid);

            Console.Read();
        }

        public static void ProcessInputA(string[] lines, ref char[,] grid)
        {
            foreach (var line in lines)
            {
                if (line.StartsWith("rect"))
                {
                    RectCommand(line, ref grid);
                } else if (line.StartsWith("rotate"))
                {
                    RotateCommand(line, ref grid);
                }
            }
        }

        public static void ProcessInputB(string[] lines)
        {
            
        }

        private static void InitializeGrid(ref char[,] grid)
        {
            for (var i = 0; i < MAXROWS; i++)
            {
                for (var j = 0; j < MAXCOLS; j++)
                {
                    grid[i, j] = '.';
                }
            }
        }

        private static void RectCommand(string cmd, ref char[,] grid)
        {
            var dims = cmd.Split(' ')[1];
            var l = int.Parse(dims.Split('x')[0]);
            var h = int.Parse(dims.Split('x')[1]);

            for (var i = 0; i < l; i++)
            {
                for (var j = 0; j < h; j++)
                {
                    grid[i,j] = '#';
                }
            }
        }

        private static void RotateCommand(string cmd, ref char[,] grid)
        {
            var words = cmd.Split(' ');
            var rowcol = words[1];
            var rowColNum = int.Parse(words[2].Split('=')[1]);
            var amt = int.Parse(words[4]);

            if (rowcol == "row")
            {
                var row = grid.Cast<char>().Skip(rowColNum * MAXCOLS).Take(MAXCOLS).ToArray();

                foreach (var c in row)
                {
                    if (c == '#' && row.IndexOf() < row.Count - 1)
                    {
                        row[row.IndexOf(c) + 1] = '#';
                        
                    }
                    else if (c == '#' && row.IndexOf(c) == row.Count - 1)
                    {
                        row[0] = '#';
                    }
                    row[row.IndexOf(c)] = '.';
                }

            }
            else if (rowcol == "column")
            {
                foreach (var row in grid)
                {
                    
                }
            }

            grid = temp;
        }
    }

    /// <summary>
    /// 
    /// Source: http://stackoverflow.com/questions/27427527/how-to-get-a-complete-row-or-column-from-2d-array-in-c-sharp
    /// User: Matthew Watson (http://stackoverflow.com/users/106159/matthew-watson)
    /// </summary>
    public static class ArrayExt
    {
        public static T[] GetRow<T>(this T[,] array, int row)
        {
            if (!typeof(T).IsPrimitive)
                throw new InvalidOperationException("Not supported for managed types.");

            if (array == null)
                throw new ArgumentNullException("array");

            int cols = array.GetUpperBound(1) + 1;
            T[] result = new T[cols];
            int size = Marshal.SizeOf<T>();

            Array.Copy(array, row * cols * size, result, 0, cols * size);

            return result;
        }
    }
}
