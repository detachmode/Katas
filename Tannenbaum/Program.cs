using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tannenbaum
{
    class TestTannenBaumCreator
    {
        
    }



    class Program
    {
        private static void print_lines(List<string> lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }


        static void Main(string[] args)
        {
            var lines = TannenbaumGenerator.CreateTannenbaum(10, true);
            print_lines(lines);


        }
    }
}
