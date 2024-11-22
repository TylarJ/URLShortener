using URLShortener.Common;

namespace URLShortener.Data.Abstractions;

public interface IUrlDataStore
{
    public void Create(ShortUrlResult url);
    public ShortUrlResult? Get(string shortId);
}
