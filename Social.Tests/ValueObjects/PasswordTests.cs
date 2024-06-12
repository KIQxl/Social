using Microsoft.VisualStudio.TestTools.UnitTesting;
using Social.Domain.ValueObjects;

namespace Social.Tests.ValueObjects
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void GivenValidPasswordReturnTrue()
        {
            var password = new Password("12345678");

            Assert.IsTrue(password.PasswordHash != "12345678" && !string.IsNullOrEmpty(password.PasswordSalt));
        }

        [TestMethod]
        public void GivenInvalidPasswordReturnTrue()
        {
            var password = new Password("12345");

            Assert.IsTrue(password.Invalid);
        }

        [TestMethod]
        public void GenerateRandomPassword()
        {
            var newPassword = Password.GenerateRandomPassword();
            Assert.IsTrue(!string.IsNullOrEmpty(newPassword));
        }

        [TestMethod]
        [DataRow("12345985", false)]
        [DataRow("12345678", true)]
        [DataRow("12345bsdfb", false)]
        public void WhenSuccessChallangeReturnTrue(string reques, bool expected)
        {
            var password = new Password("12345678");

            var result = password.Challenge(reques);

            if (expected)
            {
                Assert.IsTrue(result);
            }
            else
            {
                Assert.IsFalse(result);
            }
        }
    }
}
