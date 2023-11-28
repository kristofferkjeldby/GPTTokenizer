namespace GPTTokenizer.Models.Merge
{
    using System.Collections.Generic;

    public class MergeLog
    {
        private List<MergeLogEntry> entries = new List<MergeLogEntry>();

        public void Add(IEnumerable<Token> tokens)
        {
            entries.Add(new MergeLogEntry(tokens));
        }

        public void Add(IEnumerable<Token> tokens, MergeRule mergeRule)
        {
            entries.Add(new MergeLogEntry(tokens, mergeRule));
        }

        public IEnumerable<MergeLogEntry> Entries => entries;
    }
}
