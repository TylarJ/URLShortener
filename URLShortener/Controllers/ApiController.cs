using Microsoft.AspNetCore.Mvc;
using URLShortener.Models;
using URLShortener.Services.Abstractions;
using URLShortener.Common;

namespace URLShortener.Controllers;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private readonly IUrlService _urlService;

    public ApiController(IUrlService urlService)
    {
        _urlService = urlService;
    }

    [HttpPost("shorten")]
    public ActionResult<ShortUrlResult> Post(ShortUrlRequest request)
    {
        if (!_urlService.IsValid(request.Url))
            return BadRequest();
        
        var result = _urlService.ShortenUrl(request.Url);

        return Ok(result);
    }

    [HttpGet("{shortId}")]
    public ActionResult<ShortUrlResult> Get(string shortId)
    {
        var result = _urlService.Get(shortId);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
