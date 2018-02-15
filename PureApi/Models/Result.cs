using System;

namespace PureApi.Models
{
    public class Result
    {
        public Uri Uri { get; set; }
        public string Title { get; set; }
        public string Byline { get; set; }
        public string Dir { get; set; }
        public string TextContent { get; set; }
        public string Excerpt { get; set; }
        public string Language { get; set; }
        public string Author { get; set; }
        public int Length { get; set; }
        public TimeSpan TimeToRead { get; set; }
        public DateTime? PublicationDate { get; set; }
        public bool CacheHit { get; set; }
    }
}