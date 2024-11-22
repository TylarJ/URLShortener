using URLShortener.Common;

namespace URLShortener.Services.Abstractions;

public interface IUrlService
{
    public ShortUrlResult? Get(string shortId);
    bool IsValid(string url);
    public ShortUrlResult ShortenUrl(string url);
}
