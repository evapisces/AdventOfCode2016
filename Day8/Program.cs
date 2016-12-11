using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

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

            ProcessInputAB(file, ref grid);

            Console.Read();
        }

        public static void ProcessInputAB(string[] lines, ref char[,] grid)
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
                PrintGrid(ref grid);
            }

            var litPixels = 0;
            for (var i = 0; i < MAXROWS; i++)
            {
                for(var j = 0; j < MAXCOLS; j++)
                {
                    if (grid[i, j] == '#')
                        litPixels++;
                }
            }

            Console.WriteLine("# of lit pixels = " + litPixels);
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

            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < l; j++)
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
                var colIndices = new List<int>();

                for (var i = 0; i < MAXCOLS; i++)
                {
                    if (grid[rowColNum, i] != '#')
                        continue;

                    grid[rowColNum, i] = '.';
                    colIndices.Add(i);
                }

                foreach (var i in colIndices)
                {
                    grid[rowColNum, (i + amt) % MAXCOLS] = '#';
                }
            }
            else if (rowcol == "column")
            {
                var rowIndices = new List<int>();

                for (var i = 0; i < MAXROWS; i++)
                {
                    if (grid[i, rowColNum] != '#')
                        continue;

                    grid[i, rowColNum] = '.';
                    rowIndices.Add(i);
                }

                foreach(var i in rowIndices)
                {
                    grid[(i + amt) % (MAXROWS), rowColNum] = '#';
                }
            }
        }

        // Part B: print out what the screen would say after all instructions
        // are ran though
        public static void PrintGrid(ref char[,] grid)
        {
            for (var i = 0; i < MAXROWS; i++)
            {
                for (var j = 0; j < MAXCOLS; j++)
                {
                    Console.Write(grid[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }
    }
}
