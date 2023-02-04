using Application.Common.Validation;
using FluentValidation;
using Mediator;

namespace Application.Multitenancy;

public class DeactivateTenantRequest : IRequest<string>
{
    public string TenantId { get; set; } = default!;

    public DeactivateTenantRequest(string tenantId) => TenantId = tenantId;
}

public class DeactivateTenantRequestValidator : CustomValidator<DeactivateTenantRequest>
{
    public DeactivateTenantRequestValidator() =>
        RuleFor(t => t.TenantId)
            .NotEmpty();
}

public class DeactivateTenantRequestHandler : IRequestHandler<DeactivateTenantRequest, string>
{
    private readonly ITenantService _tenantService;

    public DeactivateTenantRequestHandler(ITenantService tenantService) => _tenantService = tenantService;

    public async ValueTask<string> Handle(DeactivateTenantRequest request, CancellationToken cancellationToken) =>
        await _tenantService.DeactivateAsync(request.TenantId);
}