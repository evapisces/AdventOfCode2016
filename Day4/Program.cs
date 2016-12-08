using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day4
{
    /// <summary>
    /// Day 4: Security Through Obscurity
    /// </summary>
    public class Program
    {
        public class LetterInfo
        {
            public char Letter { get; set; }
            public int Count { get; set; }
        }

        public static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../../day4input.txt").ToList();
            
            var sum = 0;
            var actualRooms = new Dictionary<string, int>();
            var decryptedNames = new Dictionary<string, int>();

            #region Part 1 Section
            foreach (var line in lines)
            {
                var counts = new Dictionary<string, int>();
                var encryptedName = line.Substring(0, line.LastIndexOf('-'));
                var sectorId = line.Substring(line.LastIndexOf('-') + 1, line.IndexOf('[') - line.LastIndexOf('-') - 1);
                var checksum = line.Substring(line.IndexOf('[') + 1, line.IndexOf(']') - line.IndexOf('[') - 1);

                var splitName = encryptedName.Split('-').ToList();
                var chars = new string(encryptedName.Distinct().ToArray()).Replace("-", "");

                foreach (var letter in "abcdefghijklmnopqrstuvwxyz")
                {
                    counts.Add(letter.ToString(),
                        encryptedName.Count(x => x == letter)
                    );
                }

                var actualCheckSum = "";

                for (var i = encryptedName.Length; i >= 0; --i)
                {
                    var matches = counts.Where(m => m.Value == i).Select(m => m.Key);
                    actualCheckSum += string.Join("", matches.OrderBy(cs => cs));
                }

                // get the 5 digit checksum from letters in room name
                actualCheckSum = actualCheckSum.Substring(0, 5);

                if (actualCheckSum == checksum)
                {
                    sum += int.Parse(sectorId);
                    actualRooms.Add(encryptedName, int.Parse(sectorId));
                }
            }

            Console.WriteLine("Sum of Sector IDs of Valid Rooms = " + sum);
            #endregion

            #region Part 2 Section
            foreach (var actualRoom in actualRooms)
            {
                decryptedNames.Add(Decrypt(actualRoom.Key, actualRoom.Value), actualRoom.Value);
            }

            var selectedRoom = decryptedNames.Where(d => d.Key.Contains("north")).First();
            Console.WriteLine("Room Name = " + selectedRoom.Key + ", SectorId = " + selectedRoom.Value);
            #endregion

            Console.Read();
        }

        public static string Decrypt(string encryptedName, int sectorId)
        {
            var decryptedName = "";
            foreach(var ch in encryptedName)
            {
                var newCh = ch;
                for (var i = 0; i < sectorId; i++)
                {
                    if (newCh == 'z')
                    {
                        newCh = 'a';
                    } else if (newCh == '-')
                    {
                        newCh = ' ';
                    } else if (newCh == ' ') {
                        break;
                    }
                    else
                    {
                        newCh++;
                    }
                }

                decryptedName += newCh;
            }

            return decryptedName;
        }
    }
}
