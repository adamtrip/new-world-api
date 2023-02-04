using System.Collections.ObjectModel;

namespace Share.Authorization;

public static class FSHAction
{
    public const string View = nameof(View);
    public const string Search = nameof(Search);
    public const string Create = nameof(Create);
    public const string Update = nameof(Update);
    public const string Delete = nameof(Delete);
    public const string Export = nameof(Export);
    public const string Generate = nameof(Generate);
    public const string Clean = nameof(Clean);
    public const string UpgradeSubscription = nameof(UpgradeSubscription);
}

public static class FSHResource
{
    public const string CentralService = nameof(CentralService);
    public const string Tenants = nameof(Tenants);
}

public static class FSHPermissions
{
    private static readonly FSHPermission[] _all = new FSHPermission[]
    {
        new("System", "Central Service", FSHAction.View, FSHResource.CentralService),
        new("System", "View Tenants", FSHAction.View, FSHResource.Tenants, IsRoot: true),
        new("System", "Create Tenants", FSHAction.Create, FSHResource.Tenants, IsRoot: true),
        new("System", "Update Tenants", FSHAction.Update, FSHResource.Tenants, IsRoot: true),
        new("System", "Upgrade Tenant Subscription", FSHAction.UpgradeSubscription, FSHResource.Tenants, IsRoot: true),
    };

    public static IReadOnlyList<FSHPermission> All { get; } = new ReadOnlyCollection<FSHPermission>(_all);
    public static IReadOnlyList<FSHPermission> Root { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Admin { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => !p.IsRoot).ToArray());
    public static IReadOnlyList<FSHPermission> Basic { get; } = new ReadOnlyCollection<FSHPermission>(_all.Where(p => p.IsBasic).ToArray());
}

public record FSHPermission(string Application, string Description, string Action, string Resource, bool IsBasic = false, bool IsRoot = false)
{
    public string Name => NameFor(Action, Resource, Application);
    public static string NameFor(string action, string resource, string application) => $"Permissions.{application}.{resource}.{action}";
}


