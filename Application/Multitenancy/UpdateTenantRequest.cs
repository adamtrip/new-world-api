namespace Application.Multitenancy;

public class UpdateTenantRequest : IRequest<string>
{
    public string Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? ConnectionString { get; set; }
    public string AdminEmail { get; set; } = default!;
    public string? Issuer { get; set; }
}

public class UpdateTenantRequestHandler : IRequestHandler<UpdateTenantRequest, string>
{
    private readonly ITenantService _tenantService;

    public UpdateTenantRequestHandler(ITenantService tenantService) => _tenantService = tenantService;

    public async ValueTask<string> Handle(UpdateTenantRequest request, CancellationToken cancellationToken) => await _tenantService.UpdateAsync(request, cancellationToken);
}