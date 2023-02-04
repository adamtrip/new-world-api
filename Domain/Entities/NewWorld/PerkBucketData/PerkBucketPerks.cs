using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld.PerkBucketData
{
    public class PerkBucketPerk : AuditableEntity, IAggregateRoot
    {
        public int PerkNumber { get; set; }
        public string PerkId { get; set; }
        public string Weight { get; set; }
        public Guid PerkBucketId { get; set; }
        public PerkBuckets PerkBuckets { get; set; }
    }
}
