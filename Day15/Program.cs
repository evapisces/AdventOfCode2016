using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileA = File.ReadAllLines("../../day15input.txt");
            var fileB = File.ReadAllLines("../../day15input_2.txt");
            var testfile = File.ReadAllLines("../../testinput.txt");
            var discsA = new List<Disc>();
            var discsB = new List<Disc>();

            InitializeDiscs(ref discsA, fileA);
            InitializeDiscs(ref discsB, fileB);

            ProcessInputA(discsA);

            ProcessInputB(discsB);

            Console.Read();
        }

        public static void ProcessInputA(List<Disc> discs)
        {
            var keepGoing = true;
            var t = 0;

            while (keepGoing)
            {
                foreach (var disc in discs)
                {
                    disc.NumberOfTicks = t + disc.Number;
                }

                if (AllDiscsAtZero(discs))
                {
                    keepGoing = false;
                }
                else
                {
                    t++;
                }
            }

            Console.WriteLine("Time = " + t + " seconds");
        }

        public static void ProcessInputB(List<Disc> discs)
        {
            var keepGoing = true;
            var t = 0;

            while (keepGoing)
            {
                foreach (var disc in discs)
                {
                    disc.NumberOfTicks = t + disc.Number;
                }

                if (AllDiscsAtZero(discs))
                {
                    keepGoing = false;
                }
                else
                {
                    t++;
                }
            }

            Console.WriteLine("Time = " + t + " seconds");
        }

        private static void InitializeDiscs(ref List<Disc> discs, string[] lines)
        {
            foreach (var line in lines)
            {
                var splits = line.Split(' ');
                var disc = new Disc
                {
                    Number = int.Parse(splits[1].Replace("#", "")),
                    NumberOfPositions = int.Parse(splits[3]),
                    StartingPosition = int.Parse(splits[11].Replace(".", "")),
                    NumberOfTicks = 0
                };
                discs.Add(disc);
            }
        }

        private static bool AllDiscsAtZero(List<Disc> discs)
        {
            var discsAtZero = discs.Count(d => (d.StartingPosition + d.NumberOfTicks) % d.NumberOfPositions == 0);

            return discsAtZero == discs.Count;
        }

        public class Disc
        {
            public int Number { get; set; }
            public int NumberOfPositions { get; set; }
            public int StartingPosition { get; set; }
            public int NumberOfTicks { get; set; }
        }
    }
}
