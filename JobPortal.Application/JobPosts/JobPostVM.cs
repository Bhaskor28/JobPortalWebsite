using JobPortal.Domain.Entities;
using JobPortal.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Application.JobPosts
{
    public class JobPostVM
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LogoPath { get; set; }
        [Required(ErrorMessage = "Job title is required.")]
        [StringLength(100, ErrorMessage = "Title can't exceed 100 characters.")]
        public string Title { get; set; }
        public int LocationId { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Min salary must be a positive number.")]
        public decimal MinSalary { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Max salary must be a positive number.")]
        public decimal MaxSalary { get; set; }
        [Required(ErrorMessage = "Job description is required.")]
        [StringLength(2000, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Education requirement is required.")]
        public string EducationRequirement { get; set; }
        [Required(ErrorMessage = "Experience requirement is required.")]
        public string ExperienceRequirement { get; set; }
        [Required(ErrorMessage = "Deadline is required.")]
        public DateTime Deadline { get; set; }
        public int EmploymentTypeId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Vacancy must be at least 1.")]
        public int Vacancy { get; set; }
        public EmploymentType EmploymentType { get; set; }
        [Required(ErrorMessage = "Job category is required.")]
        public int JobCategoryId { get; set; }
        public JobPostStatus Status { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
        [Required(ErrorMessage = "Experience level is required.")]
        public int ExperienceId { get; set; }
        public Location? Location { get; set; }
        public Experience? Experience { get; set; }
    }
}
