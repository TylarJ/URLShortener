using System.Security.Cryptography;
using System.Text;
using URLShortener.Services.Abstractions;
using URLShortener.Common;
using URLShortener.Data.Abstractions;

namespace URLShortener.Services;

internal class UrlService : IUrlService
{
    private readonly IUrlDataStore _urlDataStore;

    public UrlService(IUrlDataStore urlDataStore)
    {
        _urlDataStore = urlDataStore;
    }

    public bool IsValid(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }

    public ShortUrlResult? Get(string shortId)
    {
        return _urlDataStore.Get(shortId);
    }

    public ShortUrlResult ShortenUrl(string url)
    {
        string hash = GenerateHash(url);

        var result = new ShortUrlResult
        {
            OriginalUrl = url,
            ShortId = hash
        };

        _urlDataStore.Create(result);
        return result;
    }

    private static string GenerateHash(string url)
    {
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(url));

        // Increase to decrease the chance of collisions...
        // TODO: Refactor
        const int hashLength = 8;

        return BitConverter.ToString(hash)
            .Replace("-", string.Empty)
            [..hashLength];
    }
}
