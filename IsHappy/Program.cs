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
            var othernumbers = CreateOtherNumbers(numbersToCheck);
            return CheckForHappyness(othernumbers);
        }

        private static IEnumerable<int> CreateOtherNumbers(IEnumerable<int> numbersToCheck)
        {
            yield return 555;
            foreach (var i in numbersToCheck)
            {
                yield return i + 1;
            }
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

                //if(number>9999) 
            }
        }
    }



    public static class HappyNumbers
    {

        public static event Action<bool> OnResultFound;
        public static event Action<int> OnCheckNumber;

        public static void CheckNumber(int number)
        {
            //OnCheckNumber += CheckIsHappyUnhappy;
            //OnCheckNumber(number);
        }




        public static bool CheckIsHappyUnhappy(int number)
        {
          
           return IF_Is_HappyUnhappy(number, CreateNextNumber).HasValue;

        }

        private static void CreateNextNumber(int number)
        {
            Debug.WriteLine(number.ToString());
            IEnumerable<int> digits = SplitDigits(number).ToList();
            digits = digits.Select(x => (int)Math.Pow(x, 2));
            int sum = digits.Sum();

            OnCheckNumber(sum);
        }

        private static bool? IF_Is_HappyUnhappy(int number, Action<int> checkNumber)
        {
            switch (number)
            {
                case 1:
                    return true;
                case 4:
                    return false;
                default:
                    checkNumber(number);
                    return null;
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
