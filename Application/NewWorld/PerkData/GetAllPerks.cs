using Application.Common.Caching;
using Application.Common.Persistence;
using Application.NewWorld.MasterItemDefinitions;
using Domain.Entities.NewWorld;
using Domain.Entities.NewWorld.PerkData;
using Mapster;
using Mediator;
using Share.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.PerkData
{
    public record GetItemPerksRequest : IRequest<IEnumerable<ItemPerkDto>>;
    public record GetItemPerksForBucketRequest : IRequest<IEnumerable<ItemPerkForBucketDto>>;

    internal sealed class GetItemPerksRequestHandler : IRequestHandler<GetItemPerksRequest, IEnumerable<ItemPerkDto>>
    {
        private readonly IReadRepository<ItemPerk> readRepository;
        private readonly ICacheService cacheService;

        public GetItemPerksRequestHandler(IReadRepository<ItemPerk> readRepository, ICacheService cacheService)
        {
            this.readRepository = readRepository;
            this.cacheService = cacheService;
        }

        public async ValueTask<IEnumerable<ItemPerkDto>> Handle(GetItemPerksRequest request, CancellationToken cancellationToken)
        {
            var cachedItems = cacheService.Get<List<ItemPerkDto>>(CachingConstants.ALL_ITEM_PERKS);
            if (cachedItems == null)
            {
                cachedItems = (await readRepository.ListAsync(cancellationToken)).Adapt<List<ItemPerkDto>>();
                cacheService.Set(CachingConstants.ALL_ITEM_PERKS, cachedItems, TimeSpan.FromHours(24));
            }

            return cachedItems;
        }

    }

    internal sealed class GetItemPerksForBucketRequestHandler : IRequestHandler<GetItemPerksForBucketRequest, IEnumerable<ItemPerkForBucketDto>>
    {
        private readonly IReadRepository<ItemPerk> readRepository;
        private readonly ICacheService cacheService;

        public GetItemPerksForBucketRequestHandler(IReadRepository<ItemPerk> readRepository, ICacheService cacheService)
        {
            this.readRepository = readRepository;
            this.cacheService = cacheService;
        }

        public async ValueTask<IEnumerable<ItemPerkForBucketDto>> Handle(GetItemPerksForBucketRequest request, CancellationToken cancellationToken)
        {
            var cachedItems = cacheService.Get<List<ItemPerkForBucketDto>>("perks_for_buckets");
            if (cachedItems == null)
            {
                cachedItems = await readRepository.ListAsync(new GetItemPerksForBucketSpec(), cancellationToken);
                cacheService.Set("perks_for_buckets", cachedItems, TimeSpan.FromHours(24));
            }

            return cachedItems;
        }

    }

    public class GetItemPerksForBucketSpec : Specification<ItemPerk, ItemPerkForBucketDto>
    {
        public GetItemPerksForBucketSpec() =>
            Query.AsNoTracking();
    }
}
