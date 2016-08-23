using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tannenbaum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tannenbaum.Tests
{
    [TestClass()]
    public class TannenbaumGeneratorTests
    {
        [TestMethod()]
        public void CreateTannenbaumTest()
        {
            var lines = TannenbaumGenerator.CreateTannenbaum(1, true);
            Assert.AreEqual(" *", lines[0]);
            Assert.AreEqual(" X", lines[1]);
            Assert.AreEqual(" I", lines[2]);
            
        }

        [TestMethod]
        public void AddXsTest()
        {
            Assert.AreEqual("XXXXXXX", TannenbaumGenerator.AddXs("", 3));
        }
    }
}