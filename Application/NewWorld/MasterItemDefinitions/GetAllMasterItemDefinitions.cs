using Application.Common.Caching;
using Application.NewWorld.PerkBucketData;
using Application.NewWorld.PerkData;
using Application.NewWorld.WeaponItemDefs;
using Domain.Entities.NewWorld;

namespace Application.NewWorld.MasterItemDefinitions
{
    public record GetAllMasterItemDefinitionsRequest(int? Take, int? Skip, string? Filter, string SortBy) : IRequest<(int totalItems, IEnumerable<MasterItemDefinitionDto> items)>;

    public class GetAllMasterItemDefinitionsRequestHandler : IRequestHandler<GetAllMasterItemDefinitionsRequest, (int totalItems, IEnumerable<MasterItemDefinitionDto> items)>
    {
        private readonly IReadRepository<MasterItemDefinition> repository;
        private readonly IReadRepository<Locales> localesRepository;
        private readonly ICacheService cacheService;
        private readonly IMediator mediator;

        public GetAllMasterItemDefinitionsRequestHandler(IReadRepository<MasterItemDefinition> repository, ICacheService cacheService, IReadRepository<Locales> localesRepository, IMediator mediator)
        {
            this.repository = repository;
            this.cacheService = cacheService;
            this.localesRepository = localesRepository;
            this.mediator = mediator;
        }

        public async ValueTask<(int totalItems, IEnumerable<MasterItemDefinitionDto> items)> Handle(GetAllMasterItemDefinitionsRequest request, CancellationToken cancellationToken)
        {
            var cacheKey = $"items_{request.Skip ?? 0}_{request.Take ?? 10}_{request.SortBy}";

            var cachedItems = await cacheService.GetAsync<List<MasterItemDefinitionDto>>(cacheKey, cancellationToken);
            if (cachedItems == null)
            {
                cachedItems = await repository.ListAsync(new MasterItemDefinitionsSpec(request.Skip ?? 0, request.Take ?? 10, request.SortBy), cancellationToken);

                foreach (var item in cachedItems)
                {
                    if (!string.IsNullOrEmpty(item.Perk1)) item.ItemPerk1 = await mediator.Send(new GetItemPerkRequest(item.Perk1), cancellationToken);
                    if (!string.IsNullOrEmpty(item.Perk2)) item.ItemPerk2 = await mediator.Send(new GetItemPerkRequest(item.Perk2), cancellationToken);
                    if (!string.IsNullOrEmpty(item.Perk3)) item.ItemPerk3 = await mediator.Send(new GetItemPerkRequest(item.Perk3), cancellationToken);
                    if (!string.IsNullOrEmpty(item.Perk4)) item.ItemPerk4 = await mediator.Send(new GetItemPerkRequest(item.Perk4), cancellationToken);
                    if (!string.IsNullOrEmpty(item.Perk5)) item.ItemPerk5 = await mediator.Send(new GetItemPerkRequest(item.Perk5), cancellationToken);

                    var itemClassSplit = item.ItemClass.Split('+');

                    if (!string.IsNullOrEmpty(item.PerkBucket1))
                        item.ItemPerkBucket1 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket1, itemClassSplit), cancellationToken);
                    if (!string.IsNullOrEmpty(item.PerkBucket2))
                        item.ItemPerkBucket2 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket2, itemClassSplit), cancellationToken);
                    if (!string.IsNullOrEmpty(item.PerkBucket3))
                        item.ItemPerkBucket3 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket3, itemClassSplit), cancellationToken);
                    if (!string.IsNullOrEmpty(item.PerkBucket4))
                        item.ItemPerkBucket4 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket4, itemClassSplit), cancellationToken);
                    if (!string.IsNullOrEmpty(item.PerkBucket5))
                        item.ItemPerkBucket5 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket5, itemClassSplit), cancellationToken);

                    //Armor apearance
                    if (string.IsNullOrEmpty(item.IconPath) && !string.IsNullOrEmpty(item.ArmorAppearanceM))
                    {
                        item.IconPath = $"/images/icons/items/armor/{item.ArmorAppearanceM}.png";
                    }

                    //Weapon apearance
                    if (string.IsNullOrEmpty(item.IconPath) && !string.IsNullOrEmpty(item.WeaponAppearanceOverride))
                    {
                        item.IconPath = $"/images/icons/items/weapon/{item.WeaponAppearanceOverride}.png";
                    }

                    if (!item.IconPath.EndsWith(".png")) item.IconPath += ".png";

                    //Weapon definition
                    if (!string.IsNullOrEmpty(item.ItemStatsRef) && item.ItemType == "Weapon") item.WeaponItemDefinition = await mediator.Send(new GetWeaponItemDefinitionRequest(item.ItemStatsRef));
                }

                await cacheService.SetAsync(cacheKey, cachedItems, TimeSpan.FromHours(24));
            }


            var totalItems = await cacheService.GetAsync<int>("masterItems_totalCount", cancellationToken);
            if (totalItems <= 0)
            {
                totalItems = await repository.CountAsync(cancellationToken);
                await cacheService.SetAsync("masterItems_totalCount", totalItems, cancellationToken: cancellationToken);
            }

            return (totalItems, cachedItems);
        }
    }

    public class MasterItemDefinitionsSpec : Specification<MasterItemDefinition, MasterItemDefinitionDto>
    {
        public MasterItemDefinitionsSpec(int skip, int take, string orderBy) =>
            Query.AsNoTracking().OrderByDescending(x => x.GearScoreOverride).Skip(skip).Take(take);
    }
}
