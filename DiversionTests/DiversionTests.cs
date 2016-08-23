using Microsoft.VisualStudio.TestTools.UnitTesting;
using Diversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diversion.Tests
{
    [TestClass()]
    public class DiversionTests
    {
        [TestMethod()]
        public void append_0_recursionTest()
        {
            //var div = new Diversion();
            //div.append_0_recursion("", 1);
            //Assert.AreEqual(1, div.permutations.Count);

        }

        [TestMethod()]
        public void buildAllPossiblePermutationsTest()
        {
            var div = new Diversion(2);
            div.createPermutations();

            Assert.AreEqual(4, div.permutations.Count);
            Assert.AreEqual(true, div.permutations.Find(x => x == "00") != null);
            Assert.AreEqual(true, div.permutations.Find(x => x == "01") != null);
            Assert.AreEqual(true, div.permutations.Find(x => x == "11") != null);

            div = new Diversion(4);
            div.createPermutations();
            Assert.AreEqual(true, div.permutations.Find(x => x == "0001") != null);

        }

        [TestMethod()]
        public void appendBitRecursiveAndFinallyAddToPermutationsTest()
        {
            //var div = new Diversion();
            //div.appendBit("","1",3);

            //Assert.AreEqual("11", div.permutations[1]);

        }

        [TestMethod()]
        public void CreatePermutationIterativeTest()
        {
            var div = new Diversion(10);
            var result =  div.CreatePermutationsBinary(7);
            Assert.Fail();
        }
    }
}