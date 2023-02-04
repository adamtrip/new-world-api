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
    public const string Events = nameof(Events);
    public const string Customers = nameof(Customers);
    public const string EventTypes = nameof(EventTypes);
    public const string TargetMuscleTypes = nameof(TargetMuscleTypes);
    public const string ExerciseTypes = nameof(ExerciseTypes);
    public const string Plans = nameof(Plans);
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

        new("CalGest", "View Events", FSHAction.View, FSHResource.Events),
        new("CalGest", "Search Events", FSHAction.Search, FSHResource.Events),
        new("CalGest", "Create Events", FSHAction.Create, FSHResource.Events),
        new("CalGest", "Update Events", FSHAction.Update, FSHResource.Events),
        new("CalGest", "Delete Events", FSHAction.Delete, FSHResource.Events),

        new("CalGest", "View Event Types", FSHAction.View, FSHResource.EventTypes),
        new("CalGest", "Search Event Types", FSHAction.Search, FSHResource.EventTypes),
        new("CalGest", "Create Event Types", FSHAction.Create, FSHResource.EventTypes),
        new("CalGest", "Update Event Types", FSHAction.Update, FSHResource.EventTypes),
        new("CalGest", "Delete Event Types", FSHAction.Delete, FSHResource.EventTypes),

        new("CalGest", "View Customers", FSHAction.View, FSHResource.Customers),
        new("CalGest", "Search Customers", FSHAction.Search, FSHResource.Customers),
        new("CalGest", "Create Customers", FSHAction.Create, FSHResource.Customers),
        new("CalGest", "Update Customers", FSHAction.Update, FSHResource.Customers),
        new("CalGest", "Delete Customers", FSHAction.Delete, FSHResource.Customers),

        new("CalGest", "View Target Muscle Types", FSHAction.View, FSHResource.TargetMuscleTypes),
        new("CalGest", "Search Target Muscle Types", FSHAction.Search, FSHResource.TargetMuscleTypes),
        new("CalGest", "Create Target Muscle Types", FSHAction.Create, FSHResource.TargetMuscleTypes),
        new("CalGest", "Update Target Muscle Types", FSHAction.Update, FSHResource.TargetMuscleTypes),
        new("CalGest", "Delete Target Muscle Types", FSHAction.Delete, FSHResource.TargetMuscleTypes),

        new("CalGest", "View Customers", FSHAction.View, FSHResource.ExerciseTypes),
        new("CalGest", "Search Exercise Types", FSHAction.Search, FSHResource.ExerciseTypes),
        new("CalGest", "Create Exercise Types", FSHAction.Create, FSHResource.ExerciseTypes),
        new("CalGest", "Update Exercise Types", FSHAction.Update, FSHResource.ExerciseTypes),
        new("CalGest", "Delete Exercise Types", FSHAction.Delete, FSHResource.ExerciseTypes),

        new("CalGest", "View Plans", FSHAction.View, FSHResource.Plans),
        new("CalGest", "Search Plans", FSHAction.Search, FSHResource.Plans),
        new("CalGest", "Create Plans", FSHAction.Create, FSHResource.Plans),
        new("CalGest", "Update Plans", FSHAction.Update, FSHResource.Plans),
        new("CalGest", "Delete Plans", FSHAction.Delete, FSHResource.Plans)
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


