using System.Collections.Concurrent;
using URLShortener.Data.Abstractions;
using URLShortener.Common;

namespace URLShortener.Data;

internal class UrlDataStore : IUrlDataStore
{
    // Mock DB.
    private static ConcurrentBag<ShortUrlResult> _shortUrls = [];

    public void Create(ShortUrlResult url)
    {
        // TODO: Ensure thread safety in db...
        var dbUrl = Get(url.ShortId);

        if (dbUrl != null)
            return;

        _shortUrls.Add(url);
    }

    public ShortUrlResult? Get(string shortId) => _shortUrls.FirstOrDefault(u => u.ShortId == shortId);
}
