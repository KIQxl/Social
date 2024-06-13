using Microsoft.VisualStudio.TestTools.UnitTesting;
using Social.Domain.Commands.UserCommands.Commands;
using Social.Domain.Commands.UserCommands.Handlers;
using Social.Tests.Repositories;

namespace Social.Tests.Handlers
{
    [TestClass]
    public class UserHandlerTests
    {
        public CreateUserCommand _validCommand = new CreateUserCommand("kaique", "alves", "kaique@email.com.br", "12345678", "12345678910");
        public CreateUserCommand _InvalidCommand = new CreateUserCommand("ue", "as", "kaiqueemcom.br", "12345", "123456789");
        public FakeUserRepository _repository = new FakeUserRepository();


        [TestMethod]
        public async void SuccessWhenCreateUser()
        {
            var _handler = new UserHandler(_repository);

            var result = await _handler.Create(_validCommand);

            Assert.AreEqual(result.Status, 201);
        }

        [TestMethod]
        public async void FailWhenCreateUser()
        {
            var _handler = new UserHandler(_repository);

            var result = await _handler.Create(_InvalidCommand);

            Assert.AreEqual(result.Message, "Usuário não cadastrado");
        }

        [TestMethod]
        public async void FailWhenEmailExists()
        {
            _validCommand.EmailAddress = "kaique@email.com";
            var _handler = new UserHandler(_repository);

            var result = await _handler.Create(_validCommand);

            Assert.AreEqual(result.Message, "O email já está em uso");
        }
    }
}
