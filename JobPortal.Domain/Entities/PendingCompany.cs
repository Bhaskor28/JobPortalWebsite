using JobPortal.Domain.Common;
using JobPortal.Domain.Enums;

namespace JobPortal.Domain.Entities
{
    public class PendingCompany: BaseEntity
    {
        public string Name { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? CompanySize { get; set; }
        public string? About { get; set; }
        public string? LogoPath { get; set; }
        public CompanyStatus Status { get; set; } = CompanyStatus.Requested;
    }
}
