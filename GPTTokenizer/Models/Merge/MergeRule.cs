namespace GPTTokenizer.Models.Merge
{
    public class MergeRule
    {
        public Token FirstToken { get; }

        public Token SecondToken { get; }

        public int Priority { get; }

        public MergeRule(string text, int priority)
        {
            var split = text.Split(new char[] { ' ' });
            FirstToken = new Token(split[0]);
            SecondToken = new Token(split[1]);
            Priority = priority;
        }

        public MergeRule(Token firstToken, Token secondToken, int priority)
        {
            FirstToken = firstToken;
            SecondToken = secondToken;
            Priority = priority;
        }

        public bool Match(Token firstToken, Token secondToken)
        {
            return FirstToken.Value.Equals(firstToken.Value) && SecondToken.Value.Equals(secondToken.Value);
        }

        public override string ToString()
        {
            return $"{FirstToken.Value} {SecondToken.Value}";
        }
    }
}
