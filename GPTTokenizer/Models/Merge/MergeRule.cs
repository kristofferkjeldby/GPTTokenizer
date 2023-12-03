namespace GPTTokenizer.Models.Merge
{
    using System.Text;

    public class MergeRule
    {
        private readonly string rule;

        private readonly string replacement;
        private readonly string containsRule;
        private readonly string containsReplacement;

        public int Priority { get; }

        public MergeRule(string text, int priority)
        {
            rule = text;
            replacement = text.Replace(Constants.SpaceString, string.Empty);

            containsRule = string.Concat(Constants.Space, text, Constants.Space);
            containsReplacement = string.Concat(Constants.Space, replacement, Constants.Space);

            Priority = priority;
        }

        public bool Apply(StringBuilder tokens, bool result = false)
        {
            int length = 0;

            if (result)
                length = tokens.Length;

            tokens.Replace(containsRule, containsReplacement);

            if (!result)
                return false;

            return length != tokens.Length;
        }

        public override string ToString() => rule;
    }
}
