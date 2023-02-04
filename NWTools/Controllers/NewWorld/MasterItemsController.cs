using Application.Identity.Tokens;
using Application.NewWorld.AbilityData;
using Application.NewWorld.Locale;
using Application.NewWorld.MasterItemDefinitions;
using Infrastructure.OpenApi;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace NWTools.Controllers.Identity;

public sealed class MasterItemsController : VersionedApiController
{

    //[HttpPost]
    //[AllowAnonymous]
    //[TenantIdHeader]
    //[OpenApiOperation("Request an access token using credentials.", "")]
    //public ValueTask<IEnumerable<MasterItemDefinitionDto>> GetMasterItemDefinitions(GetAllMasterItemDefinitionsRequest request, CancellationToken cancellationToken)
    //{
    //    return Mediator.Send(request, cancellationToken);
    //}
}