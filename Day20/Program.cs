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
            //var allIps = new List<long>();

            var lines = file.Select(l => new IpRange(l)).OrderBy(l => l.Low).ToList();
            
            ProcessInputA(lines);

            Console.Read();
        }

        public static void ProcessInputA(List<IpRange> ipRanges)
        {
            var currLow = ipRanges[0].Low;
            var currHigh = ipRanges[0].High;
            foreach (var ipRange in ipRanges)
            {


                //for (BigInteger n = min; n <= max; n++)
                //{
                //    if (ips.Contains(n))
                //    {
                //        var ip = ips.FirstOrDefault(i => i == n);
                //        ips.Remove(ip);
                //    }
                //}

                //ips.RemoveRange(min, (max-min));
            }

            //Console.WriteLine("Remaining IPs");
            /*foreach (BigInteger ip in ips)
            {
                Console.WriteLine(ip);
            }*/

            //Console.WriteLine("Min IP = " + ips.First());
        }

        public class IpRange
        {
            public long Low { get; set; }
            public long High { get; set; }

            public IpRange(string line)
            {
                var split = line.Split('-');
                Low = long.Parse(split[0].Trim());
                High = long.Parse(split[1].Trim());
            }
        }
    }
}
