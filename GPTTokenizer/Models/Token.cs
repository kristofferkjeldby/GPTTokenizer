namespace GPTTokenizer.Models
{
    using System;
    using System.Collections.Generic;

    public class Token : IEquatable<Token>, IEqualityComparer<Token>
    {
        public string Value { get; set; }

        public Token(string value) { 
            Value = value; 
        }

        public Token(char value)
        {
            Value = value.ToString();
        }

        public static Token Merge(Token a, Token b) 
        {
            return new Token(string.Concat(a.Value, b.Value));   
        }

        public override string ToString()
        {
            return Value;
        }

        public bool Equals(Token other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;

            if (obj.GetType() != this.GetType()) return false;

            return Equals((Token)obj);
        }

        public bool Equals(Token a, Token b)
        {
            return a.Equals(b);
        }

        public int GetHashCode(Token a)
        {
            return a.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
