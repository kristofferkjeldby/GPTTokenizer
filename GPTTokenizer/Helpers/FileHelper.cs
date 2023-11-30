namespace GPTTokenizer.Helpers
{
    using GPTTokenizer.Models.Merge;
    using GPTTokenizer.Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using GPTTokenizer.Extensions;

    internal static class FileHelper
    {
        public static List<MergeRule> ReadMergeRules(string filePath) 
        {
            return ReadMergeRules(File.ReadLines(filePath).ToArray());
        }

        public static List<MergeRule> ReadMergeRules(GTPModel model)
        {
            return ReadMergeRules(GetResource("merges", model).Lines());
        }

        private static List<MergeRule> ReadMergeRules(string[] lines)
        {
            var mergeRules = new List<MergeRule>();

            for (var i = 0; i < lines.Count(); i++)
            {
                if (lines[i].StartsWith(Constants.Comment))
                    continue;
                mergeRules.Add(new MergeRule(lines[i], i));
            }

            return mergeRules;
        }

        public static Dictionary<Token, int> ReadVocabulary(string filePath)
        {
            return ReadVocabulary(File.ReadLines(filePath).ToArray());
        }

        public static Dictionary<Token, int> ReadVocabulary(GTPModel model)
        {
            return ReadVocabulary(GetResource("vocab", model).Lines());
        }

        private static Dictionary<Token, int> ReadVocabulary(string[] lines)
        {
            var vocabulary = new Dictionary<Token, int>();

            for (var i = 0; i < lines.Count(); i++)
            {
                var parts = lines[i].Trim().Split(':').ToArray();

                if (parts.Length < 2)
                    continue;

                if (!int.TryParse(parts.Last().Trim(' ', ','), out var priority))
                    continue;

                vocabulary.Add(new Token(string.Join(":", parts.Take(parts.Length - 1)).Trim(' ', '"')), priority);
            }

            return vocabulary;
        }

        private static string GetResource(string prefix, GTPModel model)
        {
            return Properties.Resources.ResourceManager.GetString($"{prefix}_{model}");
        }
    }
}
