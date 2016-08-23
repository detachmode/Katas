using Microsoft.VisualStudio.TestTools.UnitTesting;
using IsHappy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsHappy.Tests
{
    [TestClass()]
    public class HappyNumbers2Tests
    {
        [TestMethod()]
        public void IsNumberHappyTest()
        {
            HappyNumbers2.IsNumberHappy(123);
        }
    }
}