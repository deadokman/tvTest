using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CdsUpdateXmlParser;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace TESTS
{
    [TestFixture]
    public class CdsUpdateXmlParserTest
    {
        [Test]
        public void TestXmlMetaData()
        {
            var provider = new CdsUpdateXmlDataprovider("Updatestructure.xml");

        }
    }
}
