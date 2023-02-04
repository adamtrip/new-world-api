using Application.Common.Caching;
using Domain.Entities.NewWorld;

namespace Application.NewWorld.Locale
{
    public enum SearchType { Name, Description }
    public record GetItemsLocalesRequest(List<MasterItemDefinition> Items) : IRequest<List<MasterItemDefinition>>;
    public record GetItemLocalesRequest(string Key, string? KeyOverride, string? ItemID, SearchType SearchType = SearchType.Name) : IRequest<string>;

    public class GetItemsLocalesRequestHandler : IRequestHandler<GetItemsLocalesRequest, List<MasterItemDefinition>>
    {
        private readonly IRepository<Locales> repository;
        private readonly ICacheService cacheService;
        private List<Locales> cachedLocales;

        public GetItemsLocalesRequestHandler(IRepository<Locales> repository, ISerializerService serializerService, ICacheService cacheService)
        {
            this.repository = repository;
            this.cacheService = cacheService;
            this.cachedLocales = new List<Locales>();
        }

        public async ValueTask<List<MasterItemDefinition>> Handle(GetItemsLocalesRequest request, CancellationToken cancellationToken)
        {
            cachedLocales = cacheService.Get<List<Locales>>("Locales") ?? new List<Locales>();
            if (!cachedLocales.Any())
            {
                cachedLocales = await repository.ListAsync(cancellationToken);

                cacheService.Set("Locales", cachedLocales);
            }

            for (var i = 0; i < request.Items.Count; i++)
            {
                request.Items[i].MasterName = GetName("", request.Items[i].Name ?? "", request.Items[i].ItemID ?? "");
                request.Items[i].MasterDescription = GetName("", request.Items[i].Description ?? "", request.Items[i].ItemID ?? "");
            }


            return request.Items;
        }

        private string GetName(string keyOverride, string key, string itemID)
        {
            var result = string.Empty;
            //Override search
            if (keyOverride != "") result = SearchName(keyOverride);

            //Default search
            if (result == "" && key != "") result = SearchName(key);

            //Procedural search
            if (result == "" && key != "" && !key.StartsWith("Procedural_")) result = SearchName("Procedural_" + key);

            //Item ID Search
            if (result == "" && itemID != "") result = SearchName(itemID);

            return result;
        }

        private string GetDescription(string keyOverride, string key, string itemID)
        {
            var result = string.Empty;

            //Override search
            if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(keyOverride)) result = SearchDescription(keyOverride);

            //Default search
            if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(key)) result = SearchDescription(key);

