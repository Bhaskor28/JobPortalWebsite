using JobPortal.Application.Categories;
using JobPortal.Application.Common;
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
        Task<PagedResult<JobPostVM>> GetFilteredJobPostsAsync(string? categoryId, int page, int pageSize);
    }
}
