using Social.Shared.Entities;

namespace Social.Domain.Entities
{
    public class Post : EntityBase
    {
        public Post(string content, string? image = null)
        {
            Content = content;
            Image = image;
            Tags = new List<Tag>();
        }

        public string Content { get; private set; }
        public List<Tag>? Tags { get; private set; }
        public string? Image { get; private set; }
    }
}
