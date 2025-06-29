using JobPortal.Domain.Common;

namespace JobPortal.Domain.Entities
{
    public class EmploymentType : BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<JobPost> JobPosts { get; set; }
    }
}
