using Social.Domain.Commands.UserCommands.Commands;
using Social.Domain.Commands.UserCommands.Results;
using Social.Domain.Entities;
using Social.Domain.Repositories;
using Social.Domain.ValueObjects;

namespace Social.Domain.Commands.UserCommands.Handlers
{
    public class UserHandler
    {
        public readonly IUserRepository _rep;

        public UserHandler(IUserRepository rep)
        {
            _rep = rep;
        }

        public async Task<UserResult> Create(CreateUserCommand command)
        {
            var name = new Name(command.Firstname, command.Lastname);
            var email = new Email(command.EmailAddress);
            var document = new Document(command.Document);
            var password = new Password(command.Password);
            var user = new User(name, email, document, password);

            if (user.Invalid)
                return new UserResult("Usuário não cadastrado", 400, user.Notifications);

            if (await _rep.EmailExists(user.Email.Address))
                return new UserResult("O email já está em uso", 400);

            await _rep.Save(user);

            return new UserResult(
                "Usuário cadastrado com sucesso",
                201,
                new UserDataResult(
                    user.Id.ToString(),
                    user.Name.ToString())
                );
        }
    }
}
