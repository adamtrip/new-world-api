using Application.NewWorld.Importer;
using Infrastructure.OpenApi;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace NWTools.Controllers.NewWorld
{
    public class ImporterController : VersionedApiController
    {
        [HttpPost("ImportData")]
        [AllowAnonymous]
        [TenantIdHeader]
        [OpenApiOperation("Import data from datasheets.", "")]
        public ValueTask<Unit> ImportData(CancellationToken cancellationToken)
        {
            return Mediator.Send(new ImporterRequest(), cancellationToken);
        }
    }
}
