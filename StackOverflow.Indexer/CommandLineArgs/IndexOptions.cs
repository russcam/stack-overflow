using System;
using CommandLine;

namespace StackOverflow.Indexer.CommandLineArgs
{
    public class IndexOptions
    {
        [Option('e', "elasticsearch", Required = true, HelpText = "The url to use to connect to Elasticsearch")]
        public Uri ElasticsearchUrl { get; set; }

        [Option('u', "username", Required = false,
            HelpText = "The username to use to connect to Elasticsearch when the cluster has security enabled")]
        public string UserName { get; set; }

        [Option('p', "password", Required = false,
            HelpText = "The password to use to connect to Elasticsearch when the cluster has security enabled")]
        public string Password { get; set; }

        [Option('k', "insecure", Required = false,
            HelpText =
                "Allow unsecured connections to Elasticsearch. Useful when Elasticsearch is running over HTTPS with a self-signed cert. Not recommended for production, fine for demo purposes")]
        public bool AllowInsecure { get; set; }
    }
}