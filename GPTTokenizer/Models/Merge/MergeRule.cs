namespace GPTTokenizer.Models.Merge
{
    public class MergeRule
    {
        private readonly string rule;

        private readonly string replacement;
        private readonly string startWithRule;
        private readonly string startWithReplacement;
        private readonly string containsRule;
        private readonly string containsReplacement;
        private readonly string endWithRule;
        private readonly string endWithReplacement;

        public int Priority { get; }

        public MergeRule(string text, int priority)
        {
            rule = text;
            replacement = text.Replace(" ", string.Empty);

            startWithRule = string.Concat(text, Constants.Space);
            startWithReplacement = string.Concat(replacement, Constants.Space);

            containsRule = string.Concat(Constants.Space, text, Constants.Space);
            containsReplacement = string.Concat(Constants.Space, replacement, Constants.Space);

            endWithRule = string.Concat(Constants.Space, text);
            endWithReplacement = string.Concat(Constants.Space, replacement);

            Priority = priority;
        }

        public bool Apply(ref string tokens)
        {
            var result = false;

            if (tokens.StartsWith(startWithRule))
            {
                tokens = startWithReplacement + tokens.Substring(startWithRule.Length);
                result = true;
            }

            if (tokens.EndsWith(endWithRule))
            {
                tokens = tokens.Substring(0, tokens.Length - endWithRule.Length) + endWithReplacement;
                result = true;
            }

            if (tokens.Contains(containsRule))
            {
                tokens = tokens.Replace(containsRule, containsReplacement);
                result = true;
            }

            return result;
        }

        public override string ToString()
        {
            return $"{rule}";
        }
    }
}