            //Procedural search
            if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(key) && !key.StartsWith("Procedural_")) result = SearchDescription("Procedural_" + key);

            //Item ID Search
            if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(itemID)) result = SearchDescription(itemID);

            return result;
        }

        private string SearchName(string key)
        {
            var itemLocales = new List<Locales>();
            //var text = cachedLocales.SingleOrDefault(x => x.Key.ToLower() == key.ToLower())?.Text;
            var text = cachedLocales.SingleOrDefault(x => string.Equals(x.Key, key, StringComparison.CurrentCultureIgnoreCase))?.Text;
            if (string.IsNullOrEmpty(text))
            {
                var keyWithoutAt = key.Replace("@", "");
                itemLocales = cachedLocales.Where(x => x.Key.Contains(keyWithoutAt, StringComparison.InvariantCultureIgnoreCase)).ToList();

                //Default search
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower())).Text;

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_mastername")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_mastername")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_name")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_name")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_recipename")).Text;

                var keyRemoveLast__ = String.Join("_", keyWithoutAt.Split("_").SkipLast(1));
                if (itemLocales.Any(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())).Text;
            }

            if (string.IsNullOrEmpty(text))
            {
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(key.ToLower())).ToList();

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_mastername")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_mastername")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_name")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_name")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_recipename")).Text;

                var keyRemoveLast__ = String.Join("_", key.Split("_").SkipLast(1));
                if (itemLocales.Any(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())).Text;
            }
            else
            {
                return text;
            }

            var keyRemoveLast_ = String.Join("_", key.Split("_").SkipLast(1));

            if (string.IsNullOrEmpty(text))
            {
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(keyRemoveLast_.ToLower())).ToList();

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_mastername")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_mastername")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_name")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_name")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_recipename")).Text;

            }

            return "";
        }

        private string SearchDescription(string key)
        {
            var itemLocales = new List<Locales>();
            var text = cachedLocales.SingleOrDefault(x => x.Key.ToLower() == key.ToLower())?.Text;
            if (string.IsNullOrEmpty(text))
            {
                var keyWithoutAt = key.Replace("@", "");
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(keyWithoutAt.ToLower())).ToList();

                //Default search
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower())).Text;

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_masterdescription")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_masterdescription")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_description")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_description")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_recipename")).Text;

                var keyRemoveLast__ = String.Join("_", keyWithoutAt.Split("_").SkipLast(1));
                if (itemLocales.Any(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())).Text;
            }

            if (string.IsNullOrEmpty(text))
            {
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(key.ToLower())).ToList();

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_masterdescription")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_masterdescription")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_description")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_description")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_recipename")).Text;

                var keyRemoveLast__ = String.Join("_", key.Split("_").SkipLast(1));
                if (itemLocales.Any(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())).Text;
            }
            else
            {
                return text;
            }

            var keyRemoveLast_ = String.Join("_", key.Split("_").SkipLast(1));

            if (string.IsNullOrEmpty(text))
            {
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(keyRemoveLast_.ToLower())).ToList();

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_masterdescription")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_masterdescription")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_description")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_description")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_recipename")).Text;

            }

            return "";
        }
    }

    public class GetItemLocalesRequestHandler : IRequestHandler<GetItemLocalesRequest, string>
    {
        private readonly IRepository<Locales> repository;
        private readonly ICacheService cacheService;
        private List<Locales> cachedLocales;

        public GetItemLocalesRequestHandler(IRepository<Locales> repository, ISerializerService serializerService, ICacheService cacheService)
        {
            this.repository = repository;
            this.cacheService = cacheService;
            this.cachedLocales = new List<Locales>();
        }

        public async ValueTask<string> Handle(GetItemLocalesRequest request, CancellationToken cancellationToken)
        {
            var result = string.Empty;
            cachedLocales = cacheService.Get<List<Locales>>("Locales") ?? new List<Locales>();
            if (!cachedLocales.Any())
            {
                cachedLocales = await repository.ListAsync(cancellationToken);

                cacheService.Set("Locales", cachedLocales);
            }
            if (request.SearchType == SearchType.Name)
            {
                //Override search
                if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(request.KeyOverride)) result = SearchName(request.KeyOverride);

                //Default search
                if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(request.Key)) result = SearchName(request.Key);

                //Procedural search
                if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(request.Key) && !request.Key.StartsWith("Procedural_")) result = SearchName("Procedural_" + request.Key);

                //Item ID Search
                if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(request.ItemID)) result = SearchName(request.ItemID);
            }
            else
            {
                //Override search
                if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(request.KeyOverride)) result = SearchDescription(request.KeyOverride);

                //Default search
                if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(request.Key)) result = SearchDescription(request.Key);

                //Procedural search
                if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(request.Key) && !request.Key.StartsWith("Procedural_")) result = SearchDescription("Procedural_" + request.Key);

                //Item ID Search
                if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(request.ItemID)) result = SearchDescription(request.ItemID);
            }


            return result;
        }

        private string SearchName(string key)
        {
            var itemLocales = new List<Locales>();
            //var text = cachedLocales.SingleOrDefault(x => x.Key.ToLower() == key.ToLower())?.Text;
            var text = cachedLocales.SingleOrDefault(x => string.Equals(x.Key, key, StringComparison.CurrentCultureIgnoreCase))?.Text;
            if (string.IsNullOrEmpty(text))
            {
                var keyWithoutAt = key.Replace("@", "");
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(keyWithoutAt.ToLower())).ToList();

                //Default search
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower())).Text;

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_mastername")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_mastername")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_name")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_name")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_recipename")).Text;

                var keyRemoveLast__ = String.Join("_", keyWithoutAt.Split("_").SkipLast(1));
                if (itemLocales.Any(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())).Text;
            }

            if (string.IsNullOrEmpty(text))
            {
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(key.ToLower())).ToList();

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_mastername")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_mastername")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_name")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_name")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_recipename")).Text;

                var keyRemoveLast__ = String.Join("_", key.Split("_").SkipLast(1));
                if (itemLocales.Any(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())).Text;
            }
            else
            {
                return text;
            }

            var keyRemoveLast_ = String.Join("_", key.Split("_").SkipLast(1));

            if (string.IsNullOrEmpty(text))
            {
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(keyRemoveLast_.ToLower())).ToList();

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_mastername")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_mastername")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_name")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_name")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_recipename")).Text;

            }

            return "";
        }

        private string SearchDescription(string key)
        {
            var itemLocales = new List<Locales>();
            var text = cachedLocales.SingleOrDefault(x => x.Key.ToLower() == key.ToLower())?.Text;
            if (string.IsNullOrEmpty(text))
            {
                var keyWithoutAt = key.Replace("@", "");
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(keyWithoutAt.ToLower())).ToList();

                //Default search
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower())).Text;

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_masterdescription")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_masterdescription")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_description")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_description")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyWithoutAt.ToLower() + "_recipename")).Text;

                var keyRemoveLast__ = String.Join("_", keyWithoutAt.Split("_").SkipLast(1));
                if (itemLocales.Any(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())).Text;
            }

            if (string.IsNullOrEmpty(text))
            {
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(key.ToLower())).ToList();

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_masterdescription")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_masterdescription")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_description")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_description")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (key.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (key.ToLower() + "_recipename")).Text;

                var keyRemoveLast__ = String.Join("_", key.Split("_").SkipLast(1));
                if (itemLocales.Any(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())))
                    return itemLocales.First(x => x.Key.ToLower().EndsWith(keyRemoveLast__.ToLower())).Text;
            }
            else
            {
                return text;
            }

            var keyRemoveLast_ = String.Join("_", key.Split("_").SkipLast(1));

            if (string.IsNullOrEmpty(text))
            {
                itemLocales = cachedLocales.Where(x => x.Key.ToLower().Contains(keyRemoveLast_.ToLower())).ToList();

                //Search by ending _MasterName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_masterdescription")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_masterdescription")).Text;

                //Search by ending _Name
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_description")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_description")).Text;

                //Search by ending _RecipeName
                if (itemLocales.Any(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_recipename")))
                    return itemLocales.First(x => x.Key.ToLower() == (keyRemoveLast_.ToLower() + "_recipename")).Text;

            }

            return "";
        }
    }

    public class GetItemLocaleSpec : Specification<Locales, Locales>, ISingleResultSpecification
    {
        public GetItemLocaleSpec(string key) => Query.Where(x => x.Key == key);
    }
}
