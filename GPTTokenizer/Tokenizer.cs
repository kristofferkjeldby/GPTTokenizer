namespace GPTTokenizer
{
    using GPTTokenizer.Extensions;
    using GPTTokenizer.Helpers;
    using GPTTokenizer.Models;
    using GPTTokenizer.Models.Merge;
    using System.Collections.Generic;
    using System.Linq;

    public class Tokenizer
    {
        private IEnumerable<MergeRule> MergeRules { get; }

        private IDictionary<string, int> Vocabulary { get; }

        public Tokenizer(GTPModel model)
        {
            MergeRules = FileHelper.ReadMergeRules(model).OrderBy(r => r.Priority);
            Vocabulary = FileHelper.ReadVocabulary(model);
        }

        public Tokenizer(string mergesFile, string vocabularyFile)
        {
            MergeRules = FileHelper.ReadMergeRules(mergesFile).OrderBy(r => r.Priority);
            Vocabulary = FileHelper.ReadVocabulary(vocabularyFile);
        }

        public IEnumerable<string> Tokenize(string input, MergeLog mergeLog = null)
        {
            var tokens = input.ToStringBuilder();

            mergeLog?.Add(tokens.FromStringBuilder());

            foreach (var mergeRule in MergeRules)
            {
                if (mergeRule.Apply(tokens, mergeLog != null))
                    mergeLog?.Add(tokens.FromStringBuilder(), mergeRule);
            }

            return tokens.FromStringBuilder();
        }

        public int CountTokens(string text)
        {
            return Tokenize(text).Count();
        }

        public int? GetID(string token)
        {
            if (Vocabulary.ContainsKey(token))
                return Vocabulary[token];
            return null;
        }

        public IEnumerable<int?> GetIDs(IEnumerable<string> tokens)
        {
            return tokens.Select(t => GetID(t));
        }
    }
}
