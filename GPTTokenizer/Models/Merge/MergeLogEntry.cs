namespace GPTTokenizer.Models
{
    using GPTTokenizer.Models.Merge;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeLogEntry
    {
        public MergeLogEntry(IEnumerable<Token> tokens)
        {
            this.Tokens = tokens.ToArray();
        }

        public MergeLogEntry(IEnumerable<Token> tokens, MergeRule mergeRule)
        {
            this.Tokens = tokens.ToArray();
            this.MergeRule = mergeRule;
        }

        public Token[] Tokens;

        public MergeRule MergeRule {  get; set; }
    }
}
