namespace GPTTokenizer.Extensions
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal static class Extensions
    {
        public static List<int> ToInts(this string text, IDictionary<string, int> vocabulary)
        {
            return text.Replace(Constants.Space, Constants.SpaceToken).ToCharArray().Select(c => vocabulary[c.ToString()]).ToList();
        }

        public static string[] FromInts(this List<int> tokens, IDictionary<int, string> reverseVocabulary)
        {
            return tokens.Select(t => reverseVocabulary[t]).ToArray();
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

        public static string JsonUnescape(this string text)
        {
            return text.Replace("\\\"", "\"").Replace("\\\\", "\\");
        }
    }
}
