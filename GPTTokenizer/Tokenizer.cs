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

        private IDictionary<int, string> ReverseVocabulary { get; }

        public Tokenizer(GPTModel model)
        {
            Vocabulary = FileHelper.ReadVocabulary(model);
            ReverseVocabulary = Vocabulary.ToDictionary(kv => kv.Value, kv => kv.Key);
            MergeRules = FileHelper.ReadMergeRules(model, Vocabulary).OrderBy(r => r.Priority);
        }

        public Tokenizer(string mergesFile, string vocabularyFile)
        {
            Vocabulary = FileHelper.ReadVocabulary(vocabularyFile);
            ReverseVocabulary = Vocabulary.ToDictionary(kv => kv.Value, kv => kv.Key);
            MergeRules = FileHelper.ReadMergeRules(mergesFile, Vocabulary).OrderBy(r => r.Priority);
        }

        public IEnumerable<string> Tokenize(string input, MergeLog mergeLog = null)
        {
            var tokens = input.ToInts(Vocabulary);

            mergeLog?.Add(tokens.FromInts(ReverseVocabulary));

            foreach (var mergeRule in MergeRules)
            {
                if (mergeRule.Apply(tokens))
                    mergeLog?.Add(tokens.FromInts(ReverseVocabulary), mergeRule);
            }

            return tokens.FromInts(ReverseVocabulary);
        }

        public int CountTokens(string text)
        {
            return Tokenize(text, null).Count();
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
