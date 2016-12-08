using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    /// <summary>
    /// Day 3: Squares With Three Sides
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            string line;
            var file = new StreamReader("../../input.txt");
            var triangleSides = new List<string[]>();
            while ((line = file.ReadLine()) != null)
            {
                triangleSides.Add(line.Trim().Split(' '));
            }

            ProcessInputA(ref triangleSides);
            ProcessInputB(ref triangleSides);

            Console.Read();
        }

        public static void ProcessInputA(ref List<string[]> sidesList)
        {
            var validTriangles = 0;
            foreach (var s in sidesList)
            {
                var cleanSides = s.Where(l => !string.IsNullOrEmpty(l)).Select(int.Parse).ToList();

                if (cleanSides[0] + cleanSides[1] > cleanSides[2] &&
                    cleanSides[1] + cleanSides[2] > cleanSides[0] &&
                    cleanSides[2] + cleanSides[0] > cleanSides[1])
                {
                    validTriangles++;
                }
            }

            Console.WriteLine("# of valid triangles = " + validTriangles);
        }

        public static void ProcessInputB(ref List<string[]> sidesList)
        {
            var validTriangles = 0;
            var splitSidesList = sidesList.ChunkBy(3);

            foreach (var splitSides in splitSidesList)
            {
                var s1 = splitSides[0].Where(l => !string.IsNullOrEmpty(l)).Select(int.Parse).ToList();
                var s2 = splitSides[1].Where(l => !string.IsNullOrEmpty(l)).Select(int.Parse).ToList();
                var s3 = splitSides[2].Where(l => !string.IsNullOrEmpty(l)).Select(int.Parse).ToList();

                if (s1[0] + s2[0] > s3[0] && s2[0] + s3[0] > s1[0] && s3[0] + s1[0] > s2[0])
                {
                    validTriangles++;
                }

                if (s1[1] + s2[1] > s3[1] && s2[1] + s3[1] > s1[1] && s3[1] + s1[1] > s2[1])
                {
                    validTriangles++;
                }

                if (s1[2] + s2[2] > s3[2] && s2[2] + s3[2] > s1[2] && s3[2] + s1[2] > s2[2])
                {
                    validTriangles++;
                }
            }

            Console.WriteLine("# of valid triangles = " + validTriangles);
        }
    }

    public static class ListExtensions
    {
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
