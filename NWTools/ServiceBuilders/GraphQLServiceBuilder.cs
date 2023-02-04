using Infrastructure.Auth.Permissions;
using Infrastructure.Persistence.Context;
using System.Reflection;

namespace NWTools.ServiceBuilders
{
    public class GraphQLServiceBuilder
    {
        public static void Register(IServiceCollection services, IHostEnvironment environment)
        {
            var graph = services.AddGraphQL()
                .AddQueryType()
                .AddDiagnosticEventListener(sp =>
                      new ConsoleQueryLogger(
                        sp.GetApplicationService<ILogger<ConsoleQueryLogger>>()
                      ));

            //if (!environment.IsDevelopment())

            var graphqlTypes = FindExtendedObjectAttributes();

            foreach (var type in graphqlTypes)
            {
                graph.AddTypeExtension(type);
            }
            graph.AddGraphQLServer()
                .AddAuthorization()
                .RegisterDbContext<ApplicationDbContext>();


            services.AddSingleton<HotChocolate.AspNetCore.Authorization.IAuthorizationHandler, GraphQLAuthorizationHandler>();

        }

        private static IEnumerable<Type> FindExtendedObjectAttributes()
        {
            return Assembly.GetExecutingAssembly().GetTypes().Where(IsExtensionType);
            //var allFiles = Directory.EnumerateFiles(Path.Combine(basePath))
            //    .Where(x => x.Contains("CentralService") && x.EndsWith(".dll")).ToList();

            //allFiles.RemoveAll(x => !Path.GetFileName(x).Contains("CentralService"));

            //return allFiles.Select(x => Assembly.LoadFrom(x))
            //    .SelectMany(x => x.GetTypes())
            //        .Where(IsExtensionType);

        }

        private static bool IsExtensionType(Type type)
        {
            var attribute = type.GetCustomAttribute<ExtendObjectTypeAttribute>();
            return attribute != null;
        }
    }
}
