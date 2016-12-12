using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    public class Program
    {
        static Dictionary<int, List<int>> botBelongings = new Dictionary<int, List<int>>();
        public static void Main(string[] args)
        {
            var testfile = File.ReadAllLines("../../testinput.txt");

            var file = File.ReadAllLines("../../day10input.txt");

            ProcessInputA(file);

            Console.Read();
        }

        public static void ProcessInputA(string[] testfile)
        {
            var botGiveaways = new List<BotGiveaways>();
            var outputs = new Dictionary<int, int>();

            foreach(var line in testfile)
            {
                var splits = line.Split(' ');
                if (line.StartsWith("bot"))
                {
                    var botGiveaway = new BotGiveaways
                    {
                        Id = int.Parse(splits[1]),
                        Low = int.Parse(splits[6]),
                        LowType = splits[5] == "bot" ? 'B' : 'O',
                        High = int.Parse(splits[11]),
                        HighType = splits[10] == "bot" ? 'B' : 'O'
                    };
                    botGiveaways.Add(botGiveaway);
                }
                else if (line.StartsWith("value"))
                {
                    if (!botBelongings.ContainsKey(int.Parse(splits[5])))
                    {
                        botBelongings.Add(int.Parse(splits[5]), new List<int> { int.Parse(splits[1])});
                    } else
                    {
                        botBelongings[int.Parse(splits[5])].Add(int.Parse(splits[1]));
                    }
                }
            }

            // Part A solution
            // Find the bot that has chips 17 and 61 in it
            while (botBelongings.Any(b => b.Value.Count == 2))
            {
                var ctTwo = botBelongings.Where(b => b.Value.Count == 2).FirstOrDefault();

                if (ctTwo.Value.Min() == 17 && ctTwo.Value.Max() == 61)
                    Console.WriteLine("B# " + ctTwo.Key + ",  Values = {" + ctTwo.Value.Min() + ", " + ctTwo.Value.Max() + "}");

                var bot = botGiveaways.Where(bg => bg.Id == ctTwo.Key).FirstOrDefault();

                // Transfers to another bot
                if (bot.LowType == 'B')
                {
                    if (!botBelongings.ContainsKey(bot.Low))
                        botBelongings.Add(bot.Low, new List<int>());
                    botBelongings[bot.Low].Add(ctTwo.Value.Min());
                }
                // Transfers to an output register
                else if (bot.LowType == 'O')
                {
                    outputs.Add(bot.Low, ctTwo.Value.Min());
                }
                botBelongings[ctTwo.Key].Remove(ctTwo.Value.Min());

                if (bot.HighType == 'B')
                {
                    if (!botBelongings.ContainsKey(bot.High))
                        botBelongings.Add(bot.High, new List<int>());
                    botBelongings[bot.High].Add(ctTwo.Value.Max());
                }
                else if (bot.HighType == 'O')
                {
                    outputs.Add(bot.High, ctTwo.Value.Max());
                }
                botBelongings[ctTwo.Key].Remove(ctTwo.Value.Max());
            }


            // Part B solution
            // Find product of chips in outputs 0, 1, and 2
            var value = outputs[0] * outputs[1] * outputs[2];

            Console.WriteLine("Value = " + value);
            
        }

        public class BotGiveaways
        {
            public int Id { get; set; }
            public int Low { get; set; }
            public char LowType { get; set; }
            public int High { get; set; }
            public char HighType { get; set; }
        }
    }
}
