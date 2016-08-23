using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace IsHappy
{

    public static class HappyNumbers2
    {
        public static bool IsNumberHappy(int number)
        {
            var numbersToCheck = CreateNumbers(number);
            return CheckForHappyness(numbersToCheck);
        }

        private static bool CheckForHappyness(IEnumerable<int> numbersToCheck)
        {
            foreach (var number in numbersToCheck)
            {
                if (number == 1) return true;
                if (number == 4) break;
            }
            return false;
        }

        private static IEnumerable<int> CreateNumbers(int number)
        {
            while (true)
            {
                yield return number;
                var digitischars = number.ToString().ToCharArray();
                var digitsInts = digitischars.Select(x => x - '0');
                number = digitsInts.Sum(x => x * x);
            }
        }
    }



    public static class HappyNumbers
    {

        public static event Action<bool> OnResultFound;
        public static event Action<int> OnCheckNumber;

        public static void CheckNumber(int number)
        {
            OnCheckNumber += CheckIsHappyUnhappy;
            OnCheckNumber(number);
        }




        public static void CheckIsHappyUnhappy(int number)
        {
            IF_Is_HappyUnhappy(number,
                CreateNextNumber);
        }

        private static void CreateNextNumber(int number)
        {
            Debug.WriteLine(number.ToString());
            IEnumerable<int> digits = SplitDigits(number).ToList();
            digits = digits.Select(x => (int)Math.Pow(x, 2));
            int sum = digits.Sum();

            OnCheckNumber(sum);
        }

        private static void IF_Is_HappyUnhappy(int number, Action<int> checkNumber)
        {
            switch (number)
            {
                case 1:
                    OnResultFound(true);
                    return;
                case 4:
                    OnResultFound(false);
                    return;
                default:
                    checkNumber(number);
                    return;
            }
        }


        public static IEnumerable<int> SplitDigits(int number)
        {
            var chars = number.ToString().ToCharArray();
            foreach (var c in chars)
            {
                yield return int.Parse(c.ToString());
            }
        }

    }













    class Program
    {
        static void Main(string[] args)
        {


        }
    }
}
