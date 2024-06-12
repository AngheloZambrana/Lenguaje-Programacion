using System;

namespace PrimeraAplicacion
{
    static public class RegexExtensions
    {
        public static string GetString<T>(this T value)
        {
            if (value == null)
                return null;
            else
                return value.ToString();
        }

        public static string Concatenation<T>(this string value1, T value2)
        {
            string stringValue1 = value1.GetString();
            string stringValue2 = value2.GetString();

            if (stringValue1 == null || stringValue2 == null)
                return null;
            else
                return $"{stringValue1}{stringValue2}";
        }
        public static Func<string> Closo(string character)
        {
            int count = 0;
            return () =>
            {
                string currentString = string.Empty;
                for(int i = 0; i < count; i++)
                { 
                    currentString += character;
                }
                count++;
                return currentString;
            };
        }
        public static string Union(this string value1, string value2)
        {
            if (string.IsNullOrEmpty(value1))
            {
                return value2;
            }
            else if (string.IsNullOrEmpty(value2))
            {
                return value1;
            }
            else if (value1 == value2)
            {
                return value1;
            }
            else
            {
                return value1 + value2;
            }
        }
        public static HashSet<string> CombineStrings(string str1, string str2)
        {
            HashSet<string> set = new HashSet<string>();
            if (!string.IsNullOrEmpty(str1))
                set.Add(str1);
            if (!string.IsNullOrEmpty(str2))
                set.Add(str2);
            return set;
        }
        public static HashSet<T> Union<T>(this HashSet<T> set1, HashSet<T> set2)
        {
            HashSet<T> resultSet = new HashSet<T>(set1);
            resultSet.UnionWith(set2);
            return resultSet;
        }

        public static HashSet<T> Union<T>(this HashSet<T> set, T element)
        {
            HashSet<T> resultSet = new HashSet<T>(set);
            resultSet.Add(element);
            return resultSet;
        }
        public static string GetString<T>(this HashSet<T> set)
        {
            return string.Join(",", set);
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

        public static HashSet<HashSet<T>> Closure<T>(this HashSet<T> set)
        {
            HashSet<HashSet<T>> closureSet = new HashSet<HashSet<T>>();
            closureSet.Add(new HashSet<T>());

            foreach (var item in set)
            {
                var currentSubset = new HashSet<T>();
                currentSubset.Add(item);

                var newSets = new HashSet<HashSet<T>>();
                foreach (var subset in closureSet)
                {
                    var newSubset = new HashSet<T>(subset);
                    newSubset.UnionWith(currentSubset);
                    newSets.Add(newSubset);
                }

                closureSet.UnionWith(newSets);
            }

            return closureSet;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string voidLanguage = null;
            string EmptyVoid = string.Empty;
            string a = "A";
            Console.WriteLine(voidLanguage is null);
            Console.WriteLine(EmptyVoid == string.Empty);
            Console.WriteLine(EmptyVoid.Length == 0);
            Console.WriteLine(a == "A");
            Console.WriteLine(a.Length == 1);
            Console.WriteLine(voidLanguage != EmptyVoid);
            Console.WriteLine(a != EmptyVoid);

            Console.WriteLine(RegexExtensions.GetString(voidLanguage));

            Console.WriteLine(RegexExtensions.Concatenation(a, voidLanguage) is null); 
            Console.WriteLine(RegexExtensions.Concatenation(a, EmptyVoid).Length == 1);
            Console.WriteLine(RegexExtensions.Concatenation(a, a).Length == 2);

            var generator = RegexExtensions.Closo(a);
            
            for (int i = 0; i < 5; i++)
            {
            
                Console.WriteLine(generator());
            }

            string b = "b";
            string c = "c";

            Console.WriteLine($"Union of '{a}' and '{b}': {a.Union(b)}"); 
            Console.WriteLine($"Union of '{a}' and '{a}': {a.Union(a)}");
            Console.WriteLine($"Union of empty string and '{a}': {string.Empty.Union(a)}");
            Console.WriteLine($"Union of '{a}' and empty string: {a.Union(string.Empty)}"); 
            Console.WriteLine($"Union of empty strings: {string.Empty.Union(string.Empty)}"); 

            HashSet<string> combinedSet = RegexExtensions.CombineStrings(c, b);
            
            HashSet<string> f = new HashSet<string> { "a", "b" };
            string h = "h";

            HashSet<string> unionCH = f.Union(h);
            Console.WriteLine("\nUnion of set c and string h:");
            foreach (var item in unionCH)
            {
                Console.WriteLine(item);
            }

            
            Console.WriteLine("Combined set:");
            foreach (var item in combinedSet)
            {
                Console.WriteLine(item);
            }
            HashSet<string> d = new HashSet<string> { "a", "b" };
            HashSet<string> e = new HashSet<string> { "1", "2", "3" };

            HashSet<string> unionAB = d.Union(e);
            Console.WriteLine("Union of sets a and b:");
            foreach (var item in unionAB)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("HashSet a: " + unionAB.GetString());
            HashSet<string> concatenateAB = d.Concatenation(e);
            Console.WriteLine("Concatenated set:");
            foreach (var item in concatenateAB)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("HashSet a: " + concatenateAB.GetString());

            HashSet<int> set = new HashSet<int> { 1, 2, 3 };
            var closure = set.Closure();

            Console.WriteLine("Closure of set:");
            foreach (var subset in closure)
            {
                Console.WriteLine(string.Join(",", subset));
            }

        }
    }
}
