namespace GPTTokenizer.Extensions
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    internal static class Extensions
    {
        public static IList<string> ToTokens(this string text)
        {
            return text.Replace(Constants.Space, Constants.SpaceToken).Select(c => c.ToString()).ToList();
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
