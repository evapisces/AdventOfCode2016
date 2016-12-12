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


        }

        public static void ProcessInputA(string[] lines)
        {
            var registers = new Dictionary<char, int>();
            foreach (var line in lines)
            {
                if (line.StartsWith("cpy"))
                {

                }
                else if (line.StartsWith("inc"))
                {

                }
                else if (line.StartsWith("dec"))
                {

                }
                else if (line.StartsWith("jnz"))
                {

                }
            }
        }
    }
}
