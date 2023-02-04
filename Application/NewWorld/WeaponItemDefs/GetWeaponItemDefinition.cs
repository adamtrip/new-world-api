using Application.NewWorld.AffixStatData;
using Application.NewWorld.PerkData;
using Domain.Entities.NewWorld.PerkData;
using Domain.Entities.NewWorld.WeaponItemDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.WeaponItemDefs
{
    public record GetWeaponItemDefinitionRequest(string WeaponID) : IRequest<WeaponItemDefinitionDto?>;
    internal class GetWeaponItemDefinitionRequestHandler : IRequestHandler<GetWeaponItemDefinitionRequest, WeaponItemDefinitionDto?>
    {
        private readonly IReadRepository<WeaponItemDefinitions> readRepository;

        public GetWeaponItemDefinitionRequestHandler(IReadRepository<WeaponItemDefinitions> readRepository)
        {
            this.readRepository = readRepository;
        }

        public async ValueTask<WeaponItemDefinitionDto?> Handle(GetWeaponItemDefinitionRequest request, CancellationToken cancellationToken) =>
            await readRepository.SingleOrDefaultAsync(new GetWeaponItemDefinitionSpec(request.WeaponID));
    }

    internal class GetWeaponItemDefinitionSpec : SingleResultSpecification<WeaponItemDefinitions, WeaponItemDefinitionDto>, ISingleResultSpecification
    {
        public GetWeaponItemDefinitionSpec(string weaponID) => Query.Where(x => x.WeaponID == weaponID);
    }
}
