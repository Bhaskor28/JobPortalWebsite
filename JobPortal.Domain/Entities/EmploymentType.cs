using JobPortal.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Domain.Entities
{
    public class EmploymentType : BaseEntity
    {
        public string Name { get; set; } = default!;
        public ICollection<JobPost> JobPosts { get; set; }
    }
}
