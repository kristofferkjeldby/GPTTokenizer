namespace GPTTokenizer.Helpers
{
    using GPTTokenizer.Models.Merge;
    using GPTTokenizer.Models;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal static class FileHelper
    {
        public static List<MergeRule> ReadMergeRules(string mergesFilePath = null)
        {
            var mergeRules = new List<MergeRule>();

            List<string> lines;

            if (string.IsNullOrEmpty(mergesFilePath))
            {
                lines = new List<string>();

                using (StringReader reader = new StringReader(Properties.Resources.MergeRules))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            else
            {
                lines = File.ReadLines(mergesFilePath).ToList();
            }

            for (var i = 0; i < lines.Count(); i++)
            {
                if (lines[i].StartsWith(Constants.Comment))
                    continue;
                mergeRules.Add(new MergeRule(lines[i], i));
            }

            return mergeRules;
        }

        public static Dictionary<Token, int> ReadVocabulary(string vocabularyFilePath = null)
        {
            var vocabulary = new Dictionary<Token, int>(); 

            using (StringReader reader = new StringReader(Properties.Resources.Vocabulary))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Trim().Split(':').ToArray();

                    if (parts.Length < 2)
                        continue;

                    if (!int.TryParse(parts.Last().Trim(' ', ','), out var priority))
                        continue;

                    vocabulary.Add(new Token(string.Join(":", parts.Take(parts.Length - 1)).Trim(' ', '"')), priority);
                }
            }

            return vocabulary;

        }
    }
}
