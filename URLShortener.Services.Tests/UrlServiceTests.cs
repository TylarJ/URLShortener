using URLShortener.Data;
using Xunit;

namespace URLShortener.Services.Tests;

public class UrlServiceTests
{
    [Fact]
    public void UrlService_IsValid_True()
    {
        // Arrange
        var url = "https://full.url/test/is/valid";
        var uut = GetUrlService();


        // Act
        var result = uut.IsValid(url);


        // Assert
        Assert.True(result);
    }

    [Fact]
    public void UrlService_IsValid_False()
    {
        // Arrange
        var url = "full.url/test/is/valid";
        var uut = GetUrlService();


        // Act
        var result = uut.IsValid(url);


        // Assert
        Assert.False(result);
    }

    [Fact]
    public void UrlService_ShortenUrl_UniqueShortId()
    {
        // Arrange
        var urlA = "full.url.a";
        var urlB = "full.url.b";

        var uut = GetUrlService();


        // Act
        var resultA = uut.ShortenUrl(urlA);
        var resultB = uut.ShortenUrl(urlB);


        // Assert
        Assert.NotNull(resultA);
        Assert.NotNull(resultB);
        Assert.NotEqual(resultA.ShortUrl, resultB.ShortUrl);
    }

    [Fact]
    public void UrlService_Get_Found()
    {
        // Arrange
        var urlA = "full.url.a";
        var expectedShortId = "BD23CF6B";

        var uut = GetUrlService();

        var _ = uut.ShortenUrl(urlA);


        // Act
        var result = uut.Get(expectedShortId);


        // Assert
        Assert.NotNull(result);
        Assert.Equal(urlA, result.OriginalUrl);
    }

    [Fact]
    public void UrlService_Get_NotFound()
    {
        // Arrange
        var urlA = "full.url.a";
        var expectedShortId = "BD23CF6B!";

        var uut = GetUrlService();

        var _ = uut.ShortenUrl(urlA);


        // Act
        var result = uut.Get(expectedShortId);


        // Assert
        Assert.Null(result);
    }

    private static UrlService GetUrlService()
    {
        var dataStore = new UrlDataStore(); // TODO: Mock the interface instead...
        var uut = new UrlService(dataStore);
        return uut;
    }
}
