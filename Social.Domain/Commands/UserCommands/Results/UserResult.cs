using Flunt.Notifications;
using Social.Shared.Commands;

namespace Social.Domain.Commands.UserCommands.Results
{
    public class UserResult : Result
    {
        public UserDataResult? Data { get; set; }

        public UserResult(string message, int status = 400, IEnumerable<Notification> notifications = null)
        {
            Message = message;
            Status = status;

            if (notifications != null)
            {
                foreach (var notification in notifications)
                {
                    Errors.Add(notification.Message);
                }
            }

            Data = null;
        }

        public UserResult(string message, int status, UserDataResult data)
        {
            Message = message;
            Status = status;
            Data = data;
            Errors = null;
        }
    }

    public record UserDataResult(string Id, string Name);
}
