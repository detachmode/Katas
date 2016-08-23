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

            foreach (char c in chars)
            {
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


        private static IEnumerable<char> ConvertCharToRot13(IEnumerable<char> chars)
        {
            foreach (var c in chars)
            {
                int indexInAlphabet = c - 'A';
                int newIndex = (indexInAlphabet + 13) % 26;
                var newC = ((char)('A' + newIndex));
                yield return newC;
            }
        }


        private static IEnumerable<char> ToCharStream(string str)
        {
            var chars = str.ToArray();

            foreach (char c in chars)
            {
                yield return c;
            }
        }

    }
}
