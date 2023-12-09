namespace GPTTokenizer.Console
{
    using GPTTokenizer;
    using GPTTokenizer.Models;
    using GPTTokenizer.Models.Merge;
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static Tokenizer tokenizer = new Tokenizer(GPTModel.GPT3_5_turbo);

        static void Main(string[] args)
        {
            WriteHeader("GPTTokenizer");

            string input;

            if (args.Length == 1)
            {
                input = args[1];
            }
            else
            {
                Console.Write("Input: ");
                input = Console.ReadLine();
                Console.WriteLine();
            }

            var mergeLog = new MergeLog();
            var tokens = tokenizer.Tokenize(input, mergeLog);

            foreach(var entry in mergeLog.Entries)
            {
                WriteTokens(entry.Tokens, entry.MergeRule);
            }

            Console.WriteLine($"\nIDs: [{string.Join(", ", tokenizer.GetIDs(tokens))}]");
            Console.WriteLine("\nPress any key ...");
            Console.ReadKey();
        }

        private static void WriteTokens(IEnumerable<string> tokens, MergeRule mergeRule = null)
        {
            var currentTokenString = string.Join("|", tokens);
            if (mergeRule == null)
                Console.WriteLine($"|{currentTokenString}|");
            else
                Console.WriteLine($"|{currentTokenString}| ← Applied merge rule #{mergeRule.Priority} ({mergeRule})");
        }

        private static void WriteHeader(string text)
        {
            Console.WriteLine(text);
            Console.WriteLine(new string('-', text.Length));
            Console.WriteLine();
        }
    }
}
