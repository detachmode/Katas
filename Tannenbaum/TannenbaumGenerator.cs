using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tannenbaum
{
    public static class TannenbaumGenerator
    {
        internal static List<string> lines;

        public static List<string> CreateTannenbaum(int size, bool star)
        {
            lines = new List<string>();
            built_lines(size, star);
            return lines;
        }


        internal static void built_lines(int size, bool star)
        {
            addStar(size, star);
            if(size > 10)
                onProcessLine += linenumber => BuildAndAddLine(size, linenumber);
            built_MiddlePart(size);
            built_trunk(size);
        }

        internal static void BuildAndAddLine(int size, int linenumber)
        {
            string line = "";
            line = AddSpaces(size, linenumber, line);
            line = AddXs(line, linenumber);
            lines.Add(line);
        }

        public static string AddXs(string line, int i)
        {
            var numberOfSpaces = CalculateNumberOfSpaces(i);
            line = addSameSymbolMultipleTimes(line, "X", numberOfSpaces);
            return line;
        }

        internal static int CalculateNumberOfSpaces(int i)
        {
            return (i*2) + 1;
        }

        internal static string AddSpaces(int size, int i, string line)
        {
            int spacecount = size - i;
            line = addSameSymbolMultipleTimes(line, " ", spacecount);
            return line;
        }

        internal static void addStar(int size, bool star)
        {
            string line = "";
            int spacecount = size;
            line = addSameSymbolMultipleTimes(line, " ", spacecount);
            line += "*";

            if (star)
                lines.Add(line);
        }

        //internal static void built_MiddlePart(int size)
        //{
        //    for (int i = 0; linenumber < size; linenumber++)
        //    {
        //        string line = "";
        //        int spacecount = size - i;
        //        line = addSameSymbolMultipleTimes(line, " ", spacecount);

        //        line = addSameSymbolMultipleTimes(line, "X", (i * 2) + 1);

        //        lines.Add(line);
        //    }
        //}

        internal static void built_MiddlePart(int size)
        {
            for (int i = 0; i < size; i++)
            {
                onProcessLine?.Invoke(i);
            }
        }

        public static  event Action<int> onProcessLine;


        internal static void built_trunk(int size)
        {
            string line = "";
            line = addSameSymbolMultipleTimes(line, " ", size);
            line += "I";
            lines.Add(line);
        }



        internal static string addSameSymbolMultipleTimes(string input, string s, int count)
        {
            for (int i = 0; i < count; i++)
            {
                input += s;
            }
            return input;
        }

    }
}
