using JobPortal.Domain.Common;

namespace JobPortal.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<JobPost> JobPosts { get; set; }
    }
}
