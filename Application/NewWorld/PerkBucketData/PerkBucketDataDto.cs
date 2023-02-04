using Domain.Entities.NewWorld.PerkBucketData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.PerkBucketData
{

    public class PerkBucketDataDto
    {
        public string PerkBucketID { get; set; }
        public string PerkType { get; set; }
        public double? PerkChance { get; set; }
        public string IgnoreExclusiveLabelWeights { get; set; }
        public List<PerkBucketDataPerksDto> Perks { get; set; }
    }

    public class PerkBucketDataPerksDto
    {
        public Guid PerkBucketPerkId { get; set; }
        public int PerkNumber { get; set; }
        public string PerkId { get; set; }
        public string Weight { get; set; }
        public string PerkBucketsId { get; set; }
    }
}
