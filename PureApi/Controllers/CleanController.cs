using Microsoft.AspNetCore.Mvc;
using PureApi.Extensions;
using PureApi.Models;
using SmartReader;

namespace PureApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Clean")]
    public class CleanController : Controller
    {
        [HttpGet]
        public Result Get(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                return null;
            }

            Article article = Reader.ParseArticle(url);

            if (article == null)
            {
                return null;
            }

            return ResultMaker.FromArticle(article);
        }
    }
}
