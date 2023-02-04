using Application.Common.Caching;
using Application.NewWorld.PerkData;
using Domain.Entities.NewWorld.PerkBucketData;
using System.Collections.Concurrent;

namespace Application.NewWorld.PerkBucketData
{
    public record GetPerkBucketDataRequest(string PerkBucketId, string[] ItemClasses) : IRequest<PerkBucketDataDto>;

    internal class GetPerkBucketDataRequestHandler : IRequestHandler<GetPerkBucketDataRequest, PerkBucketDataDto>
    {
        private readonly IReadRepository<PerkBuckets> readRepository;
        private readonly IMediator mediator;
        private readonly ICacheService cacheService;

        public GetPerkBucketDataRequestHandler(IReadRepository<PerkBuckets> readRepository, IMediator mediator, ICacheService cacheService)
        {
            this.readRepository = readRepository;
            this.mediator = mediator;
            this.cacheService = cacheService;
        }

        public async ValueTask<PerkBucketDataDto> Handle(GetPerkBucketDataRequest request, CancellationToken cancellationToken)
        {
            //var cacheKey = $"perk_bucket_{request.PerkBucketId}";

            //var cachedPerk = await cacheService.GetAsync<PerkBucketDataDto>(cacheKey, cancellationToken);
            //if (cachedPerk == null)
            //{
            //    cachedPerk = await readRepository.FirstOrDefaultAsync(new GetPerkBucketDataSpec(request.PerkBucketId), cancellationToken);
            //    if (cachedPerk == null) throw new NotFoundException($"Perk bucket id not found: {request.PerkBucketId}");

            //    var perks = await mediator.Send(new GetItemPerksForBucketRequest(), cancellationToken);
            //    var perksNoItemClass = new ConcurrentBag<Guid>();
            //    Parallel.ForEach(cachedPerk.Perks, async (perk) =>
            //    {
            //        var dbPerk = perks.FirstOrDefault(x => x.PerkID == perk.PerkId);
            //        var perkClassNames = dbPerk?.ItemClass?.Split('+');
            //        if (perkClassNames != null && !perkClassNames.Any(x => request.ItemClasses.Contains(x)))
            //        {
            //            perksNoItemClass.Add(perk.PerkBucketPerkId);
            //        }
            //    });
            //    cachedPerk.Perks.RemoveAll(x => perksNoItemClass.Contains(x.PerkBucketPerkId));

            //    cacheService.Set(cacheKey, cachedPerk);
            //}

            //return cachedPerk;
            var cacheKey = $"perk_bucket_{request.PerkBucketId}";

            var cachedPerk = await cacheService.GetAsync<PerkBucketDataDto>(cacheKey, cancellationToken);
            if (cachedPerk == null)
            {
                cachedPerk = await readRepository.FirstOrDefaultAsync(new GetPerkBucketDataSpec(request.PerkBucketId), cancellationToken);
                if (cachedPerk == null) throw new NotFoundException($"Perk bucket id not found: {request.PerkBucketId}");

                var perks = await mediator.Send(new GetItemPerksForBucketRequest(), cancellationToken);
                var perksNoItemClass = new ConcurrentBag<Guid>();

                cachedPerk.Perks
                        .AsParallel()
                        .Where(perk =>
                            perks.FirstOrDefault(dbPerk => dbPerk.PerkID == perk.PerkId &&
                            !dbPerk.ItemClass.Split('+').Any(x => request.ItemClasses.Contains(x))) == null)
                        .ForAll(perk => perksNoItemClass.Add(perk.PerkBucketPerkId));

                cachedPerk.Perks.RemoveAll(x => perksNoItemClass.Contains(x.PerkBucketPerkId));

                cacheService.Set(cacheKey, cachedPerk);
            }

            return cachedPerk;
        }
    }

    internal class GetPerkBucketDataSpec : SingleResultSpecification<PerkBuckets, PerkBucketDataDto>, ISingleResultSpecification
    {
        public GetPerkBucketDataSpec(string perkBucketId) => Query.Include(x => x.Perks).Where(x => x.PerkBucketID == perkBucketId);
    }

    internal class GetPerkBucketsDataSpec : Specification<PerkBuckets, PerkBucketDataDto>
    {
        public GetPerkBucketsDataSpec() => Query.Include(x => x.Perks);
    }
}
