using Flunt.Notifications;

namespace Social.Shared.Entities
{
    public class EntityBase : Notifiable
    {
        public Guid Id { get; set; }

        public EntityBase()
        {
            Id = Guid.NewGuid();
        }
    }
}
