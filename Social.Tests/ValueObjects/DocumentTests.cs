using Microsoft.VisualStudio.TestTools.UnitTesting;
using Social.Domain.ValueObjects;

namespace Social.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [DataRow("", false)]
        [DataRow("123456789", false)]
        [DataRow("12345678910", true)]
        public void GivenDocumentNumberCheckIfItIsValidOrNot(string documentNumber, bool expected)
        {
            var document = new Document(documentNumber);

            if (expected)
            {
                Assert.IsTrue(document.Valid);
            }
            else
            {
                Assert.IsFalse(document.Valid);
            }
        }
    }
}
