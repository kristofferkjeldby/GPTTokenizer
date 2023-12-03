namespace GTPTokenizer.Console
{
    using GPTTokenizer;
    using GPTTokenizer.Models;
    using GPTTokenizer.Models.Merge;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal class Program
    {
        private static Tokenizer tokenizer = new Tokenizer(GTPModel.GTP3_5_turbo);
        private static Random random = new Random();

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
                Console.WriteLine("Command:");
                command = Console.ReadLine();
                Console.WriteLine("Text:");
                text = Console.ReadLine();
                Console.WriteLine();
            }

            switch (command.ToLowerInvariant())
            {
                case "speed":
                    {
                        SpeedTest();
                        break;
                    }
                case "count":
                    {
                        Console.WriteLine($"Number of tokens: {tokenizer.CountTokens(text)}");
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

                        Console.WriteLine();
                        Console.WriteLine($"IDs: [{string.Join(", ", tokenizer.GetIDs(tokens))}]");

                        break;
                    }
                default:
                    {
                        Console.WriteLine("Unknown command");
                        break;
                    }
            }

            Console.ReadKey();
        }

        private static void SpeedTest()
        {
            var mstokenizer = new Microsoft.ML.Tokenizers.Tokenizer(new Microsoft.ML.Tokenizers.Bpe("./Data/vocab.json", "./Data/merges.txt"));
            var stopWatch = new Stopwatch();
            var test = RandomString(5000);

            stopWatch.Start();
            var msResult = mstokenizer.Encode(test);
            stopWatch.Stop();

            Console.WriteLine($"Microsoft tokenizer found {msResult.Tokens.Count()} in {stopWatch.ElapsedMilliseconds} ms");

            stopWatch.Restart();
            var result = tokenizer.Tokenize(test);
            stopWatch.Stop();

            Console.WriteLine($"Your tokenizer found {result.Count()} in {stopWatch.ElapsedMilliseconds} ms");
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789 ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static void WriteTokens(IEnumerable<string> tokens, MergeRule mergeRule = null)
        {
            var currentTokenString = string.Join("|", tokens);
            if (mergeRule == null)
                Console.WriteLine($"|{currentTokenString}|");
            else
                Console.WriteLine($"|{currentTokenString}| ← Applied merge rule #{mergeRule.Priority} ({mergeRule})");
        }
    }
}
