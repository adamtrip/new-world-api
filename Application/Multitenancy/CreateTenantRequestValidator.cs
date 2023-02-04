namespace Application.Multitenancy;

public class CreateTenantRequestValidator : CustomValidator<CreateTenantRequest>
{
    public CreateTenantRequestValidator(
        ITenantService tenantService)
    {
        RuleFor(t => t.Id).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MustAsync(async (id, _) => !await tenantService.ExistsWithIdAsync(id))
                .WithMessage((_, id) => string.Format("Tenant {0} already exists.", id));

        RuleFor(t => t.Name).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MustAsync(async (name, _) => !await tenantService.ExistsWithNameAsync(name!))
                .WithMessage((_, name) => string.Format("Tenant {0} already exists.", name));

        RuleFor(t => t.ConnectionString).Cascade(CascadeMode.Stop)
            .Must((_, cs) => string.IsNullOrWhiteSpace(cs))
                .WithMessage("Connection string invalid.");

        RuleFor(t => t.AdminEmail).Cascade(CascadeMode.Stop)
            .NotEmpty()
            .EmailAddress();
    }
}