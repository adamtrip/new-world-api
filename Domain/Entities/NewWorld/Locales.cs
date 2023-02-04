using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld
{
    public class Locales : AuditableEntity, IAggregateRoot
    {
        public string Key { get; set; }
        public string Text { get; set; }
        public string ISO { get; set; }
    }
}
