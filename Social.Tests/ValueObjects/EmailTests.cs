using Microsoft.VisualStudio.TestTools.UnitTesting;
using Social.Domain.ValueObjects;

namespace Social.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [DataRow("", false)]
        [DataRow("kaique", false)]
        [DataRow("kaique@email.com", true)]
        public void GivenEmailAddresCheckIfItIsValidOrNot(string address, bool expected)
        {
            var email = new Email(address);

            if(expected)
            {
                Assert.IsTrue(email.Valid);
            }
            else
            {
                Assert.IsFalse(email.Valid);
            }
        }
    }
}
