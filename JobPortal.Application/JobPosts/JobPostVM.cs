using JobPortal.Domain.Entities;
using JobPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Application.JobPosts
{
    public class JobPostVM
    {
        public DateTime CreatedAt { get; set; }
        public string CompanyName { get; set; }
        public int EmployerId { get; set; }
        public string LogoPath { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public string EducationRequirement { get; set; }
        public string ExperienceRequirement { get; set; }
        public DateTime Deadline { get; set; }
        public int EmploymentTypeId { get; set; }
        public int JobCategoryId { get; set; }
        public JobPostStatus Status { get; set; }
    }
}
