using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AirportManager.API.Helpers;

public static class StringUtils
{
    private static readonly Dictionary<string, string> Irregulars = new()
    {
        { "child", "children" },
        { "man", "men" },
        { "woman", "women" },
        { "mouse", "mice" },
        { "goose", "geese" },
        { "tooth", "teeth" },
        { "foot", "feet" },
        { "person", "people" },
        { "cactus", "cacti" },
        { "focus", "foci" },
        { "fungus", "fungi" },
        { "nucleus", "nuclei" },
        { "syllabus", "syllabi" },
        { "analysis", "analyses" },
        { "diagnosis", "diagnoses" },
        { "oasis", "oases" },
        { "thesis", "theses" },
        { "crisis", "crises" },
        { "phenomenon", "phenomena" },
        { "criterion", "criteria" },
        { "datum", "data" }
    };

    public static string Pluralize(this string word) // TODO: since it's going to be snakecase, I need to check if the word ends with one of the irregular words
    {
        if (Irregulars.TryGetValue(word, out string? plural))
        {
            if (char.IsUpper(word[0]))
                plural = char.ToUpper(plural[0]) + plural[1..];

            return plural;
        }

        // Ends with s, x, z, ch, sh -> add "es"
        string lower = word.ToLower();
        if (lower.EndsWith("s") || lower.EndsWith("x") || lower.EndsWith("z") || lower.EndsWith("ch") || lower.EndsWith("sh"))
            return word + "es";

        // Ends with consonant + y -> replace y with ies
        if (word.Length > 1 && word.EndsWith("y", StringComparison.OrdinalIgnoreCase) &&
            !"aeiou".Contains(char.ToLower(word[^2])))
            return word[..^1] + "ies";

        // Ends with 'fe' -> replace with 'ves'
        if (lower.EndsWith("fe"))
            return word[..^2] + "ves";

        // Ends with 'f' -> replace with 'ves'
        if (lower.EndsWith("f"))
            return word[..^1] + "ves";

        // Default: add 's'
        return word + "s";
    }

    public static string PascalCaseToSnakeCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // Insert underscore before uppercase letters (not at the beginning)
        string result = Regex.Replace(input, @"(?<!^)([A-Z])", "_$1");

        // Convert the entire string to lowercase
        return result.ToLowerInvariant();
    }
}