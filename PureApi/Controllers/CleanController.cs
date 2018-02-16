using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PureApi.Extensions;
using PureApi.Models;
using SmartReader;
using System;

namespace PureApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Clean")]
    public class CleanController : Controller
    {
        private IMemoryCache _cache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(45))
            .SetAbsoluteExpiration(TimeSpan.FromHours(1));

        public CleanController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        [HttpGet]
        public Result Get(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            if (_cache.TryGetValue(url, out Result result))
            {
                result.CacheHit = true;
                return result;
            }

            Article article = Reader.ParseArticle(url);

            if (article == null)
            {
                return null;
            }

            result = ResultMaker.FromArticle(article);

            _cache.Set(url, result, _cacheEntryOptions);

            return result;
        }
    }
}
