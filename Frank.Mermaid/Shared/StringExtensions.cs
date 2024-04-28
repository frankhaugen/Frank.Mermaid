using System.Text;

namespace Frank.Mermaid;

public static class StringExtensions
{
    internal static string CleanNonAlphanumeric(this string value, bool keepNewLines = false)
    {
        var stringBuilder = new StringBuilder();
        foreach (var c in value.ReplaceLineEndings("\n"))
            if (char.IsLetterOrDigit(c))
                stringBuilder.Append(c);
            else if (keepNewLines && c == '\n') 
                stringBuilder.Append(c);
        return stringBuilder.ToString();
    }
}