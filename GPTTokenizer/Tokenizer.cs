namespace GPTTokenizer
{
    using GPTTokenizer.Extensions;
    using GPTTokenizer.Helpers;
    using GPTTokenizer.Models;
    using GPTTokenizer.Models.Merge;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tokenizer
    {
        private IEnumerable<MergeRule> MergeRules { get; }

        private IDictionary<Token, int> Vocabulary { get; }

        public Tokenizer(string mergesFile = null, string vocabularyFile = null)
        {
            MergeRules = FileHelper.ReadMergeRules(mergesFile).OrderBy(r => r.Priority);
            Vocabulary = FileHelper.ReadVocabulary(vocabularyFile);
        }

        public IList<Token> Tokenize(string text, MergeLog mergeLog = null)
        {
            var tokens = text.ToTokens();

            mergeLog?.Add(tokens);

            foreach (var mergeRule in MergeRules)
            {
                for (int position = 0; position < tokens.Count() - 1; position++)
                {
                    if (mergeRule.Match(tokens, position))
                    {
                        if (!tokens.Merge(position, Vocabulary))
                            throw new Exception($"Cannot merge to a token that is not in the vocabulary: {mergeRule}");

                        mergeLog?.Add(tokens, mergeRule);
                    }
                }
            }

            return tokens;
        }

        public int CountTokens(string text)
        {
            return Tokenize(text).Count();
        }

        public int? GetID(Token token)
        {
            if (Vocabulary.ContainsKey(token))
                return Vocabulary[token];
            return null;
        }

        public IEnumerable<int?> GetIDs(IEnumerable<Token> tokens)
        {
            return tokens.Select(t => GetID(t));
        }
    }
}
