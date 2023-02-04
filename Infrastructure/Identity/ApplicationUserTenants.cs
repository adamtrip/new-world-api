using Domain.Common.Contracts;

namespace Infrastructure.Identity
{
    public class ApplicationUserTenant : AuditableEntity
    {
        public string UserId { get; set; }
        public string TentantId { get; set; }
    }
}
