using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobPortal.Domain.Entities
{
    public class JobPost : BaseEntity
    {
        public string? LogoPath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public string EducationRequirement { get; set; }
        public string ExperienceRequirement { get; set; }
        public int Vacancy { get; set; }
        public DateTime Deadline { get; set; }
        public int EmploymentTypeId { get; set; }
        public EmploymentType? EmploymentType { get; set; }
        public int JobCategoryId { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }
        public int ExperienceId { get; set; }
        public Experience? Experience { get; set; }


    }
}
