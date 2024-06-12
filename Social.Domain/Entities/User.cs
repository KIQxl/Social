using Social.Domain.ValueObjects;
using Social.Shared.Entities;

namespace Social.Domain.Entities
{
    public class User : EntityBase
    {
        public User(Name name, Email email, Document document, Password password)
        {
            AddNotifications(name, email, document, password);

            Name = name;
            Email = email;
            Document = document;
            Password = password;
            Posts = new List<Post>();
        }

        public Name Name { get; private set; }
        public string Image { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public Password Password { get; private set; }
        public IList<Post> Posts { get; private set; }

        public void ChangeName(Name name)
        {
            if (name.Invalid)
            {
                AddNotifications(name);
                return;
            }

            Name = name;
            return;
        }

        public void ChangePassword(Password newPassword)
        {
            if (newPassword.Invalid)
            {
                AddNotifications(newPassword);
                return;
            }

            Password = newPassword;
            return;
        }

        public void ChangeDocument(Document document)
        {
            if (document.Invalid)
            {
                AddNotifications(document);
                return;
            }

            Document = document;
            return;
        }

        public void ChangeImage(string image)
        {
            this.Image = image;
        }

        public void ChangeEmail(Email address)
        {
            if (address.Invalid)
            {
                AddNotifications(address);
                return;
            }

            Email = address;
            return;
        }
    }
}
