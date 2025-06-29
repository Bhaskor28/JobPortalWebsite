using JobPortal.Domain.Common;

namespace JobPortal.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<JobPost> JobPosts { get; set; }
    }
}
