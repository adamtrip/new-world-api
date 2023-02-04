namespace Application.Multitenancy;

public class GetAllTenantsRequest : IRequest<List<TenantDto>>
{
}

public class GetAllTenantsRequestHandler : IRequestHandler<GetAllTenantsRequest, List<TenantDto>>
{
    private readonly ITenantService _tenantService;

    public GetAllTenantsRequestHandler(ITenantService tenantService) => _tenantService = tenantService;

    public async ValueTask<List<TenantDto>> Handle(GetAllTenantsRequest request, CancellationToken cancellationToken) =>
        await _tenantService.GetAllAsync();
}