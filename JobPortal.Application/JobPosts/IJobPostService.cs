using JobPortal.Application.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.JobPosts
{
    public interface IJobPostService
    {
        Task<IList<JobPostVM>> GetAllJobPostAsync();
    }
}
