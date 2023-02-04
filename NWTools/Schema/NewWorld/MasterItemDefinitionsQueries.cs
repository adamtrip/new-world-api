using Application.NewWorld.MasterItemDefinitions;
using DocumentFormat.OpenXml.Spreadsheet;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types.Pagination;
using Infrastructure.Auth.Permissions;
using Mediator;
using System.Threading;

namespace NWTools.Schema.NewWorld
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class MasterItemDefinitionsQueries
    {
        [Authorize]
        public async Task<MasterItemDefinitionDto> GetMasterItemDefinition([Service] IMediator mediator, Guid masterItemId) =>
            await mediator.Send(new GetMasterItemDefinitionRequest(masterItemId));

        [Authorize]
        [UseOffsetPaging(IncludeTotalCount = true)]
        public async Task<CollectionSegment<MasterItemDefinitionDto>> GetMasterItemDefinitions([Service] IMediator mediator, int? skip, int? take)
        {
            var items = await mediator.Send(new GetAllMasterItemDefinitionsRequest(take, skip, null, ""));
            var pageInfo = new CollectionSegmentInfo(false, false);

            var collectionSegment = new CollectionSegment<MasterItemDefinitionDto>(items.items.ToList(), pageInfo,
                ct => ValueTask.FromResult(items.totalItems));

            return collectionSegment;

        }
    }
}
