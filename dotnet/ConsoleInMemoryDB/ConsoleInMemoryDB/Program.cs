using Enyim.Caching;
using Enyim.Caching.Configuration;
using Microsoft.Extensions.Logging;

string key = "MyKey";

using var loggerFactory = LoggerFactory.Create(builder =>
    builder.AddConsole()
    .SetMinimumLevel(LogLevel.Warning));

ILogger logger = loggerFactory.CreateLogger<Program>();

var config = new MemcachedClientConfiguration(loggerFactory, new MemcachedClientOptions());
config.AddServer("localhost", 11211);

MemcachedClient myCache = new MemcachedClient(loggerFactory, config);

Console.WriteLine($"Setting - Key:{key}, Value:999");
await myCache.SetAsync(key, 999, 10);

Console.WriteLine($"\nWaiting a second...\n");
await Task.Delay(1000);

int number = myCache.Get<int>(key);
Console.WriteLine($"Getting - Key:{key}, Value:{number}");