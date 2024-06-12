using Microsoft.VisualStudio.TestTools.UnitTesting;
using Social.Domain.ValueObjects;

namespace Social.Tests.ValueObjects
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        [DataRow("", "")]
        [DataRow("Kaique", "")]
        [DataRow("", "Alves")]
        [DataRow("Kaique", "")]
        [DataRow("Jo", "Ab")]
        public void GivenInvalidNameReturnTrue(string firstname, string lastname)
        {
            var name = new Name(firstname, lastname);

            Assert.IsTrue(name.Invalid);
        }

        [TestMethod]
        [DataRow("Kaique", "Alves")]
        [DataRow("Ana", "Ana")]
        [DataRow("abc", "abc")]
        public void GivenValidNameReturnTrue(string firstname, string lastname)
        {
            var name = new Name(firstname, lastname);

            Assert.IsTrue(name.Valid);
        }
    }
}
