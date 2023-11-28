namespace GPTTokenizer
{
    using GPTTokenizer.Helpers;
    using GPTTokenizer.Models;
    using GPTTokenizer.Models.Merge;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tokenizer
    {
        public List<MergeRule> MergeRules { get; }

        public Dictionary<Token, int> Vocabulary { get; }

        public Tokenizer(string mergesFile = null, string vocabularyFile = null)
        {
            MergeRules = FileHelper.ReadMergeRules(mergesFile);
            Vocabulary = FileHelper.ReadVocabulary(vocabularyFile);
        }

        public List<Token> Tokenize(string text, MergeLog mergeLog = null)
        {
            var tokens = text.Replace(' ', Constants.Space).Select(c => new Token(c)).ToList();

            mergeLog?.Add(tokens);

            foreach (var mergeRule in MergeRules.OrderBy(r => r.Priority))
            {
                for (int i = 0; i < tokens.Count() - 1; i++)
                {
                    var token = tokens[i];
                    var nextToken = tokens[i + 1];

                    if (mergeRule.Match(token, nextToken))
                    {
                        var mergedToken = Token.Merge(token, nextToken);

                        if (!Vocabulary.ContainsKey(mergedToken))
                            throw new Exception($"Cannot merge to a token that is not in the vocabulary: {mergeRule}");

                        tokens[i] = mergedToken;
                        tokens.RemoveAt(i + 1);

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
