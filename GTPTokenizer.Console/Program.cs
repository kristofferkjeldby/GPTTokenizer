namespace GTPTokenizer.Console
{
    using GPTTokenizer;
    using GPTTokenizer.Models;
    using GPTTokenizer.Models.Merge;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            string text;

            if (args.Length == 2)
            {
                command = args[0];
                text = args[1];
            }
            else
            {
                System.Console.WriteLine("Command:");
                command = System.Console.ReadLine();
                System.Console.WriteLine("Text:");
                text = System.Console.ReadLine();
                System.Console.WriteLine();
            }

            var tokenizer = new Tokenizer();

            switch (command.ToLowerInvariant())
            {
                case "count":
                    {
                        System.Console.WriteLine($"Number of tokens: {tokenizer.CountTokens(text)}");
                        break;
                    }
                case "tokenize":
                    {
                        var mergeLog = new MergeLog();
                        var tokens = tokenizer.Tokenize(text, mergeLog);

                        foreach(var entry in mergeLog.Entries)
                        {
                            WriteTokens(entry.Tokens, entry.MergeRule);
                        }

                        System.Console.WriteLine();
                        System.Console.WriteLine($"IDs: [{string.Join(", ", tokenizer.GetIDs(tokens))}]");

                        break;
                    }
                default:
                    {
                        System.Console.WriteLine("Unknown command");
                        break;
                    }
            }

            System.Console.ReadKey();
        }

        private static void WriteTokens(IEnumerable<Token> tokens, MergeRule mergeRule = null)
        {
            var currentTokenString = string.Join("|", tokens);
            if (mergeRule == null)
                System.Console.WriteLine($"|{currentTokenString}|");
            else
                System.Console.WriteLine($"|{currentTokenString}| ← Applied merge rule #{mergeRule.Priority} ({mergeRule})");
        }
    }
}
