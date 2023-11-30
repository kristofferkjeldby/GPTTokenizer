namespace GPTTokenizer.Extensions
{
    using GPTTokenizer.Models;
    using System.Collections.Generic;
    using System.Linq;

    internal static class Extensions
    {
        public static bool Merge(this IList<Token> tokens, int positions, IDictionary<Token, int> vocabulary = null)
        {
            var mergedToken = Token.Merge(tokens[positions], tokens[positions + 1]);

            if (!vocabulary?.ContainsKey(mergedToken) ?? false)
                return false;

            tokens[positions] = mergedToken;
            tokens.RemoveAt(positions + 1);

            return true;
        }

        public static IList<Token> ToTokens(this string text)
        {
            return text.Replace(Constants.Space, Constants.SpaceToken).Select(c => new Token(c)).ToList();
        }
    }
}
