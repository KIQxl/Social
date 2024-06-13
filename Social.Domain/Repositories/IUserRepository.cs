using Social.Domain.Commands.UserCommands.Results;
using Social.Domain.Entities;

namespace Social.Domain.Repositories
{
    public interface IUserRepository
    {
        public Task Save(User user);
        public Task<bool> EmailExists(string email);
    }
}
