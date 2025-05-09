using JobPortal.Domain.Common;
using JobPortal.Domain.Enums;

namespace JobPortal.Domain.Entities
{
    public class JobPost : BaseEntity
    {
        public string CompanyName { get; set; }
        public int EmployerId { get; set; }
        public string LogoPath { get; set; } // Assuming image as byte array
        public int ApprovedByAdminId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public string EducationRequirement { get; set; }
        public string ExperienceRequirement { get; set; }
        public DateTime Deadline { get; set; }
        public int EmploymentTypeId { get; set; }
        public int JobCategoryId { get; set; }
        public JobPostStatus Status { get; set; }
        public Category Category { get; set; }
    }
}
