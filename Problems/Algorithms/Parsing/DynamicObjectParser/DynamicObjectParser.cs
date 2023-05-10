using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Problems.Algorithms.Parsing.DynamicObjectParser;

/// <summary>
/// Write a simple parser for a configuration file conforming to the following rules.
/// 
/// Sample configuration file:
/// UserName: admin;
/// Password: super password;
/// 
/// TimeToLive: 4;
/// IsEnabled: true;
/// 
/// Assumptions:
/// - A configuration file will always use the format shown above; i.e. each non-empty line will contain 
/// a key name, then a colon and then a value;
/// - Key names are case sensitive.
/// - A key value can be a Boolean (true, false), an integer (e.g. 1, -2, 44) or a string.
/// - All values that are not Booleans or integers will be treated as strings.
/// - Integer values can be safely stored in variables of type int.
/// Integer values will be written as a series of digits (and only digits), 
/// with an additional minus sign at the beginning for for negative numbers.
/// A configuration file can contain empty lines.
/// Neither a key name nor a value will contain a colon.
/// Each line in a configuration file, except for empty lines, will have a semicolon at the end.
/// 
/// Additional Requirements:
/// - The parsing method should have the following signature: public dynamic Parse(string configuration).
/// - Every key name found in a configuration file should be exposed as a property of an object returned from a parse, 
/// e.g. var r = parser.Parse(s); Console.WriteLine(r.TimeToLive);. These properties should be of an appropriate type, 
/// i.e. bool, int or string.
/// - A parsing method should trhow an exception ARgumentException if a provided string is null or empty.
/// - The parser should trim off all key names and string values.
/// - If someone tries to read a property (a key) which is not found in a configuration file then an exception should 
/// be thrown (in the following way: throw new EmptyKeyException():).
/// - If a key found in a configuration file cannot be used as a property in C# then an exception should be throw
/// in the following way: throw new InvalidKeyException();). You can assume that a key name is correct
/// if an only if it consists of letters (a-z and A-Z) and digits (0-9), and does not start with a digit.
/// You should throw a an exception (in the followin way: throw new DuplicateKeyException()) if a duplicated key name is found in 
/// a configuration file.
/// </summary>
public class DynamicObjectParser : IParser
{
    private static readonly char[] _trimChars = new char[] { ' ', '\t' };

    public dynamic? Parse(string? configuration)
    {
        if (configuration == null)
            throw new ArgumentException("Congfiguration is null!");
        else if (configuration.Length == 0)
            return new ConfigurationBag();

        dynamic output = new ConfigurationBag();
        foreach (var line in configuration.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries))
        {
            var row = line;
            var columns = row.Split(':');
            var key = columns[0].Trim(_trimChars);

            var value = columns[1].Trim(_trimChars);
            value = value.Substring(0, value.Length - 1).Trim(_trimChars);
            if (bool.TryParse(value, out bool boolean))
                output[key] = boolean;
            else if (int.TryParse(value, out int integer))
                output[key] = integer;
            else
                output[key] = value;
        }

        return output;
    }
}

public interface IParser
{
    public dynamic? Parse(string configuration);
}

public class ConfigurationBag : DynamicObject
{
    private const string _validPropertyRegex = "^(?![0-9])[a-zA-Z0-9]+$";
    Dictionary<string, object> _dictionary = new();

    public object? this[string key]
    {
        get
        {
            if (!_dictionary.ContainsKey(key))
                throw new UnknownKeyException();

            _dictionary.TryGetValue(key, out object? value);

            return value;
        }
        set
        {
            if(value == null || (value.GetType() == typeof(string) && value.ToString() == string.Empty))
                throw new ArgumentException($"Value for key: '{key}', is emtpy!");

            if (string.IsNullOrEmpty(key))
                throw new EmptyKeyException();

            if (!IsValidPropertyName(key))
                throw new InvalidKeyException();

            if(!_dictionary.TryAdd(key, value!))
                throw new InvalidKeyException();
        }
    }

    public override bool TryGetMember(GetMemberBinder binder, out object? result) {
        if (!_dictionary.ContainsKey(binder.Name))
            throw new UnknownKeyException();
        
        return _dictionary.TryGetValue(binder.Name, out result);
    }

    public override bool TrySetMember(SetMemberBinder binder, object? value)
    {
        if (_dictionary.ContainsKey(binder.Name))
            throw new DuplicateKeyException();

        _dictionary[binder.Name] = value!;

        return true;
    }

    private static bool IsValidPropertyName(string prop)
        => Regex.IsMatch(prop, _validPropertyRegex);
}

public class EmptyKeyException : Exception { }

public class InvalidKeyException : Exception { }

public class DuplicateKeyException : Exception { }

public class UnknownKeyException : Exception { }
