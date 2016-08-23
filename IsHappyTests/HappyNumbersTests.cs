using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsHappy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHappy.Tests
{
    [TestClass()]
    public class HappyNumbersTests
    {
        [TestMethod()]
        public void splitDigitsTest()
        {
            var res = HappyNumbers.SplitDigits(453).ToList();


        }

        [TestMethod()]
        public void CheckIsHappyUnhappyTest()
        {
            HappyNumbers.OnResultFound += x => Debug.WriteLine(x.ToString());
            HappyNumbers.CheckNumber(239);
           


        }
    }
}