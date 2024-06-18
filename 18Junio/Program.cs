using System;
using System.Collections.Generic;
using System.Linq;

public static class HashSetExtensions
{
    public static HashSet<string> Concatenation(this HashSet<string> set1, HashSet<string> set2)
    {
        var concatenatedSet = new HashSet<string>();

        foreach (var item1 in set1)
        {
            foreach (var item2 in set2)
            {
                concatenatedSet.Add(item1 + item2);
            }
        }

        return concatenatedSet;
    }

    public static bool IsMatch(this HashSet<string> set1, string pattern)
    {
        return set1.Contains(pattern);
    }

    public static HashSet<string> Closure(this string element, int limit)
    {
        var closureSet = new HashSet<string> { "" };

        for (int i = 1; i <= limit; i++)
        {
            closureSet.Add(new string(element[0], i));
        }

        return closureSet;
    }

    public static HashSet<string> Union(this HashSet<string> set1, HashSet<string> set2)
    {
        var unionSet = new HashSet<string>(set1);
        foreach (var item in set2)
        {
            unionSet.Add(item);
        }
        return unionSet;
    }

    public static HashSet<string> FormRegex(this string pattern, int limit)
    {
        var result = new HashSet<string> { "" };
        var stack = new Stack<HashSet<string>>();
        var currentSet = new HashSet<string> { "" };

        for (int i = 0; i < pattern.Length; i++)
        {
            char currentChar = pattern[i];

            if (char.IsLetterOrDigit(currentChar))
            {
                currentSet = new HashSet<string> { currentChar.ToString() };
            }
            else if (currentChar == '(')
            {
                stack.Push(result);
                result = new HashSet<string> { "" };
            }
            else if (currentChar == ')')
            {
                if (stack.Count > 0)
                {
                    var previousSet = stack.Pop();
                    result = previousSet.Concatenation(result);
                }
                else
                {
                    throw new ArgumentException("Invalid pattern: mismatched parentheses.");
                }
            }
            else if (currentChar == '*')
            {
                if (currentSet.Any())
                {
                    currentSet = currentSet.First().Closure(limit);
                    result = result.Concatenation(currentSet);
                }
                else
                {
                    throw new ArgumentException("Invalid pattern: '*' operator without preceding character.");
                }
            }
            else if (currentChar == '+')
            {
                int j = i + 1;
                var nextSet = new HashSet<string>();

                while (j < pattern.Length && char.IsLetterOrDigit(pattern[j]))
                {
                    nextSet.Add(pattern[j].ToString());
                    j++;
                }

                currentSet = currentSet.Union(nextSet);
                i = j - 1;
                result = result.Union(currentSet);
            }
            else if (currentChar == '.')
            {
                int j = i + 1;
                var nextSet = new HashSet<string>();

                while (j < pattern.Length && char.IsLetterOrDigit(pattern[j]))
                {
                    nextSet.Add(pattern[j].ToString());
                    j++;
                }

                result = result.Concatenation(nextSet);
                i = j - 1;
            }
        }

        if (currentSet.Count > 0)
        {
            result = result.Concatenation(currentSet);
        }

        return result;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var formRegex1 = new HashSet<string> { "HMundo" };
        Console.WriteLine(formRegex1.IsMatch("HMundo")); // True
        
        var formRegex = "a*".FormRegex(5);
        Console.WriteLine(formRegex.IsMatch("")); // True
        Console.WriteLine(formRegex.IsMatch("aaaaa")); // True
        Console.WriteLine(formRegex.IsMatch("xxxxx")); // False
        
        var formRegex2 = "(1+0)*.10".FormRegex(5);
        Console.WriteLine($"\nIs '1010' matched in formRegex2? {formRegex2.IsMatch("1010")}"); // True
        Console.WriteLine($"Is '01' matched in formRegex2? {formRegex2.IsMatch("01")}"); // False
        Console.WriteLine($"Is '2' matched in formRegex2? {formRegex2.IsMatch("2")}"); // False

        var formRegex3 = "(H+o+l+a) *mundo".FormRegex(5);
        Console.WriteLine(formRegex3.IsMatch("mundo")); // true
    }
}
