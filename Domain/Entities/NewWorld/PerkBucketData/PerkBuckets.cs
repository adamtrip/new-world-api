﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.NewWorld.PerkBucketData
{
    public class PerkBuckets : AuditableEntity, IAggregateRoot
    {
        public string PerkBucketID { get; set; }
        public string PerkType { get; set; }
        public double? PerkChance { get; set; }
        public string IgnoreExclusiveLabelWeights { get; set; }
        public List<PerkBucketPerk> Perks { get; set; }
        public string CURRENTLIMIT { get; set; }
    }
}
