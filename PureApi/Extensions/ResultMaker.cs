using System;
using PureApi.Models;
using SmartReader;

namespace PureApi.Extensions
{
    public static class ResultMaker
    {
        public static Result FromArticle(Article article)
        {
            return new Result
            {
                Author = article.Author,
                Byline = article.Byline,
                Dir = article.Dir,
                Excerpt = article.Excerpt,
                Language = article.Language,
                Length = article.Length,
                PublicationDate = article.PublicationDate,
                TextContent = CleanTextContent(article.TextContent),
                TimeToRead = article.TimeToRead,
                Title = article.Title,
                Uri = article.Uri
            };
        }

        private static string CleanTextContent(string textContent)
        {
            var r = textContent.Replace("\n", String.Empty);
            return r;
        }
    }
}