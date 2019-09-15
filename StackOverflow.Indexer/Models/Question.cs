using System;
using System.Collections.Generic;
using Nest;

namespace StackOverflow.Indexer.Models
{
    public class Question : Post
    {
        public string Title { get; set; }
        public CompletionField TitleSuggest { get; set; }
        public int? AcceptedAnswerId { get; set; }
        public int ViewCount { get; set; }
        public string LastEditorDisplayName { get; set; }
        public int AnswerCount { get; set; }
        public int FavoriteCount { get; set; }
        public DateTimeOffset? CommunityOwnedDate { get; set; }
        public override string Type => nameof(Question);
    }
}