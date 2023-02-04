using Application.Multitenancy;
using Infrastructure.Auth.Permissions;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Share.Authorization;

namespace NWTools.Controllers.Multitenancy;

public class TenantsController : VersionNeutralApiController
{
    [HttpGet]
    [MustHavePermission(FSHAction.View, FSHResource.Tenants, "System")]
    [OpenApiOperation("Get a list of all tenants.", "")]
    public ValueTask<List<TenantDto>> GetListAsync()
    {
        return Mediator.Send(new GetAllTenantsRequest());
    }

    [HttpGet("{id}")]
    [MustHavePermission(FSHAction.View, FSHResource.Tenants, "System")]
    [OpenApiOperation("Get tenant details.", "")]
    public ValueTask<TenantDto> GetAsync(string id)
    {
        return Mediator.Send(new GetTenantRequest(id));
    }

    [HttpPost]
    [MustHavePermission(FSHAction.Create, FSHResource.Tenants, "System")]
    [OpenApiOperation("Create a new tenant.", "")]
    public ValueTask<string> CreateAsync(CreateTenantRequest request)
    {
        return Mediator.Send(request);
    }

    [HttpPost("{id}/activate")]
    [MustHavePermission(FSHAction.Update, FSHResource.Tenants, "System")]
    [OpenApiOperation("Activate a tenant.", "")]
    //[ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Register))]
    public ValueTask<string> ActivateAsync(string id)
    {
        return Mediator.Send(new ActivateTenantRequest(id));
    }

    [HttpPost("{id}/deactivate")]
    [MustHavePermission(FSHAction.Update, FSHResource.Tenants, "System")]
    [OpenApiOperation("Deactivate a tenant.", "")]
    //[ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Register))]
    public ValueTask<string> DeactivateAsync(string id)
    {
        return Mediator.Send(new DeactivateTenantRequest(id));
    }

    [HttpPost("{id}/upgrade")]
    [MustHavePermission(FSHAction.UpgradeSubscription, FSHResource.Tenants, "System")]
    [OpenApiOperation("Upgrade a tenant's subscription.", "")]
    //[ApiConventionMethod(typeof(FSHApiConventions), nameof(FSHApiConventions.Register))]
    public async Task<ActionResult<string>> UpgradeSubscriptionAsync(string id, UpgradeSubscriptionRequest request)
    {
        return id != request.TenantId
            ? BadRequest()
            : Ok(await Mediator.Send(request));
    }
}