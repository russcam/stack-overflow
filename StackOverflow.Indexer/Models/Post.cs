using System;
using System.Collections.Generic;
using Nest;

namespace StackOverflow.Indexer.Models
{
    public class Post
    {
        public int Id { get; set; }
        public JoinField ParentId { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public int? OwnerUserId { get; set; }
        public string OwnerDisplayName { get; set; }
        public int? LastEditorUserId { get; set; }
        public DateTimeOffset? LastEditDate { get; set; }
        public DateTimeOffset? LastActivityDate { get; set; }
        public int CommentCount { get; set; }
        public List<string> Tags { get; set; }
        public virtual string Type => nameof(Post);
    }
}