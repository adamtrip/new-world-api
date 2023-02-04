using Application.Common.Caching;
using Application.NewWorld.AffixStatData;
using Domain.Entities.NewWorld.PerkData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.PerkData
{
    public record GetItemPerkRequest(string GamePerkId) : IRequest<ItemPerkDto?>;

    internal sealed class GetItemPerkRequestHandler : IRequestHandler<GetItemPerkRequest, ItemPerkDto?>
    {
        private readonly IReadRepository<ItemPerk> readRepository;
        private readonly IMediator mediator;
        private readonly ICacheService cacheService;

        public GetItemPerkRequestHandler(IReadRepository<ItemPerk> readRepository, IMediator mediator, ICacheService cacheService)
        {
            this.readRepository = readRepository;
            this.mediator = mediator;
            this.cacheService = cacheService;
        }

        public async ValueTask<ItemPerkDto?> Handle(GetItemPerkRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = $"itemperk_{request.GamePerkId}";
            var perk = await cacheService.GetAsync<ItemPerkDto>(cacheKey, cancellationToken);
            if(perk == null)
            {
                perk = await readRepository.SingleOrDefaultAsync(new GetItemPerkSpec(request.GamePerkId), cancellationToken);
                if (!string.IsNullOrEmpty(perk?.Affix)) perk.AffixStatData = await mediator.Send(new GetAffixStatDataRequest(perk.Affix), cancellationToken);
            }

            return perk;
        }
        
    }

    internal class GetItemPerkSpec : SingleResultSpecification<ItemPerk, ItemPerkDto>, ISingleResultSpecification
    {
        public GetItemPerkSpec(string gamePerkId) => Query.Where(x => x.PerkID == gamePerkId);
    }
}
