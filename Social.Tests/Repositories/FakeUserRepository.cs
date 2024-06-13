using Social.Domain.Commands.UserCommands.Results;
using Social.Domain.Entities;
using Social.Domain.Repositories;

namespace Social.Tests.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public async Task<bool> EmailExists(string email)
        {
            if (email == "kaique@email.com")
                return true;

            return false;
        }

        public Task Save(User user)
        {
            return Task.CompletedTask;
        }
    }
}
