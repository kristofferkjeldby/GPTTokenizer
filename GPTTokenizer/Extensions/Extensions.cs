namespace GPTTokenizer.Extensions
{
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    internal static class Extensions
    {
        public static StringBuilder ToStringBuilder(this string text)
        {
            return new StringBuilder(
                string.Concat(
                    Constants.SpaceString, 
                    string.Join(Constants.SpaceString, text.Replace(Constants.Space, Constants.SpaceToken).ToCharArray()), 
                    Constants.SpaceString)
                );
        }

        public static string[] FromStringBuilder(this StringBuilder tokens)
        {
            return tokens.ToString().Substring(1, tokens.Length - 2).Split(Constants.Space);
        }

        public static string[] Lines(this string text)
        {
            var lines = new List<string>();

            using (StringReader reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines.ToArray();
        }
    }
}
