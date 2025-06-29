using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        [Url(ErrorMessage = "Enter a valid website URL.")]
        public string? Website { get; set; }
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string? Email { get; set; }
        [Phone(ErrorMessage = "Enter a valid phone number.")]
        public string? Phone { get; set; }
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Please select a company size.")]
        public string? CompanySize { get; set; }
        [StringLength(1000, ErrorMessage = "About section is too long.")]
        public string? About { get; set; }
        public string? LogoPath { get; set; }
        public ICollection<JobPost>? JobPosts { get; set; }
    }
}
