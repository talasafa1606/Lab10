namespace InMindAcademy.Lab10.Tala;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Switch between different casing styles
/// </summary>
public static class StringFormatter
{
    /// <summary>
    /// Converts a string to PascalCase , ex : ThisIsAnExample
    /// </summary>
    public static string ToPascalCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        string[] words = Regex.Split(input, @"[\s_\-.]")
            .Where(word => !string.IsNullOrEmpty(word))
            .ToArray();

        return string.Join("", words
            .Select(word => char.ToUpper(word[0]) + (word.Length > 1 ? word.Substring(1).ToLower() : "")));
    }

    /// <summary>
    /// Converts a string to camelCase , ex : thisIsAnExample
    /// </summary>
    public static string ToCamelCase(string input)
    {
        string pascalCase = ToPascalCase(input);
        
        if (string.IsNullOrEmpty(pascalCase))
            return pascalCase;
            
        return char.ToLower(pascalCase[0]) + (pascalCase.Length > 1 ? pascalCase.Substring(1) : "");
    }

    /// <summary>
    /// Converts a string to snake_case , ex : this_is_an_example
    /// </summary>
    public static string ToSnakeCase(string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        string normalizedInput = Regex.Replace(input, @"[\s\-.]", "_");
        
        string result = Regex.Replace(normalizedInput, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        
        return Regex.Replace(result, @"_+", "_");
    }

    /// <summary>
    /// Converts a string to kebab-case , ex: this-is-an-example
    /// </summary>
    public static string ToKebabCase(string input)
    {
        return ToSnakeCase(input).Replace('_', '-');
    }
}


