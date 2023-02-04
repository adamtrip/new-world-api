using Application.NewWorld.AbilityData;
using Application.NewWorld.AffixStatData;
using Application.NewWorld.ConsumableItem;
using Application.NewWorld.DamageData;
using Application.NewWorld.Locale;
using Application.NewWorld.MasterItemDefinitions;
using Application.NewWorld.PerkBucketData;
using Application.NewWorld.PerkData;
using Application.NewWorld.SpellData;
using Application.NewWorld.StatusEffectData;
using Application.NewWorld.WeaponItemDefs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.Importer
{
    public record ImporterRequest : IRequest;
    public class ImportLocalesRequestHandler : IRequestHandler<ImporterRequest>
    {
        private readonly IMediator mediator;

        public ImportLocalesRequestHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async ValueTask<Unit> Handle(ImporterRequest request, CancellationToken cancellationToken)
        {

            //Import locales
            await mediator.Send(new ImportLocalesRequest(), cancellationToken);

            //Import AbilityData
            await mediator.Send(new ImportAbilityDataRequest(), cancellationToken);

            //Import AffixStatData
            await mediator.Send(new ImportAffixStatDataRequest(), cancellationToken);

            //Import ConsumableItemDefinitions
            await mediator.Send(new ImportConsumableItemDefinitionsRequest(), cancellationToken);

            //Import SpellData
            await mediator.Send(new ImportSpellDataRequest(), cancellationToken);

            //Import StatusEffectData
            await mediator.Send(new ImportStatusEffectRequest(), cancellationToken);

            //Import WeaponItemDefinitions
            await mediator.Send(new ImportWeaponItemDefinitionsRequest(true), cancellationToken);

            //Import DamageData
            await mediator.Send(new ImportDamageDataRequest(), cancellationToken);

            //Import PerkBucketData
            await mediator.Send(new ImportPerkBucketDataRequest(), cancellationToken);

            //Import perk data
            await mediator.Send(new ImportPerkDataRequest(), cancellationToken);

            //Import MasterItemDefinitions
            await mediator.Send(new ImportMasterItemDefinitionsRequest(), cancellationToken);

            //Import CraftingRecipes



            return default!;
        }
    }
}
