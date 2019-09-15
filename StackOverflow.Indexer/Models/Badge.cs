using System;

namespace StackOverflow.Indexer.Models
{
    public class Badge
    {
        public string Name { get; set; }
        public BadgeClass Class { get; set; }
        public DateTimeOffset Date { get; set; }
    }

    public class BadgeMeta
    {
        public int UserId { get; set; }
        public Badge Badge { get; set; }
    }
}