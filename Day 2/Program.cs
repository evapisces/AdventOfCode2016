using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_2
{
    /// <summary>
    /// Day 2: Bathroom Security
    /// </summary>
    public class Program
    {
        /* Keypad button locations
         * 
         *      |1| |2| |3|
         *      |4| |5| |6|
         *      |7| |8| |9|
         */

        public static void Main(string[] args)
        {
            string line;
            var ctr = 0;
            var file = new StreamReader("../../day2input.txt");
            var keypadLines = new List<string>();

            while ((line = file.ReadLine()) != null)
            {
                keypadLines.Add(line);
                ctr++;
            }
            Console.WriteLine("# of digits = " + ctr);

            ProcessInputA(ref keypadLines);

            ProcessInputB(ref keypadLines);
            Console.Read();
        }

        public static void ProcessInputA(ref List<string> lines)
        {
            var currentButton = 5;
            Console.Write("Bathroom code = ");
            foreach(var line in lines)
            {
                foreach (var ch in line)
                {
                    switch (ch)
                    {
                        case 'U':
                            switch (currentButton)
                            {
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    currentButton = 1;
                                    break;
                                case 5:
                                    currentButton = 2;
                                    break;
                                case 6:
                                    currentButton = 3;
                                    break;
                                case 7:
                                    currentButton = 4;
                                    break;
                                case 8:
                                    currentButton = 5;
                                    break;
                                case 9:
                                    currentButton = 6;
                                    break;
                            }
                            break;
                        case 'D':
                            switch (currentButton)
                            {
                                case 1:
                                    currentButton = 4;
                                    break;
                                case 2:
                                    currentButton = 5;
                                    break;
                                case 3:
                                    currentButton = 6;
                                    break;
                                case 4:
                                    currentButton = 7;
                                    break;
                                case 5:
                                    currentButton = 8;
                                    break;
                                case 6:
                                    currentButton = 9;
                                    break;
                                case 7:
                                    break;
                                case 8:
                                    break;
                                case 9:
                                    break;
                            }
                            break;
                        case 'L':
                            switch (currentButton)
                            {
                                case 1:
                                    break;
                                case 2:
                                    currentButton = 1;
                                    break;
                                case 3:
                                    currentButton = 2;
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    currentButton = 4;
                                    break;
                                case 6:
                                    currentButton = 5;
                                    break;
                                case 7:
                                    break;
                                case 8:
                                    currentButton = 7;
                                    break;
                                case 9:
                                    currentButton = 8;
                                    break;
                            }
                            break;
                        case 'R':
                            switch (currentButton)
                            {
                                case 1:
                                    currentButton = 2;
                                    break;
                                case 2:
                                    currentButton = 3;
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    currentButton = 5;
                                    break;
                                case 5:
                                    currentButton = 6;
                                    break;
                                case 6:
                                    break;
                                case 7:
                                    currentButton = 8;
                                    break;
                                case 8:
                                    currentButton = 9;
                                    break;
                                case 9:
                                    break;
                            }
                            break;
                    }
                }
                Console.Write(currentButton);
            }
        }

        public static void ProcessInputB(ref List<string> lines)
        {
            var currentButton = '5';
            Console.Write("Bathroom code = ");
            foreach (var line in lines)
            {
                foreach (var ch in line)
                {
                    switch (ch)
                    {
                        case 'U':
                            switch (currentButton)
                            {
                                case '1':
                                    break;
                                case '2':
                                    break;
                                case '3':
                                    currentButton = '1';
                                    break;
                                case '4':
                                    break;
                                case '5':
                                    break;
                                case '6':
                                    currentButton = '2';
                                    break;
                                case '7':
                                    currentButton = '3';
                                    break;
                                case '8':
                                    currentButton = '4';
                                    break;
                                case '9':
                                    break;
                                case 'A':
                                    currentButton = '6';
                                    break;
                                case 'B':
                                    currentButton = '7';
                                    break;
                                case 'C':
                                    currentButton = '8';
                                    break;
                                case 'D':
                                    currentButton = 'B';
                                    break;
                            }
                            break;
                        case 'D':
                            switch (currentButton)
                            {
                                case '1':
                                    currentButton = '3';
                                    break;
                                case '2':
                                    currentButton = '6';
                                    break;
                                case '3':
                                    currentButton = '7';
                                    break;
                                case '4':
                                    currentButton = '8';
                                    break;
                                case '5':
                                    break;
                                case '6':
                                    currentButton = 'A';
                                    break;
                                case '7':
                                    currentButton = 'B';
                                    break;
                                case '8':
                                    currentButton = 'C';
                                    break;
                                case '9':
                                    break;
                                case 'A':
                                    break;
                                case 'B':
                                    currentButton = 'D';
                                    break;
                                case 'C':
                                    break;
                                case 'D':
                                    break;
                            }
                            break;
                        case 'L':
                            switch (currentButton)
                            {
                                case '1':
                                    break;
                                case '2':
                                    break;
                                case '3':
                                    currentButton = '2';
                                    break;
                                case '4':
                                    currentButton = '3';
                                    break;
                                case '5':
                                    break;
                                case '6':
                                    currentButton = '5';
                                    break;
                                case '7':
                                    currentButton = '6';
                                    break;
                                case '8':
                                    currentButton = '7';
                                    break;
                                case '9':
                                    currentButton = '8';
                                    break;
                                case 'A':
                                    break;
                                case 'B':
                                    currentButton = 'A';
                                    break;
                                case 'C':
                                    currentButton = 'B';
                                    break;
                                case 'D':
                                    break;
                            }
                            break;
                        case 'R':
                            switch (currentButton)
                            {
                                case '1':
                                    break;
                                case '2':
                                    currentButton = '3';
                                    break;
                                case '3':
                                    currentButton = '4';
                                    break;
                                case '4':
                                    break;
                                case '5':
                                    currentButton = '6';
                                    break;
                                case '6':
                                    currentButton = '7';
                                    break;
                                case '7':
                                    currentButton = '8';
                                    break;
                                case '8':
                                    currentButton = '9';
                                    break;
                                case '9':
                                    break;
                                case 'A':
                                    currentButton = 'B';
                                    break;
                                case 'B':
                                    currentButton = 'C';
                                    break;
                                case 'C':
                                    break;
                                case 'D':
                                    break;
                            }
                            break;
                    }
                }
                Console.Write(currentButton);
            }
        }
    }
}
