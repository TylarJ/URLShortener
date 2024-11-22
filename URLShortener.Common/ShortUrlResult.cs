namespace URLShortener.Common;

public class ShortUrlResult
{
    public string OriginalUrl { get; set; } = default!;
    public string ShortId { get; set; } = default!;
    public string ShortUrl => $"https://short.url/{ShortId}";
}