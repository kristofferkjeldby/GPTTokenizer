namespace GPTTokenizer.Models
{
    using GPTTokenizer.Models.Merge;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeLogEntry
    {
        public MergeLogEntry(string tokens)
        {
            this.Tokens = tokens.Split(Constants.Space);
        }

        public MergeLogEntry(string tokens, MergeRule mergeRule)
        {
            this.Tokens = tokens.Split(Constants.Space);
            this.MergeRule = mergeRule;
        }

        public string[] Tokens;

        public MergeRule MergeRule {  get; set; }
    }
}
