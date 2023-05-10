using Problems.Algorithms.Parsing.DynamicObjectParser;
using System;
using Xunit;

namespace Tests.Problems.Algorithms.Parsing.DynamicObjectParserTests;
public class ParseTests
{
    [Fact]
    public void ShouldReturnNegativeInteger_WhenValueNegative()
    {
        var parser = new DynamicObjectParser();
        var value = -123;
        var input = $"value: {value};";

        var config = parser.Parse(input);

        Assert.Equal(value, config?.value);
    }

    [Fact]
    public void ShouldReturnInteger_WhenValueNeedsToBeTrimmed()
    {
        var parser = new DynamicObjectParser();
        var value = 123;
        var input = $"value:             {value}         ;";

        var config = parser.Parse(input);

        Assert.Equal(value, config?.value);
    }

    [Fact]
    public void ShouldReturnInteger_WhenValueIsInteger()
    {
        var parser = new DynamicObjectParser();
        var value = 123;
        var input = $"value: {value};";

        var config = parser.Parse(input);

        Assert.Equal(value, config?.value);
    }

    [Theory]
    [InlineData(true, "value: true;")]
    [InlineData(false, "value: false;")]
    public void ShouldReturnBooleanT_WhenValueIsBoolean(bool expected, string input)
    {
        var parser = new DynamicObjectParser();

        var config = parser.Parse(input);

        Assert.Equal(expected, config?.value);
    }

    [Fact]
    public void ShouldReturnString_WhenValueIsString()
    {
        var parser = new DynamicObjectParser();
        var value = "abc";
        var input = $"value: {value};";

        var config = parser.Parse(input);

        Assert.Equal(value, config?.value);
    }

    [Fact]
    public void ShouldTrimTabsForStringValueOnEdgeOnly_WhenValueHasTabs()
    {
        var parser = new DynamicObjectParser();
        var value = "\tab\tc\t";
        var input = $"value: {value};\t   \t";
        var expected = "ab\tc";

        var config = parser.Parse(input);

        Assert.Equal(expected, config?.value);
    }

    [Fact]
    public void ShouldTrimTabsForStringValue_WhenValueHasTabs()
    {
        var parser = new DynamicObjectParser();
        var value = "\tabc\t";
        var input = $"value: {value};";
        var expected = "abc";

        var config = parser.Parse(input);

        Assert.Equal(expected, config?.value);
    }

    [Fact]
    public void ShouldThrowUnknownKeyException_WhenKeyDoesNotExists()
    {
        var parser = new DynamicObjectParser();
        var value = 123;
        var input = $"value: {value};";

        Assert.Throws<UnknownKeyException>(() => parser.Parse(input)?.Key);
    }

    [Fact]
    public void ShouldThrowArgumentException_WhenConfigurationIsNull()
    {
        var parser = new DynamicObjectParser();

        Assert.Throws<ArgumentException>(() => parser.Parse(null));
    }

    [Fact]
    public void ShouldThrowEmtpyKeyException_WhenKeyIsEmtpy()
    {
        var parser = new DynamicObjectParser();
        var value = 123;
        var input = $": {value};";

        Assert.Throws<EmptyKeyException>(() => parser.Parse(input));
    }

    [Theory]
    [InlineData($"1value: true;")]
    [InlineData($"!value: true;")]
    [InlineData($"value!: true;")]
    [InlineData($"val!ue: true;")]
    [InlineData($"val ue: true;")]
    public void ShouldThrowInvalidKeyException_WhenKeyInvalid(string input)
    {
        var parser = new DynamicObjectParser();

        Assert.Throws<InvalidKeyException>(() => parser.Parse(input));
    }

    [Fact]
    public void ShouldReturnSolution_ForInput()
    {
        var parser = new DynamicObjectParser();
        var input =
            @"
                bool1: false;
                int1: 0;
                string1: s;

                bool2: true;
            ";

        var config = parser.Parse(input);

        Assert.Equal(false, config?.bool1);
        Assert.Equal(0, config?.int1);
        Assert.Equal("s", config?.string1);
        Assert.Equal(true, config?.bool2);
    }
}
