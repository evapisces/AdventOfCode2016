using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var file = File.ReadAllLines("../../day12input.txt");
            var testfile = File.ReadAllLines("../../testinput.txt");

            //var instructions = new List<KeyValuePair<string, List<string>>>();
            var instructions = new Dictionary<int, Dictionary<string, List<string>>>();
            var index = 0;
            foreach (var line in file)
            {
                var split = line.Split(' ');
                var name = split[0];
                if (split.Length == 3)
                {
                    instructions.Add(index, new Dictionary<string, List<string>>());
                    instructions[index].Add(name, new List<string> {split[1], split[2]});
                }
                else
                {
                    instructions.Add(index, new Dictionary<string, List<string>>());
                    instructions[index].Add(name, new List<string> { split[1] });
                }

                index++;
            }

            ProcessInputA(file, ref instructions);

            Console.Read();
        }

        /// <summary>
        /// Instructions
        /// ============
        /// cpy x y => copies x (either an integer or the value of a register) into register y.
        /// inc x => increases the value of register x by one.
        /// dec x => decreases the value of register x by one.
        /// jnz x y => jumps to an instruction y away (positive means forward; negative means backward), but only if x is not zero.
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="instructions"></param>
        public static void ProcessInputA(string[] lines, ref Dictionary<int, Dictionary<string, List<string>>> instructions)
        {
            var registers = new Dictionary<string, int>();
            InitializeRegisters(lines, ref registers);

            var currInst = 0;

            while (currInst < instructions.Count-1)
            //for (var i = 0; i < instructions.Keys.Count; i++)
            {
                var instruction = instructions[currInst].First();

                // Copy
                // FORMAT: cpy src dest
                //              0   1
                if (instruction.Key == "cpy")
                {
                    //if (!registers.ContainsKey(instruction.Value[1]))
                    //{
                    if (!IsDigitsOnly(instruction.Value[0]))
                    {
                        registers[instruction.Value[1]] = registers[instruction.Value[0]];
                    }
                    else
                    {
                        registers[instruction.Value[1]] = int.Parse(instruction.Value.First());
                    }
                        
                    //}
                    //else
                    //{
                        //if (char.IsLetter(instruction.Value[0]))
                        //{
                        //    registers.Add(instruction.Value[1], registers[instruction.Value[0]]);
                        //}
                        //else
                        //{
                        //    //registers.Add(instruction.Value[1], int.Parse(instruction.Value[0]));
                        //}
                    //}

                    currInst++;
                }
                // Increment
                // FORMAT: inc x
                else if (instruction.Key == "inc")
                {
                    registers[instruction.Value[0]] += 1;

                    currInst++;
                }
                // Decrement
                // FORMAT: dec x
                else if (instruction.Key == "dec")
                {
                    registers[instruction.Value[0]] -= 1;

                    currInst++;
                }
                // Jump if not zero
                // FORMAT: jnz x y
                else if (instruction.Key == "jnz")
                {
                    if (IsDigitsOnly(instruction.Value[0]) && int.Parse(instruction.Value[1]) != 0)
                    {
                        currInst += int.Parse(instruction.Value[1]);
                    }
                    else if (!IsDigitsOnly(instruction.Value[0]) && registers[instruction.Value[0]] != 0 && currInst + int.Parse(instruction.Value[1]) < instructions.Count)
                    {
                        currInst += int.Parse(instruction.Value[1]);
                    }
                    else
                    {
                        currInst++;
                    }
                }
            }

//            Console.WriteLine("Register A = " + registers["a"]);
            /*foreach (var instruction in instructions)
            {
                // Copy
                // FORMAT: cpy x y
                if (instruction.Key == "cpy")
                {
                    if (!registers.ContainsKey(instruction.Value[1]))
                        registers.Add(instruction.Value[1], int.Parse(instruction.Value[0]));
                    else
                        registers[instruction.Value[1]] = int.Parse(instruction.Value[0]);
                }
                // Increment
                // FORMAT: inc x
                else if (instruction.Key == "inc")
                {
                    registers[instruction.Value[0]] += 1;
                }
                // Decrement
                // FORMAT: dec x
                else if (instruction.Key == "dec")
                {
                    registers[instruction.Value[0]] -= 1;
                }
                // Jump if not zero
                // FORMAT: jnz x y
                else if (instruction.Key == "jnz")
                {

                }
            }*/
        }

        public static void InitializeRegisters(string[] lines, ref Dictionary<string, int> registers)
        {
            foreach (var line in lines)
            {
                var split = line.Split(' ');

                if (split.Length == 2)
                {
                    if (char.IsLetter(split[1][0]))
                    {
                        if (!registers.ContainsKey(split[1]))
                            registers.Add(split[1], 0);
                    }

                }
                else if (split.Length == 3)
                {
                    if (char.IsLetter(split[1][0]))
                    {
                        if (!registers.ContainsKey(split[1]))
                            registers.Add(split[1], 0);
                    }

                    if (char.IsLetter(split[2][0]))
                    {
                        if (!registers.ContainsKey(split[2]))
                            registers.Add(split[2], 0);
                    }
                }

            }
        }

        private static bool IsDigitsOnly(string str)
        {
            foreach (var ch in str)
            {
                if (ch < '0' || ch > '9')
                    return false;
            }

            return true;
        }
    }
}
