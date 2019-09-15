using Elasticsearch.Net;

namespace StackOverflow.Indexer.Models
{
    [StringEnum]
    public enum BadgeClass
    {
        Gold = 1,
        Silver = 2,
        Bronze = 3
    }
}