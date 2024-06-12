using Social.Shared.Commands;

namespace Social.Domain.Commands.UserCommands.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Document { get; set; }
    }
}
