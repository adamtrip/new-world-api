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
