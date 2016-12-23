using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day20
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var maxIpValue = BigInteger.Parse(ConfigurationManager.AppSettings["MaxIpValue"]);

            var file = File.ReadAllLines("../../day20input.txt");
            var allIps = new List<BigInteger>();

            for (BigInteger i = 0; i <= maxIpValue; i++)
            {
                allIps.Add(i);
            }
            
            ProcessInputA(allIps, file);

            Console.Read();
        }

        public static void ProcessInputA(List<BigInteger> ips, string[] lines)
        {
            foreach (var line in lines)
            {
                var split = line.Split('-');
                var min = BigInteger.Parse(split[0]);
                var max = BigInteger.Parse(split[1]);

                for (BigInteger n = min; n <= max; n++)
                {
                    if (ips.Contains(n))
                    {
                        var ip = ips.FirstOrDefault(i => i == n);
                        ips.Remove(ip);
                    }
                }

                //ips.RemoveRange(min, (max-min));
            }

            Console.WriteLine("Remaining IPs");
            foreach (BigInteger ip in ips)
            {
                Console.WriteLine(ip);
            }

            Console.WriteLine("Min IP = " + ips.First());
        }
    }
}
