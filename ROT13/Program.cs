using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ROT13
{
    class Program
    {


        static void Main(string[] args)
        {
            string rot13 = ConvertToRot13("ÖÖÖÖHEßLLO");

        }

        private static string ConvertToRot13(string str)
        {
            var chars = ToCharStream(str.ToUpper());
            var filteredChars = ConvertSpecialChars(chars);
            var rot13Chars = ConvertCharToRot13(filteredChars).ToList();
            return string.Concat(rot13Chars);

        }


        private static IEnumerable<char> ConvertSpecialChars(IEnumerable<char> chars)
        {
            //return chars.Where(x => x == 'ß').Concat("ss".ToCharArray());

            Dictionary<char, string> d = new Dictionary<char, string>
            {
                {'ß', "SS"},
                {'Ö', "OE"}
            };

            foreach (char c in chars)
            {
                //string value;

                //if (d.TryGetValue(c, out value))
                //{
                //    foreach (var VARIABLE in COLLECTION)
                //    {
                        
                //    }
                //}
                //else
                //{
                //    yield return c;
                //}
                
                switch (c)
                {
                    case 'ß':
                        yield return 'S';
                        yield return 'S';
                        break;
                    case 'Ö':
                        yield return 'O';
                        yield return 'E';
                        break;
                    default:
                        yield return c;
                        break;
                }

            }
        }


        private static IEnumerable<char> ConvertCharToRot13(List<char> chars)
        {
            return chars.Select(c => OffestChar(c));
        }

        private static char OffestChar(char c)
        {
            int indexInAlphabet = c - 'A';
            int newIndex = (indexInAlphabet + 13) % 26;
            var newC = ((char)('A' + newIndex));
            return newC;
        }

        private static IEnumerable<char> ToCharStream(string str)
        {
            return str.ToArray();

        }

    }
}
