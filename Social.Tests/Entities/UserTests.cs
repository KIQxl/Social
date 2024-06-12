using Microsoft.VisualStudio.TestTools.UnitTesting;
using Social.Domain.Entities;
using Social.Domain.ValueObjects;

namespace Social.Tests.Entities
{
    [TestClass]
    public class UserTests
    {
        private readonly Document _document = new Document("12345678910");
        private readonly Name _name = new Name("Kaique", "Alves");
        private readonly Password _password = new Password("12345678");
        private readonly Email _email = new Email("kaique_rba@yahoo.com.br");

        [TestMethod]
        [DataRow("Kaique", "Alves", true)]
        [DataRow("ana", "Alves", true)]
        [DataRow("", "Alves", false)]
        [DataRow("Alves", "", false)]
        public void GivenNewNameTest(string firstname, string lastname, bool expected)
        {
            var user = new User(_name, _email, _document, _password);
            var newName = new Name(firstname, lastname);
            user.ChangeName(newName);

            if (expected)
            {
                Assert.IsTrue(user.Valid);
            }
            else
            {
                Assert.IsFalse(user.Valid);
            }
        }

        [TestMethod]
        [DataRow("123456789", false)]
        [DataRow("12345678910", true)]
        public void GivenNewDocumentTest(string document, bool expected)
        {
            var user = new User(_name, _email, _document, _password);
            var newDocument = new Document(document);
            user.ChangeDocument(newDocument);

            if (expected)
            {
                Assert.IsTrue(user.Valid);
            }
            else
            {
                Assert.IsFalse(user.Valid);
            }
        }

        [TestMethod]
        [DataRow("12345", false)]
        [DataRow("12345678910", true)]
        public void GivenNewPasswordTest(string password, bool expected)
        {
            var user = new User(_name, _email, _document, _password);
            var newPassword = new Password(password);
            user.ChangePassword(newPassword);

            if (expected)
            {
                Assert.IsTrue(user.Valid);
            }
            else
            {
                Assert.IsFalse(user.Valid);
            }
        }

        [TestMethod]
        [DataRow("kaique", false)]
        [DataRow("", false)]
        [DataRow("kaique@email.com", true)]
        public void GivenNewEmailTest(string email, bool expected)
        {
            var user = new User(_name, _email, _document, _password);
            var newEmail = new Email(email);
            user.ChangeEmail(newEmail);

            if (expected)
            {
                Assert.IsTrue(user.Valid);
            }
            else
            {
                Assert.IsFalse(user.Valid);
            }
        }
    }
}
