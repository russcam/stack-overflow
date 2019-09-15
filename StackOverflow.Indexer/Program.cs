using System;
using CommandLine;
using StackOverflow.Indexer.CommandLineArgs;

namespace StackOverflow.Indexer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<IndexPostsOptions, IndexUsersOptions, UpdateAnswersWithTagsOptions>(args)
                .MapResult(
                    (IndexPostsOptions opts) => RunIndexPostsAndReturnExitCode(opts),
                    (IndexUsersOptions opts) => RunIndexUsersAndReturnExitCode(opts),
                    (UpdateAnswersWithTagsOptions opts) => UpdateAnswersWithQuestionTagsAndReturnExitCode(opts),
                    errs => 1);
        }

        private static int RunIndexUsersAndReturnExitCode(IndexUsersOptions opts)
        {
            try
            {
                var indexer = new BulkIndexer(opts);
                indexer.IndexUsers(opts.UsersPath, opts.BadgesPath);
                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return 1;
            }
        }

        private static int RunIndexPostsAndReturnExitCode(IndexPostsOptions opts)
        {
            try
            {
                var indexer = new BulkIndexer(opts);
                indexer.IndexPosts(opts.PostsPath);
                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return 1;
            }
        }

        private static int UpdateAnswersWithQuestionTagsAndReturnExitCode(UpdateAnswersWithTagsOptions opts)
        {
            try
            {
                var indexer = new BulkIndexer(opts);
                indexer.UpdateAnswersWithQuestionTags(opts.PostsPath, opts.Size);
                return 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                return 1;
            }
        }
    }
}