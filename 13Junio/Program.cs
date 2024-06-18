using System;
using System.Collections.Generic;

namespace PrimeraAplicacion
{
    public static class RegexExtensions
    {
        public static string GetString<T>(this T value)
        {
            return value?.ToString();
        }

        public static HashSet<string> Concatenation<T, U>(this HashSet<T> set1, HashSet<U> set2)
        {
            var concatenatedSet = new HashSet<string>();

            foreach (var item1 in set1)
            {
                foreach (var item2 in set2)
                {
                    concatenatedSet.Add(item1.ToString() + item2.ToString());
                }
            }

            return concatenatedSet;
        }

        public static HashSet<T> Union<T>(this HashSet<T> set1, HashSet<T> set2)
        {
            HashSet<T> resultSet = new HashSet<T>(set1);
            resultSet.UnionWith(set2);
            return resultSet;
        }

        public static HashSet<string> Concatenation<T, U>(this HashSet<T> set, U value)
        {
            var concatenatedSet = new HashSet<string>();

            if (set == null || set.Count == 0 || value == null)
                return concatenatedSet;

            foreach (var item in set)
            {
                concatenatedSet.Add(item.ToString() + value.ToString());
            }

            return concatenatedSet;
        }

        public static HashSet<string> ConcatenationReversed<U, T>(this U value, HashSet<T> set)
        {
            var concatenatedSet = new HashSet<string>();

            if (set == null || set.Count == 0 || value == null)
                return concatenatedSet;

            foreach (var item in set)
            {
                concatenatedSet.Add(value.ToString() + item.ToString());
            }

            return concatenatedSet;
        }

        public static Func<string> Closure(HashSet<string> set)
        {
            int count = 0;
            List<string> combinations = new List<string>();
            GenerateCombinations("", set, combinations);

            return () =>
            {
                if (count < combinations.Count)
                {
                    return combinations[count++];
                }
                else
                {
                    return null;
                }
            };
        }

        private static void GenerateCombinations(string prefix, HashSet<string> set, List<string> combinations)
        {
            if (!combinations.Contains(prefix))
            {
                combinations.Add(prefix);
            }

            foreach (var item in set)
            {
                GenerateCombinations(prefix + item, set, combinations);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string> { "a", "b" };
            var generator = RegexExtensions.Closure(set);

            Console.WriteLine("Generated combinations:");
            for (int i = 0; i < 3; i++)
            {
                var combination = generator();
                if (combination != null)
                {
                    Console.WriteLine(combination);
                }
                else
                {
                    break;
                }
            }

            // Test Concatenation and Union functions
            HashSet<string> set1 = new HashSet<string> { "a", "b" };
            HashSet<int> set2 = new HashSet<int> { 1, 2, 3 };

            // Concatenation between two HashSets
            HashSet<string> concatenatedSet = set1.Concatenation(set2);
            Console.WriteLine("Concatenation of two HashSets:");
            foreach (var item in concatenatedSet)
            {
                Console.WriteLine(item);
            }

            // Union between two HashSets
            HashSet<string> set3 = new HashSet<string> { "c", "d" };
            HashSet<string> unionSet = set1.Union(set3);
            Console.WriteLine("Union of two HashSets:");
            foreach (var item in unionSet)
            {
                Console.WriteLine(item);
            }

            // Concatenation of HashSet with a generic value
            string value = "prefix_";
            HashSet<string> concatenationWithGeneric = set2.Concatenation(value);
            Console.WriteLine("Concatenation of HashSet with a generic value:");
            foreach (var item in concatenationWithGeneric)
            {
                Console.WriteLine(item);
            }

            // Concatenation of a generic value with a HashSet
            HashSet<string> concatenationReversed = value.ConcatenationReversed(set2);
            Console.WriteLine("Concatenation of a generic value with a HashSet:");
            foreach (var item in concatenationReversed)
            {
                Console.WriteLine(item);
            }
        }
    }
}
