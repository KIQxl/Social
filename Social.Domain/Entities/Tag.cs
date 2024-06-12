using Social.Shared.Entities;

namespace Social.Domain.Entities
{
    public class Tag : EntityBase
    {
        public Tag(string tagName)
        {
            TagName = tagName;
            Posts = new List<Post>();
        }

        public string TagName { get; private set; }
        public List<Post>? Posts { get; private set; }
    }
}
