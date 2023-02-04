using Application.Common.Caching;
using Application.NewWorld.PerkBucketData;
using Application.NewWorld.PerkData;
using Application.NewWorld.WeaponItemDefs;
using Domain.Entities.NewWorld;
using Domain.Entities.NewWorld.PerkData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.MasterItemDefinitions
{
    public record GetMasterItemDefinitionRequest(Guid MasterItemId) : IRequest<MasterItemDefinitionDto>;

    internal sealed class GetMasterItemDefinitionRequestHandler : IRequestHandler<GetMasterItemDefinitionRequest, MasterItemDefinitionDto>
    {
        private readonly IReadRepository<MasterItemDefinition> readRepository;
        private readonly IMediator mediator;
        private readonly ICacheService cacheService;

        public GetMasterItemDefinitionRequestHandler(IReadRepository<MasterItemDefinition> readRepository, IMediator mediator, ICacheService cacheService)
        {
            this.readRepository = readRepository;
            this.mediator = mediator;
            this.cacheService = cacheService;
        }

        public async ValueTask<MasterItemDefinitionDto> Handle(GetMasterItemDefinitionRequest request, CancellationToken cancellationToken)
        {
            var cachedItem = cacheService.Get<MasterItemDefinitionDto>(request.MasterItemId.ToString());
            if(cachedItem != null)
                return cachedItem;
            else
            {
                try
                {
                    var item = await readRepository.SingleOrDefaultAsync(new GetMasterItemDefinitionSpec(request.MasterItemId)) ?? throw new NotFoundException("Master item not found"); ;
                    if (!string.IsNullOrEmpty(item.Perk1)) item.ItemPerk1 = await mediator.Send(new GetItemPerkRequest(item.Perk1));
                    if (!string.IsNullOrEmpty(item.Perk2)) item.ItemPerk2 = await mediator.Send(new GetItemPerkRequest(item.Perk2));
                    if (!string.IsNullOrEmpty(item.Perk3)) item.ItemPerk3 = await mediator.Send(new GetItemPerkRequest(item.Perk3));
                    if (!string.IsNullOrEmpty(item.Perk4)) item.ItemPerk4 = await mediator.Send(new GetItemPerkRequest(item.Perk4));
                    if (!string.IsNullOrEmpty(item.Perk5)) item.ItemPerk5 = await mediator.Send(new GetItemPerkRequest(item.Perk5));

                    if (!string.IsNullOrEmpty(item.PerkBucket1)) item.ItemPerkBucket1 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket1, item.ItemClass.Split('+')));
                    if (!string.IsNullOrEmpty(item.PerkBucket2)) item.ItemPerkBucket2 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket2, item.ItemClass.Split('+')));
                    if (!string.IsNullOrEmpty(item.PerkBucket3)) item.ItemPerkBucket3 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket3, item.ItemClass.Split('+')));
                    if (!string.IsNullOrEmpty(item.PerkBucket4)) item.ItemPerkBucket3 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket4, item.ItemClass.Split('+')));
                    if (!string.IsNullOrEmpty(item.PerkBucket5)) item.ItemPerkBucket4 = await mediator.Send(new GetPerkBucketDataRequest(item.PerkBucket5, item.ItemClass.Split('+')));

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
                    if (!string.IsNullOrEmpty(item.ItemStatsRef)) item.WeaponItemDefinition = await mediator.Send(new GetWeaponItemDefinitionRequest(item.ItemStatsRef));

                    cacheService.Set(request.MasterItemId.ToString(), item);

                    return item;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }

    internal class GetMasterItemDefinitionSpec : SingleResultSpecification<MasterItemDefinition, MasterItemDefinitionDto>, ISingleResultSpecification
    {
        public GetMasterItemDefinitionSpec(Guid id) => Query.Where(x => x.Id == id);
    }
}
