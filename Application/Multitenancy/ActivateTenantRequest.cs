namespace Application.Multitenancy;

public class ActivateTenantRequest : IRequest<string>
{
    public string TenantId { get; set; } = default!;

    public ActivateTenantRequest(string tenantId) => TenantId = tenantId;
}

public class ActivateTenantRequestValidator : CustomValidator<ActivateTenantRequest>
{
    public ActivateTenantRequestValidator() =>
        RuleFor(t => t.TenantId)
            .NotEmpty();
}

public class ActivateTenantRequestHandler : IRequestHandler<ActivateTenantRequest, string>
{
    private readonly ITenantService _tenantService;

    public ActivateTenantRequestHandler(ITenantService tenantService) => _tenantService = tenantService;

    public async ValueTask<string> Handle(ActivateTenantRequest request, CancellationToken cancellationToken) =>
        await _tenantService.ActivateAsync(request.TenantId);
}