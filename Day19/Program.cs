using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    public class Program
    {
        public static void Main(string[] args)
        {
            long input = 3004953;
            long testInput = 5;

            var elves = new List<Elf>();

            for (var i = 1; i <= input; i++)
            {
                elves.Add(new Elf {
                    Number = i,
                    NumberOfPresents = 1
                });
            }

            ProcessInputA(ref elves);

            Console.Read();
        }

        public static void ProcessInputA(ref List<Elf> elves)
        {
            var cont = true;

            while (cont)
            {
                for (var i = 0; i < elves.Count; i++)
                {
                    if (elves[i].NumberOfPresents > 0)
                    {
                        if (i == elves.Count-1)
                        {
                            elves[i].NumberOfPresents += elves[0].NumberOfPresents;
                            elves[0].NumberOfPresents = 0;
                        }
                        else
                        {
                            elves[i].NumberOfPresents += elves[i + 1].NumberOfPresents;
                            elves[i + 1].NumberOfPresents = 0;
                        }

                    }
                }

                elves.RemoveAll(e => e.NumberOfPresents == 0);

                cont = elves.FirstOrDefault(e => e.NumberOfPresents == 3004953) == null;    // no elves have all gifts
            }

            Console.WriteLine("Elf #" + elves.First().Number + " has all the presents!!");

        }

        public class Elf
        {
            public int Number { get; set; }
            public int NumberOfPresents { get; set; }
        }
    }
}
