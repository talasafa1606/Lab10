using System.Text;
using System.Text.RegularExpressions;

namespace InMindAcademy.Lab10.Tala;

/// <summary>
/// Provides utilities for analyzing text and generating statistics and insights
/// </summary>
public class StringStatistics
{
    private readonly string _text;
    
    /// <summary>
    /// Initialize a new StringStatistics instance with the inserted text
    /// </summary>
    public StringStatistics(string text)
    {
        _text = text ?? "";
    }

    /// <summary>
    /// Gets the total character count of the text
    /// </summary>
    public int CharacterCount => _text.Length;

    /// <summary>
    /// Gets the total character count excluding whitespace
    /// </summary>
    public int CharacterCountWithoutWhitespace => _text.Count(c => !char.IsWhiteSpace(c));

    /// <summary>
    /// Gets the word count in the text
    /// </summary>
    public int WordCount => !string.IsNullOrWhiteSpace(_text) 
        ? Regex.Matches(_text, @"\b\w+\b").Count 
        : 0;

    /// <summary>
    /// Gets the sentence count in the text
    /// </summary>
    public int SentenceCount => !string.IsNullOrWhiteSpace(_text) 
        ? Regex.Matches(_text, @"[.!?]+").Count 
        : 0;

    /// <summary>
    /// Gets a dictionary of words and their frequencies
    /// </summary>
    public Dictionary<string, int> WordFrequency
    {
        get
        {
            var result = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            
            if (string.IsNullOrWhiteSpace(_text))
                return result;
            
            var words = Regex.Matches(_text, @"\b\w+\b")
                .Cast<Match>()
                .Select(m => m.Value.ToLower());
            
            foreach (var word in words)
            {
                if (result.ContainsKey(word))
                    result[word]++;
                else
                    result[word] = 1;
            }
            
            return result;
        }
    }

    /// <summary>
    /// Gets the most common word in the text
    /// </summary>
    public string MostCommonWord
    {
        get
        {
            var frequency = WordFrequency;
            return frequency.Any() 
                ? frequency.OrderByDescending(kv => kv.Value).First().Key 
                : string.Empty;
        }
    }

    /// <summary>
    /// Gets the least common word in the text
    /// </summary>
    public string LeastCommonWord
    {
        get
        {
            var frequency = WordFrequency;
            return frequency.Any() 
                ? frequency.OrderBy(kv => kv.Value).First().Key 
                : string.Empty;
        }
    }

    /// <summary>
    /// Gets the average word length in the text
    /// </summary>
    public double AverageWordLength
    {
        get
        {
            var words = Regex.Matches(_text, @"\b\w+\b")
                .Cast<Match>()
                .Select(m => m.Value);
            
            return words.Any() 
                ? words.Average(w => w.Length) 
                : 0;
        }
    }

    /// <summary>
    /// Returns a comprehensive statistical report of the text
    /// </summary>
    public string GetTextReport()
    {
        var sb = new StringBuilder();
        sb.AppendLine("TEXT ANALYSIS REPORT");
        sb.AppendLine("-------------------");
        sb.AppendLine($"Character count: {CharacterCount}");
        sb.AppendLine($"Character count (without whitespace): {CharacterCountWithoutWhitespace}");
        sb.AppendLine($"Word count: {WordCount}");
        sb.AppendLine($"Sentence count: {SentenceCount}");
        sb.AppendLine($"Average word length: {AverageWordLength:F2} characters");
        
        if (!string.IsNullOrEmpty(MostCommonWord))
            sb.AppendLine($"Most common word: '{MostCommonWord}' ({WordFrequency[MostCommonWord]} occurrences)");
        
        if (!string.IsNullOrEmpty(LeastCommonWord))
            sb.AppendLine($"Least common word: '{LeastCommonWord}' ({WordFrequency[LeastCommonWord]} occurrences)");
        
        return sb.ToString();
    }
}