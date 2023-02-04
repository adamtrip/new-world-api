using Application.NewWorld.PerkData;
using Domain.Entities.NewWorld.AffixStatData;
using Domain.Entities.NewWorld.PerkData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.NewWorld.AffixStatData
{
    public record GetAffixStatDataRequest(string StatusID) : IRequest<AffixStatDataDto>;
    internal class GetAffixStatDataRequestHandler : IRequestHandler<GetAffixStatDataRequest, AffixStatDataDto>
    {
        private readonly IReadRepository<AffixStatDataTable> readRepository;

        public GetAffixStatDataRequestHandler(IReadRepository<AffixStatDataTable> readRepository)
        {
            this.readRepository = readRepository;
        }

        public async ValueTask<AffixStatDataDto> Handle(GetAffixStatDataRequest request, CancellationToken cancellationToken) =>
            await readRepository.SingleOrDefaultAsync(new GetAffixStatDataSpec(request.StatusID)) ?? throw new NotFoundException("Affix Stat Data not found");
    }

    internal class GetAffixStatDataSpec : SingleResultSpecification<AffixStatDataTable, AffixStatDataDto>, ISingleResultSpecification
    {
        public GetAffixStatDataSpec(string statusID) => Query.Where(x => x.StatusID == statusID);
    }
}
