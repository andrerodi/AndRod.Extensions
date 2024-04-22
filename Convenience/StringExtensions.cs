using System.Text.RegularExpressions;

namespace Extensions;

public static partial class StringExtensions
{
    private static readonly char[] _separator = ['_'];

    /// <summary>
    /// Converts the input string <paramref name="original"/> to a PascalCase <see cref="string"/>.
    /// <br/>
    /// Example: "hello_world" -> "HelloWorld"
    /// <br/>
    /// Example: "hello world" -> "HelloWorld"
    /// <br/>
    /// Example: "hello-world123" -> "HelloWorld123"
    /// </summary>
    /// <param name="original"></param>
    /// <returns></returns>
    public static string ToPascalCase(this string original)
    {
        Regex invalidCharsRgx = InvalidCharsPattern();
        Regex whiteSpace = WhiteSpacePattern();
        Regex startsWithLowerCaseChar = StartsWithLowerCaseCharPattern();
        Regex firstCharFollowedByUpperCasesOnly = FirstCharFollowedByUpperCasesOnlyPattern();
        Regex lowerCaseNextToNumber = LowerCaseNextToNumber();
        Regex upperCaseInside = UpperCaseInsidePattern();

        // replace white spaces with undescore, then replace all invalid chars with empty string
        var pascalCase = invalidCharsRgx.Replace(whiteSpace.Replace(original, "_"), string.Empty)
            // split by underscores
            .Split(_separator, StringSplitOptions.RemoveEmptyEntries)
            // set first letter to uppercase
            .Select(w => startsWithLowerCaseChar.Replace(w, m => m.Value.ToUpper()))
            // replace second and all following upper case letters to lower if there is no next lower (ABC -> Abc)
            .Select(w => firstCharFollowedByUpperCasesOnly.Replace(w, m => m.Value.ToLower()))
            // set upper case the first lower case following a number (Ab9cd -> Ab9Cd)
            .Select(w => lowerCaseNextToNumber.Replace(w, m => m.Value.ToUpper()))
            // lower second and next upper case letters except the last if it follows by any lower (ABcDEf -> AbcDef)
            .Select(w => upperCaseInside.Replace(w, m => m.Value.ToLower()));

        return string.Concat(pascalCase);
    }

    [GeneratedRegex("[^_a-zA-Z0-9]")]
    private static partial Regex InvalidCharsPattern();
    [GeneratedRegex(@"(?<=\s)")]
    private static partial Regex WhiteSpacePattern();
    [GeneratedRegex("^[a-z]")]
    private static partial Regex StartsWithLowerCaseCharPattern();
    [GeneratedRegex("(?<=[A-Z])[A-Z0-9]+$")]
    private static partial Regex FirstCharFollowedByUpperCasesOnlyPattern();
    [GeneratedRegex("(?<=[0-9])[a-z]")]
    private static partial Regex LowerCaseNextToNumber();
    [GeneratedRegex("(?<=[A-Z])[A-Z]+?((?=[A-Z][a-z])|(?=[0-9]))")]
    private static partial Regex UpperCaseInsidePattern();
}
