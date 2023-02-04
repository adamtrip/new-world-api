using System.Text;
using Application.Common.Caching;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Caching;

#pragma warning disable CA2254
public class DistributedCacheService : ICacheService
{
    private readonly IDistributedCache _cache;
    private readonly ILogger<DistributedCacheService> _logger;
    private readonly ISerializerService _serializer;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public DistributedCacheService(IDistributedCache cache, ISerializerService serializer, ILogger<DistributedCacheService> logger, IWebHostEnvironment webHostEnvironment) =>
        (_cache, _serializer, _logger, _webHostEnvironment) = (cache, serializer, logger, webHostEnvironment);

    public T? Get<T>(string key) =>
        Get(key) is { } data
            ? Deserialize<T>(data)
            : default;

    private byte[]? Get(string key)
    {
        ArgumentNullException.ThrowIfNull(key);
        key = (_webHostEnvironment.IsDevelopment() ? "nwtools_dev_" : "nwtools_prod_") + key;

        try
        {
            return _cache.Get(key);
        }
        catch
        {
            return null;
        }
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken token = default) =>
        await GetAsync(key, token) is { } data
            ? Deserialize<T>(data)
            : default;

    private async Task<byte[]?> GetAsync(string key, CancellationToken token = default)
    {
        try
        {
            key = (_webHostEnvironment.IsDevelopment() ? "nwtools_dev_" : "nwtools_prod_") + key;
            return await _cache.GetAsync(key, token);
        }
        catch
        {
            return null;
        }
    }

    public void Refresh(string key)
    {
        try
        {
            key = (_webHostEnvironment.IsDevelopment() ? "nwtools_dev_" : "nwtools_prod_") + key;
            _cache.Refresh(key);
        }
        catch
        {
        }
    }

    public async Task RefreshAsync(string key, CancellationToken token = default)
    {
        try
        {
            key = (_webHostEnvironment.IsDevelopment() ? "nwtools_dev_" : "nwtools_prod_") + key;
            await _cache.RefreshAsync(key, token);
            _logger.LogDebug(string.Format("Cache Refreshed : {0}", key));
        }
        catch
        {
        }
    }

    public void Remove(string key)
    {
        try
        {
            key = (_webHostEnvironment.IsDevelopment() ? "nwtools_dev_" : "nwtools_prod_") + key;
            _cache.Remove(key);
        }
        catch
        {
        }
    }

    public async Task RemoveAsync(string key, CancellationToken token = default)
    {
        try
        {
            key = (_webHostEnvironment.IsDevelopment() ? "nwtools_dev_" : "nwtools_prod_") + key;
            await _cache.RemoveAsync(key, token);
        }
        catch
        {
        }
    }

    public void Set<T>(string key, T value, TimeSpan? slidingExpiration = null) =>
        Set(key, Serialize(value), slidingExpiration);

    private void Set(string key, byte[] value, TimeSpan? slidingExpiration = null)
    {
        try
        {
            key = (_webHostEnvironment.IsDevelopment() ? "nwtools_dev_" : "nwtools_prod_") + key;
            _cache.Set(key, value, GetOptions(slidingExpiration));
            _logger.LogDebug($"Added to Cache : {key}");
        }
        catch
        {
        }
    }

    public Task SetAsync<T>(string key, T value, TimeSpan? slidingExpiration = null, CancellationToken cancellationToken = default) =>
        SetAsync(key, Serialize(value), slidingExpiration, cancellationToken);

    private async Task SetAsync(string key, byte[] value, TimeSpan? slidingExpiration = null, CancellationToken token = default)
    {
        try
        {
            key = (_webHostEnvironment.IsDevelopment() ? "nwtools_dev_" : "nwtools_prod_") + key;
            await _cache.SetAsync(key, value, GetOptions(slidingExpiration), token);
            _logger.LogDebug($"Added to Cache : {key}");
        }
        catch
        {
        }
    }

    private byte[] Serialize<T>(T item) =>
        Encoding.Default.GetBytes(_serializer.Serialize(item));

    private T Deserialize<T>(byte[] cachedData) =>
        _serializer.Deserialize<T>(Encoding.Default.GetString(cachedData));

    private static DistributedCacheEntryOptions GetOptions(TimeSpan? slidingExpiration)
    {
        var options = new DistributedCacheEntryOptions();
        if (slidingExpiration.HasValue)
        {
            options.SetSlidingExpiration(slidingExpiration.Value);
        }
        else
        {
            // TODO: add to appsettings?
            options.SetSlidingExpiration(TimeSpan.FromMinutes(10)); // Default expiration time of 10 minutes.
        }

        return options;
    }
}