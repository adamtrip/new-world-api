using Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class ApplicationUserTenant : AuditableEntity
    {
        public string UserId { get; set; }
        public string TentantId { get; set; }
    }
}
