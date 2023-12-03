namespace GPTTokenizer.Models
{
    using GPTTokenizer.Models.Merge;

    public class MergeLogEntry
    {
        public MergeLogEntry(string[] tokens)
        {
            this.Tokens = tokens;
        }

        public MergeLogEntry(string[] tokens, MergeRule mergeRule)
        {
            this.Tokens = tokens;
            this.MergeRule = mergeRule;
        }

        public string[] Tokens;

        public MergeRule MergeRule {  get; set; }
    }
}
