using Application.Common.Caching;
using Application.NewWorld.Locale;
using Application.NewWorld.PerkBucketData;
using Application.NewWorld.PerkData;
using Application.NewWorld.WeaponItemDefs;
using Domain.Entities.NewWorld;
using Mapster;
using MapsterMapper;
using Share.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.MasterItemDefinitions
{
    public record PagedMasterItemDefinitions(IEnumerable<MasterItemDefinitionDto> Items, int TotalCount);

    public record GetPagedMasterItemDefinitionsRequest(int? Take, int? Skip, string? Filter) : IRequest<PagedMasterItemDefinitions>;

    public class GetPagedMasterItemDefinitionsRequestHandler : IRequestHandler<GetPagedMasterItemDefinitionsRequest, PagedMasterItemDefinitions>
    {
        private readonly IReadRepository<MasterItemDefinition> repository;
        private readonly IReadRepository<Locales> localesRepository;
        private readonly ICacheService cacheService;
        private readonly IMediator mediator;

        public GetPagedMasterItemDefinitionsRequestHandler(IReadRepository<MasterItemDefinition> repository, ICacheService cacheService, IReadRepository<Locales> localesRepository, IMediator mediator)
        {
            this.repository = repository;
            this.cacheService = cacheService;
            this.localesRepository = localesRepository;
            this.mediator = mediator;
        }

        public async ValueTask<PagedMasterItemDefinitions> Handle(GetPagedMasterItemDefinitionsRequest request, CancellationToken cancellationToken)
        {
            //var perks = await mediator.Send(new GetItemPerksRequest(), cancellationToken);
            //var cachedItems = cacheService.Get<List<MasterItemDefinitionDto>>(CachingConstants.ALL_ITEMS);
            //if (cachedItems == null)
            //{

            //    cacheService.Set(CachingConstants.ALL_ITEMS, cachedItems, TimeSpan.FromHours(24));
            //}
            var perks = await mediator.Send(new GetItemPerksRequest(), cancellationToken);
            var items = await repository.ListAsync(new PagedMasterItemDefinitionsSpec(request.Take ?? 10, request.Skip ?? 0), cancellationToken);
            var totalCount = await repository.CountAsync(cancellationToken);

            foreach (var item in items)
            {
                try
                {
                    if (!string.IsNullOrEmpty(item.Perk1)) item.ItemPerk1 = perks.FirstOrDefault(x => x.PerkID == item.Perk1);
                    if (!string.IsNullOrEmpty(item.Perk2)) item.ItemPerk2 = perks.FirstOrDefault(x => x.PerkID == item.Perk2);
                    if (!string.IsNullOrEmpty(item.Perk3)) item.ItemPerk3 = perks.FirstOrDefault(x => x.PerkID == item.Perk3);
                    if (!string.IsNullOrEmpty(item.Perk4)) item.ItemPerk4 = perks.FirstOrDefault(x => x.PerkID == item.Perk4);
                    if (!string.IsNullOrEmpty(item.Perk5)) item.ItemPerk5 = perks.FirstOrDefault(x => x.PerkID == item.Perk5);

                    var itemClassSplit = item.ItemClass.Split('+');

                    if (!string.IsNullOrEmpty(item.PerkBucket1))
                        item.ItemPerkBucket1 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket1, itemClassSplit));
                    if (!string.IsNullOrEmpty(item.PerkBucket2))
                        item.ItemPerkBucket2 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket2, itemClassSplit));
                    if (!string.IsNullOrEmpty(item.PerkBucket3))
                        item.ItemPerkBucket3 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket3, itemClassSplit));
                    if (!string.IsNullOrEmpty(item.PerkBucket4))
                        item.ItemPerkBucket3 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket4, itemClassSplit));
                    if (!string.IsNullOrEmpty(item.PerkBucket5))
                        item.ItemPerkBucket4 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket5, itemClassSplit));

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
                    //if (!string.IsNullOrEmpty(item.ItemStatsRef) && item.ItemType == "Weapon") item.WeaponItemDefinition = await mediator.Send(new GetWeaponItemDefinitionRequest(item.ItemStatsRef));
                }
                catch (Exception ex)
                {

                }
            }
            return new PagedMasterItemDefinitions(items, totalCount);
        }
    }

    public class PagedMasterItemDefinitionsSpec : Specification<MasterItemDefinition, MasterItemDefinitionDto>
    {
        public PagedMasterItemDefinitionsSpec(int take, int skip) =>
            Query.OrderBy(x => x.GearScoreOverride).Take(take).Skip(skip);
    }
}
