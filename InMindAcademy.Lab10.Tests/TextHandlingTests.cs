using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace InMindAcademy.Lab10.Tests;
using InMindAcademy.Lab10.Tala;


[TestClass]
public class StringFormatterTests
{
    [TestMethod]
    public void ToPascalCase_ConvertsDifferentFormats()
    {
        string snakeCase = "tala_trying_her_package";
        string kebabCase = "tala-trying-her-package";
        string withSpaces = "tala trying her package";
        
        string pascalFromSnake = StringFormatter.ToPascalCase(snakeCase);
        string pascalFromKebab = StringFormatter.ToPascalCase(kebabCase);
        string pascalFromSpaces = StringFormatter.ToPascalCase(withSpaces);
        
        Assert.AreEqual("TalaTryingHerPackage", pascalFromSnake);
        Assert.AreEqual("TalaTryingHerPackage", pascalFromKebab);
        Assert.AreEqual("TalaTryingHerPackage", pascalFromSpaces);
    }
    
    [TestMethod]
    public void ToCamelCase_ConvertsDifferentFormats()
    {
        string snakeCase = "tala_trying_her_package";
        string kebabCase = "tala-trying-her-package";
        string withSpaces = "tala trying her package";
        
        
        string camelFromSnake = StringFormatter.ToCamelCase(snakeCase);
        string camelFromKebab = StringFormatter.ToCamelCase(kebabCase);
        string camelFromSpaces = StringFormatter.ToCamelCase(withSpaces);
        
        Assert.AreEqual("talaTryingHerPackage", camelFromSnake);
        Assert.AreEqual("talaTryingHerPackage", camelFromKebab);
        Assert.AreEqual("talaTryingHerPackage", camelFromSpaces);
    }
    
    [TestMethod]
    public void ToSnakeCase_ConvertsDifferentFormats()
    {
        string pascalCase = "TalaTryingHerPackage";
        string camelCase = "talaTryingHerPackage";
        string kebabCase = "tala-trying-her-package";
        
        string snakeFromPascal = StringFormatter.ToSnakeCase(pascalCase);
        string snakeFromCamel = StringFormatter.ToSnakeCase(camelCase);
        string snakeFromKebab = StringFormatter.ToSnakeCase(kebabCase);
        
        Assert.AreEqual("tala_trying_her_package", snakeFromPascal);
        Assert.AreEqual("tala_trying_her_package", snakeFromCamel);
        Assert.AreEqual("tala_trying_her_package", snakeFromKebab);
    }
    
    [TestMethod]
    public void ToKebabCase_ConvertsDifferentFormats()
    {
        string pascalCase = "TalaTryingHerPackage";
        string camelCase = "talaTryingHerPackage";
        string snakeCase = "tala_trying_her_package";
        
        string kebabFromPascal = StringFormatter.ToKebabCase(pascalCase);
        string kebabFromCamel = StringFormatter.ToKebabCase(camelCase);
        string kebabFromSnake = StringFormatter.ToKebabCase(snakeCase);
        
        Assert.AreEqual("tala-trying-her-package", kebabFromPascal);
        Assert.AreEqual("tala-trying-her-package", kebabFromCamel);
        Assert.AreEqual("tala-trying-her-package", kebabFromSnake);
    }
}

[TestClass]
public class StringStatisticsTests
{
    [TestMethod]
    public void StringStatistics_BasicProperties()
    {
        string text = "Hello! This is a test of my package. This is only a test.";
        var stats = new StringStatistics(text);
        
        Assert.AreEqual(57, stats.CharacterCount);
        Assert.AreEqual(45, stats.CharacterCountWithoutWhitespace);
        Assert.AreEqual(13, stats.WordCount);
        Assert.AreEqual(3, stats.SentenceCount);
    }
    
    [TestMethod]
    public void StringStatistics_WordFrequency()
    {
        string text = "This is a test. This is only a test.";
        var stats = new StringStatistics(text);
        
        var frequency = stats.WordFrequency;
        
        Assert.AreEqual(2, frequency["this"]);
        Assert.AreEqual(2, frequency["is"]);
        Assert.AreEqual(2, frequency["a"]);
        Assert.AreEqual(2, frequency["test"]);
        Assert.AreEqual(1, frequency["only"]);
    }
    
    [TestMethod]
    public void StringStatistics_MostAndLeastCommonWords()
    {
        string text = "This is a test. This is only a test. This is great.";
        var stats = new StringStatistics(text);
        
        Assert.AreEqual("this", stats.MostCommonWord);
        Assert.AreEqual(3, stats.WordFrequency[stats.MostCommonWord]);
        
        Assert.AreEqual(1, stats.WordFrequency[stats.LeastCommonWord]);
    }
}


